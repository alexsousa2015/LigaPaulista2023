using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using LigaPaulista.Core.SDK.DAO.CustomAttributes;
using LigaPaulista.Core.SDK.Enum;
using LigaPaulista.Core.SDK.Exception;
using LigaPaulista.Core.SDK.Utils;

namespace LigaPaulista.Core.SDK.DAO
{
    public class BaseDataAccess
    {

        #region Constructors

        public BaseDataAccess() { }

        #endregion

        #region Properties

        public const string ConnectionClass_SqlClient = "System.Data.SqlClient";

        public enum ConectionServer : int
        {
            Connection_Sql = 0
        }

        private ConectionServer ConectionSystem { get; set; }

        private string ConnectionString
        {
            get
            {
                string StringConexao = string.Empty;
                switch (ConectionSystem)
                {
                    case ConectionServer.Connection_Sql:
                        // Integrator
                        StringConexao = ConfigurationManager.ConnectionStrings["LigaabcConnectionString"].ConnectionString;
                        break;
                }

                return StringConexao;
            }
        }

        private DataContext contextTransaction { get; set; }
        private System.Data.Common.DbCommand commandTransaction { get; set; }
        #endregion

        #region Methods

        public DataContext GetDataContext()
        {
            ConectionSystem = BaseDataAccess.ConectionServer.Connection_Sql;

            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            var Objcommand = factory.CreateCommand();

            var ObjDbConnection = factory.CreateConnection();

            ObjDbConnection.ConnectionString = ConnectionString;

            return new DataContext(ObjDbConnection);
        }

        #region Not Transaction

        /// <summary>
        /// Metódo responsavel por efetuar consultas dinamicas sem a necessidade de criar objetos, so ultilizar em join complexo.
        /// </summary>        
        public IEnumerable<object> ExecuteDynamicTable(DbProviderFactory factory, ConectionServer ConnectionDB, CommandType tipoComando, string storedProcedure, params DbParameter[] parameters)
        {
            ConectionSystem = ConnectionDB;

            var Objcommand = factory.CreateCommand();

            var ObjDbConnection = factory.CreateConnection();

            ObjDbConnection.ConnectionString = ConnectionString;

            using (var context = new DataContext(ObjDbConnection))
            {
                context.Connection.Open();

                var command = CreateCommand(context.Connection, tipoComando, storedProcedure, parameters);
                try
                {
                    var reader = command.ExecuteReader();
                    DataTable tblDynamic = new DataTable();
                    tblDynamic.Load(reader);

                    List<Field> listaField = new List<Field>();
                    foreach (DataColumn itemDataColumn in tblDynamic.Columns)
                        listaField.Add(new Field { FieldName = itemDataColumn.ColumnName, FieldType = itemDataColumn.DataType });


                    Type type = new DynamicClass().CompileResultType(listaField, "ExcelDynamicType");


                    List<object> ListValue = new List<object>();
                    for (int i = 0; i < tblDynamic.Rows.Count; i++)
                    {
                        object Object = Activator.CreateInstance(type);

                        PropertyInfo[] PropertyInfo = type.GetProperties();
                        for (int j = 0; j < PropertyInfo.Count(); j++)
                        {
                            object value = (tblDynamic.Rows[i].ItemArray[j]);
                            if (value == DBNull.Value)
                                value = null;

                            PropertyInfo[j].SetValue(Object, value, null);
                        }

                        ListValue.Add(Object);
                    }

                    return ListValue.AsEnumerable();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command.Dispose();
                    context.Connection.Close();
                }
            }
        }


        /// <summary>
        /// Metodo responsavel por efetuar consultas na base de dados.
        /// Sera devolvido uma listagem de objetos definidos pelo usuario.
        /// </summary>
        /// <typeparam name="T">Entidade que sera usada como retorno</typeparam>
        /// <param name="ConnectionDB">Tipo da conexao</param>
        /// <param name="tipoComando">Tipo do comando</param>
        /// <param name="storedProcedure">Nome do comando</param>
        /// <param name="parameters">Parametros</param>
        /// <returns></returns>
        public IEnumerable<T> ExecuteReader<T>(DbProviderFactory factory, ConectionServer ConnectionDB, CommandType tipoComando, string storedProcedure, params DbParameter[] parameters)
        {
            IEnumerable<T> result = null;
            ConectionSystem = ConnectionDB;

            var Objcommand = factory.CreateCommand();

            var ObjDbConnection = factory.CreateConnection();

            ObjDbConnection.ConnectionString = ConnectionString;

            using (var context = new DataContext(ObjDbConnection))
            {
                context.Connection.Open();

                var command = CreateCommand(context.Connection, tipoComando, storedProcedure, parameters);
                try
                {
                    var reader = command.ExecuteReader();
                    result = context.Translate<T>(reader).ToList();
                    reader.Close();
                }
                catch (System.Exception ex)
                {
                    //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                    throw ex;//System.Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    command.Dispose();
                    context.Connection.Close();
                }
            }

            return result;
        }

