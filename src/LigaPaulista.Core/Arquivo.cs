using System;
using System.Data;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for Arquivo
    /// </summary>
    public class Arquivo
    {
        public int id_arquivo;
        public string nome;
        public string arquivo;
        public int id_tipo;
        public DateTime data;

        public Arquivo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataSet listaInformativosDs()
        {
            var sql = new Sql
            {
                strSql = ("Select * from tbl_arquivo " +
                          " where id_tipo = 1 order by data desc")
            };
            return sql.queryDs();
        }

        public static DataSet listaOficiaisDs()
        {
            var sql = new Sql
            {
                strSql = ("Select * from tbl_arquivo " +
                          " where id_tipo = 2 ")
            };
            return sql.queryDs();
        }

        public static DataSet listaRegulamentosDs()
        {
            var sql = new Sql
            {
                strSql = ("Select * from tbl_arquivo " +
                          " where id_tipo = 3 ")
            };
            return sql.queryDs();
        }

        public static DataSet listaOutrosDs()
        {
            var sql = new Sql
            {
                strSql = ("Select * from tbl_arquivo " +
                          " where id_tipo = 4 ")
            };
            return sql.queryDs();
        }
    }
}
