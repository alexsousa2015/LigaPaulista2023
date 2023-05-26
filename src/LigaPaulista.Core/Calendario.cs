using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Formula;
using Formula.Data;
using Microsoft.SqlServer.Server;

namespace LigaPaulista.Core
{
    public class Calendario

    {
        #region "Propriedades"

        public int IdCalendario { get; set; }
        public int Ano { get; set; }
        public string Temporada { get; set; }
        public string NomeArquivo { get; set; }
        public string GuidArquivo { get; set; }

        #endregion

        #region "Construtor"

        public Calendario() { }

        public Calendario(int id)
        {
            this.IdCalendario = id;
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Cadastrar Calendario
        /// </summary>
        /// <returns></returns>
        public void CadastraCalendario()
        {
            var sb = new StringBuilder();
            sb.Append("Insert into Calendario (Ano, Temporada, NomeArquivo, GuidArquivo)");
            sb.AppendFormat(" values ('{0}','{1}','{2}','{3}')", Ano, Temporada, NomeArquivo, GuidArquivo);

            var sql = new Sql
            {
                strSql = sb.ToString()
            };
            sql.query();
        }

        /// <summary>
        /// Altera Calendario
        /// </summary>
        public void AlteraCalendario()
        {
            var sb = new StringBuilder();
            sb.Append("Update Calendario ");
            sb.AppendFormat("set Ano = '{0}',Temporada = '{1}', NomeArquivo = '{2}', " +
                            "GuidArquivo='{3}'  where id_Calendario = {4}", Ano, Temporada, NomeArquivo, GuidArquivo, IdCalendario);

            var sql = new Sql
            {
                strSql = sb.ToString()
            };
            sql.query();
        }

        /// <summary>
        /// Retorna todas as Calendario
        /// </summary>
        /// <returns></returns>
        public static DataSet RetornaTodosCalendarios()
        {
            var sql = new Sql
            {
                strSql = "Select id_Calendario,Ano, Temporada, NomeArquivo, " +
                                       "GuidArquivo from Calendario"
            };

            return sql.queryDs();
        }


        public DataSet RetornaCalendario(int id)
        {
            var sql = new Sql
            {
                strSql = "Select id_Calendario, Ano, Temporada, NomeArquivo, GuidArquivo " +
                         "from Calendario where id_Calendario = " + id
            };

            return sql.queryDs();
        }

        /// <summary>
        /// Retorna Calendario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Calendario GetCalendarioById(int id)
        {
            Calendario objCalendario = null;

            var sql = new Sql
            {
                strSql = "Select id_Calendario, Ano, Temporada, NomeArquivo, GuidArquivo " +
                         "from Calendario where id_Calendario = " + id
            };

            var ds = sql.queryDs();
            if (Utils.existeDataSet(ds))
            {
                var drCalendario = ds.Tables[0].Rows[0];

                objCalendario = new Calendario()
                {
                    IdCalendario = Convert.ToInt32(drCalendario["id_Calendario"]),
                    Ano = Convert.ToInt32(drCalendario["Ano"]),
                    Temporada = Convert.ToString(drCalendario["Temporada"]),
                    NomeArquivo = Convert.ToString(drCalendario["NomeArquivo"]),
                    GuidArquivo = Convert.ToString(drCalendario["GuidArquivo"])
                };
            }
            return objCalendario;
        }

        #endregion
    }
}