        public IEnumerable<T> ExecuteReader<T>(DbProviderFactory factory, ConectionServer ConnectionDB, CommandType tipoComando, string storedProcedure, int CommandTimeout, params DbParameter[] parameters)
        {
            IEnumerable<T> result = null;
            ConectionSystem = ConnectionDB;

            var Objcommand = factory.CreateCommand();

            var ObjDbConnection = factory.CreateConnection();

            ObjDbConnection.ConnectionString = ConnectionString;
            //ObjDbConnection.ConnectionTimeout = CommandTimeout;
            using (var context = new DataContext(ObjDbConnection))
            {
                context.CommandTimeout = CommandTimeout;
                context.Connection.Open();

                var command = CreateCommand(context.Connection, tipoComando, storedProcedure, parameters);
                try
                {
                    var reader = command.ExecuteReader();
                    result = context.Translate<T>(reader).ToList();
                    reader.Close();
                }
                catch (System.Exception ex)
                {

                    throw ex;//System.Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    context.Connection.Close();
                    context.Dispose();
                    command.Parameters.Clear();
                    command.Connection.Close();
                    command.Connection.Dispose();
                    command.Dispose();
                    command = null;
                }
            }

            return result;
        }

        /// <summary>
        /// Metodo responsavel por efetuar uma operação sem retorno no banco de dados
        /// </summary>
        /// <param name="ConnectionDB">Tipo da conexao</param>
        /// <param name="tipoComando">Tipo do comando</param>
        /// <param name="storedProcedure">Nome do comando</param>
        /// <param name="parameters">Parametros</param>
        public void ExecuteNonQuery(DbProviderFactory factory, ConectionServer ConnectionDB, CommandType tipoComando, string storedProcedure, params DbParameter[] parameters)
        {
            ConectionSystem = ConnectionDB;

            var Objcommand = factory.CreateCommand();

            var ObjDbConnection = factory.CreateConnection();

            ObjDbConnection.ConnectionString = ConnectionString;

            using (var context = new DataContext(ObjDbConnection))
            {
                context.Connection.Open();

                var command = CreateCommand(context.Connection, tipoComando, storedProcedure, parameters);
                try
                {
                    command.ExecuteNonQuery();
                    context.Connection.Close();
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == Convert.ToInt32(EnumErroSQL.Constraint))
                    {
                        //throw new ApplicationException("Não foi possível excluir esse registro, pois ele já está sendo utilizada no sistema.");
                        throw new ApplicationException(@"O sistema encontrou um problema ao executar a ação solicitada:</br></br>

                        1. O registro não pode ser excluído pois está sendo utilizado no sistema.</br>
                        2. Uma das informações foi excluída recentemente. (Por favor, atualize a página)");
                    }
                    else
                    {
                        throw new System.Exception(sqlEx.Message, sqlEx.InnerException);
                    }

                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    command.Dispose();
                    context.Connection.Close();
                }

            }

        }

