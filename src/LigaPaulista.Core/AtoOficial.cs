using System;
using System.Data;
using Formula;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for AtoOficial
    /// </summary>
    public class AtoOficial
    {
        public int id_portaria;
        public DateTime data;
        public int tipo;
        public string titulo;
        public string descricao;
        public string arquivo;
        public bool deleta;


        public static class Session
        {
            public const string ato = "ato";
        }


        public static AtoOficial pegaDadosPeloID(int idPort)
        {
            Sql sql = new Sql();
            sql.strSql = "Select * from tbl_portaria where id_portaria = " + idPort;
            DataSet ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
            {
                AtoOficial ato = new AtoOficial();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ato.id_portaria = idPort;
                    ato.data = Convert.ToDateTime(dr.ItemArray[1]);
                    ato.tipo = Convert.ToInt32(dr.ItemArray[2]);
                    ato.titulo = dr.ItemArray[3].ToString();
                    ato.descricao = dr.ItemArray[4].ToString();
                    ato.arquivo = dr.ItemArray[5].ToString();
                    ato.deleta = Convert.ToBoolean(dr.ItemArray[6]);
                }
                return ato;
            }
            return new AtoOficial();
        }


        public static AtoOficial pegaUltimoAto()
        {
            Sql sql = new Sql();
            sql.strSql = "Select top 1 id_portaria from tbl_portaria " +
                         " where tipo = 1 " +
                         " and [delete] = 0" +
                         " order by data desc";
            return pegaDadosPeloID(sql.queryID());
        }

        public static DataSet listaAtoDS()
        {
            Sql sql = new Sql();
            sql.strSql = "Select * from tbl_portaria where tipo = 1 order by data desc";
            return sql.queryDs();
        }
    }
}
