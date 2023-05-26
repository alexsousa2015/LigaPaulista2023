using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Entidades
{
    public sealed class Entidades
    {
        public Objects.Entidades.Entidades GetEntidade(Objects.Entidades.Entidades entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IdEntidade";
            parametro.Value = entity.IdEntidade;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@Email";
            parametro.Value = entity.Email;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@Senha";
            parametro.Value = entity.Senha;
            listaParametros.Add(parametro);

            string SQL = Sql.Entidades.Entidades.GetEntidade();
            Objects.Entidades.Entidades item;

            if (baseDataAccess == null)
                item = new BaseDataAccess().ExecuteReader<Objects.Entidades.Entidades>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
            else
                item = baseDataAccess.ExecuteReaderTransacrion<Objects.Entidades.Entidades>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

            return item;
        }
    }
}