        /// <summary>
        /// Metodo responsavel por efetuar uma operação sem retorno no banco de dados
        /// </summary>
        /// <param name="ConnectionDB">Tipo da conexao</param>
        /// <param name="tipoComando">Tipo do comando</param>
        /// <param name="storedProcedure">Nome do comando</param>
        /// <param name="parameters">Parametros</param>
        public bool ExecuteNonQuery(DbProviderFactory factory, ConectionServer ConnectionDB, CommandType tipoComando, string storedProcedure, int CommandTimeout, params DbParameter[] parameters)
        {
            ConectionSystem = ConnectionDB;

            var Objcommand = factory.CreateCommand();

            var ObjDbConnection = factory.CreateConnection();

            ObjDbConnection.ConnectionString = ConnectionString;

            using (var context = new DataContext(ObjDbConnection))
            {
                context.CommandTimeout = CommandTimeout;
                context.Connection.Open();

                var command = CreateCommand(context.Connection, tipoComando, storedProcedure, parameters);
                try
                {
                    command.ExecuteNonQuery();
                    context.Connection.Close();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
                finally
                {
                    context.Connection.Close();
                    context.Dispose();
                    command.Parameters.Clear();
                    command.Connection.Close();
                    command.Connection.Dispose();
                    command.Dispose();
                    command = null;
                }
            }
        }

        /// <summary>
        /// Metodo responsavel por efetuar operacoes na base de dados e retornar o ID
        /// </summary>
        /// <param name="ConnectionDB">Tipo da conexao</param>
        /// <param name="tipoComando">Tipo do comando</param>
        /// <param name="storedProcedure">Nome do comando</param>
        /// <param name="parameters">Parametros</param>
        public object ExecuteScalar(DbProviderFactory factory, ConectionServer ConnectionDB, CommandType tipoComando, string storedProcedure, params DbParameter[] parameters)
        {
            ConectionSystem = ConnectionDB;


            var Objcommand = factory.CreateCommand();

            var ObjDbConnection = factory.CreateConnection();

            ObjDbConnection.ConnectionString = ConnectionString;

            object oScalar;
            using (var context = new DataContext(ObjDbConnection))
            {
                context.Connection.Open();

                var command = CreateCommand(context.Connection, tipoComando, storedProcedure, parameters);
                try
                {
                    oScalar = command.ExecuteScalar();
                    context.Connection.Close();
                }
                catch (SqlException sqlEx)
                {
                    oScalar = 0;
                    if (sqlEx.Number == Convert.ToInt32(EnumErroSQL.Constraint))
                    {
                        //throw new ApplicationException("Não foi possível excluir esse registro, pois ele já está sendo utilizada no sistema.");
                        throw new ApplicationException(@"O sistema encontrou um problema ao executar a ação solicitada:</br></br>
                                                        1. O registro não pode ser excluído pois está sendo utilizado no sistema.</br>
                                                        2. Uma das informações foi excluída recentemente. (Por favor, atualize a página)");
                    }
                }
                catch (System.Exception ex)
                {
                    oScalar = 0;
                    throw new System.Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    command.Parameters.Clear();
                    command.Dispose();
                    context.Connection.Close();
                }
            }

            return oScalar;

        }

        /// <summary>
        /// Metodo responsavel por efetuar operacoes na base de dados e retornar o ID
        /// </summary>
        /// <param name="ConnectionDB">Tipo da conexao</param>
        /// <param name="tipoComando">Tipo do comando</param>
        /// <param name="storedProcedure">Nome do comando</param>
        /// <param name="parameters">Parametros</param>
        public object ExecuteScalar(ConectionServer ConnectionDB, CommandType tipoComando, string storedProcedure, params DbParameter[] parameters)
        {
            ConectionSystem = ConnectionDB;
            object oScalar;
            using (var context = new DataContext(ConnectionString))
            {
                context.Connection.Open();

                var command = CreateCommand(context.Connection, tipoComando, storedProcedure, parameters);
                try
                {
                    oScalar = command.ExecuteScalar();
                    context.Connection.Close();
                }
                catch (SqlException sqlEx)
                {
                    oScalar = 0;
                    if (sqlEx.Number == Convert.ToInt32(EnumErroSQL.Constraint))
                    {
                        //throw new ApplicationException("Não foi possível excluir esse registro, pois ele já está sendo utilizada no sistema.");
                        throw new ApplicationException(@"O sistema encontrou um problema ao executar a ação solicitada:</br></br>

1. O registro não pode ser excluído pois está sendo utilizado no sistema.</br>
2. Uma das informações foi excluída recentemente. (Por favor, atualize a página)");
                    }
                }
                catch (System.Exception ex)
                {
                    oScalar = 0;
                    throw new System.Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    command.Parameters.Clear();
                    command.Dispose();
                    context.Connection.Close();
                }

            }

            return oScalar;

        }

        /// <summary>
        /// Metodo responsavel por criar o comando para a execucao
        /// </summary>
        /// <param name="ConnectionDB">Tipo da conexao</param>
        /// <param name="tipoComando">Tipo do comando</param>
        /// <param name="storedProcedure">Nome do comando</param>
        /// <param name="parameters">Parametros</param>
        /// <returns></returns>
        private DbCommand CreateCommand(DbConnection connection, CommandType tipoComando, string textSql, params DbParameter[] parameters)
        {
            System.Data.Common.DbCommand command = connection.CreateCommand();
            command.CommandType = tipoComando;
            command.CommandText = textSql;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    command.Parameters.Add(parameter);
            }

            return command;
        }

        #endregion

        #region Transaction
        /// <summary>
        /// Metodo responsavel por criar o comando para a execucao transacionada
        /// </summary>
        /// <param name="ConnectionDB">Tipo da conexao</param>
        /// <param name="tipoComando">Tipo do comando</param>
        /// <param name="storedProcedure">Nome do comando</param>
        /// <param name="parameters">Parametros</param>
        /// <returns></returns>
        private void CreateCommandTransaction(DbConnection connection)
        {
            commandTransaction = connection.CreateCommand();
        }

        /// <summary>
        /// Metodo responsavel pelo inicio de uma conexao transacionada
        /// </summary>
        /// <param name="ConnectionDB"></param>
        public void BeginTransaction(ConectionServer ConnectionDB)
        {
            ConectionSystem = ConnectionDB;
            contextTransaction = new DataContext(ConnectionString);
            contextTransaction.Connection.Open();
            CreateCommandTransaction(contextTransaction.Connection);
            commandTransaction.Transaction = contextTransaction.Connection.BeginTransaction();
        }

        /// <summary>
        /// Metodo que sera executado dentro de uma transacao
        /// </summary>
        /// <param name="tipoComando"></param>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        public void ExecuteNonQueryTransaction(CommandType tipoComando, string storedProcedure, params DbParameter[] parameters)
        {
            commandTransaction.CommandType = tipoComando;
            commandTransaction.CommandText = storedProcedure;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    commandTransaction.Parameters.Add(parameter);
            }

            try
            {
                commandTransaction.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == Convert.ToInt32(EnumErroSQL.Constraint))
                {
                    //throw new ApplicationException("Não foi possível excluir esse registro, pois ele já está sendo utilizada no sistema.");
                    throw new ApplicationException(@"O sistema encontrou um problema ao executar a ação solicitada:</br></br>

                    1. O registro não pode ser excluído pois está sendo utilizado no sistema.</br>
                    2. Uma das informações foi excluída recentemente. (Por favor, atualize a página)");
                }
                else
                {
                    throw new System.Exception(sqlEx.Message, sqlEx.InnerException);
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                commandTransaction.Parameters.Clear();
            }
        }

        /// <summary>
        /// Metodo responsavel por efetuar consultas na base de dados qdo estiver com transacao aberta.
        /// Sera devolvido uma listagem de objetos definidos pelo usuario.
        /// </summary>
        /// <typeparam name="T">Entidade que sera usada como retorno</typeparam>
        /// <param name="ConnectionDB">Tipo da conexao</param>
        /// <param name="tipoComando">Tipo do comando</param>
        /// <param name="storedProcedure">Nome do comando</param>
        /// <param name="parameters">Parametros</param>
        /// <returns></returns>
        public IEnumerable<T> ExecuteReaderTransacrion<T>(CommandType tipoComando, string storedProcedure, params DbParameter[] parameters)
        {
            IEnumerable<T> result = null;

            commandTransaction.CommandType = tipoComando;
            commandTransaction.CommandText = storedProcedure;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    commandTransaction.Parameters.Add(parameter);
            }

            try
            {
                var reader = commandTransaction.ExecuteReader();
                result = contextTransaction.Translate<T>(reader).ToList();
                reader.Close();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                commandTransaction.Parameters.Clear();
            }

            return result;
        }

        /// <summary>
        /// Metodo responsavel por efetuar operacoes na base de dados e retornar o ID usando transacao
        /// Sera devolvido o id da operacao
        /// </summary>
        /// <typeparam name="T">Entidade que sera usada como retorno</typeparam>
        /// <param name="ConnectionDB">Tipo da conexao</param>
        /// <param name="tipoComando">Tipo do comando</param>
        /// <param name="storedProcedure">Nome do comando</param>
        /// <param name="parameters">Parametros</param>
        /// <returns></returns>
        public object ExecuteScalarTransacrion(CommandType tipoComando, string storedProcedure, params DbParameter[] parameters)
        {
            object oScalar;

            commandTransaction.CommandType = tipoComando;
            commandTransaction.CommandText = storedProcedure;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    commandTransaction.Parameters.Add(parameter);
            }

            try
            {
                oScalar = commandTransaction.ExecuteScalar();
            }
            catch (SqlException sqlEx)
            {
                oScalar = 0;
                if (sqlEx.Number == Convert.ToInt32(EnumErroSQL.Constraint))
                {
                    //throw new ApplicationException("Não foi possível excluir esse registro, pois ele já está sendo utilizada no sistema.");
                    throw new ApplicationException(@"O sistema encontrou um problema ao executar a ação solicitada:</br></br>
                                                    1. O registro não pode ser excluído pois está sendo utilizado no sistema.</br>
                                                    2. Uma das informações foi excluída recentemente. (Por favor, atualize a página)");
                }

                throw new System.Exception(sqlEx.Message, sqlEx.InnerException);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                commandTransaction.Parameters.Clear();
            }

            return oScalar;
        }

        /// <summary>
        /// Metodo responsavel por efetuar o commit da transacao
        /// </summary>
        public void CommitTransaction()
        {
            commandTransaction.Transaction.Commit();
            commandTransaction.Dispose();
            contextTransaction.Connection.Close();
            contextTransaction.Dispose();

        }

        /// <summary>
        /// Metodo responsavel por efetuar o rollback da transacao
        /// </summary>
        public void RollbackTransaction()
        {
            commandTransaction.Transaction.Rollback();
            commandTransaction.Dispose();
            contextTransaction.Connection.Close();
            contextTransaction.Dispose();
        }
        #endregion



        #endregion

        #region Parameter
        /// <summary>
        /// Metodo responsavel por inserir os parametros para as querys 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Objeto">O objeto a ser inserido na base de dados </param>
        /// <param name="ObjEnumDataAccessMetodo"> 
        /// O tipo do metodo de entrada:
        /// Quando for insert os compos com o IsDbGenerated nao seram passado como parametro vão ser tratados como Identity.
        /// Quando for delete apenas os campos com IsPrimaryKey seram passados como parametro.
        /// Quando Update e Get seram passados todos os parametros.
        /// </param>
        /// <returns></returns>
        public List<DbParameter> GetDbParameter<T>(T Objeto, EnumDataAccessMetodo ObjEnumDataAccessMetodo)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();

            foreach (var itemProperties in Objeto.GetType().GetProperties())
            {
                foreach (var itemAttributes in itemProperties.GetCustomAttributes(typeof(ColumnAttribute), false))
                {

                    bool pExcluirParametro = false;
                    foreach (var itemCustomAttributes in itemProperties.GetCustomAttributes(typeof(CustomAttributesParameter), false))
                        pExcluirParametro = (bool)((dynamic)itemCustomAttributes).ExcluirParametro;

                    var Value = itemProperties.GetValue(Objeto, null);

                    //quando for insert e o coampo for IDENTITY
                    if (ObjEnumDataAccessMetodo == EnumDataAccessMetodo.Insert)
                    {
                        if (!pExcluirParametro && !(bool)((dynamic)itemAttributes).IsDbGenerated)
                            listaParametros.Add(CarregarDbParameter(Value, factory, itemProperties));
                    }
                    else if (ObjEnumDataAccessMetodo == EnumDataAccessMetodo.Delete)
                    {
                        if (!pExcluirParametro && (bool)((dynamic)itemAttributes).IsPrimaryKey)
                            listaParametros.Add(CarregarDbParameter(Value, factory, itemProperties));
                    }
                    else if (!pExcluirParametro)
                    {
                        listaParametros.Add(CarregarDbParameter(Value, factory, itemProperties));
                    }
                }
            }

            return listaParametros;
        }

        private DbParameter CarregarDbParameter(object Value, DbProviderFactory factory, PropertyInfo itemProperties)
        {
            DbParameter parametro = null;

            bool pExcluirParametro = false;
            foreach (var itemCustomAttributes in itemProperties.GetCustomAttributes(typeof(CustomAttributesParameter), false))
                pExcluirParametro = (bool)((dynamic)itemCustomAttributes).ExcluirParametro;

            if (!pExcluirParametro)
            {
                parametro = factory.CreateParameter();
                parametro.ParameterName = "@" + ((System.Reflection.MemberInfo)(itemProperties)).Name;
                parametro.Value = (Value != null) ? Value : (object)DBNull.Value;
            }

            return parametro;
        }
        #endregion
    }
}
