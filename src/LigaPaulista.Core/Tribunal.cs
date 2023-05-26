using System;
using System.Data;
using Formula;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for Tribunal
    /// </summary>
    public class Tribunal
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
            public const string tribunal = "tribunal";
        }

        public static Tribunal pegaDadosPeloID(int idPort)
        {
            Sql sql = new Sql();
            sql.strSql = "Select * from tbl_portaria where id_portaria = " + idPort;
            DataSet ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
            {
                Tribunal tri = new Tribunal();

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    tri.id_portaria = idPort;
                    tri.data = Convert.ToDateTime(dr.ItemArray[1]);
                    tri.tipo = Convert.ToInt32(dr.ItemArray[2]);
                    tri.titulo = dr.ItemArray[3].ToString();
                    tri.descricao = dr.ItemArray[4].ToString();
                    tri.arquivo = dr.ItemArray[5].ToString();
                    tri.deleta = Convert.ToBoolean(dr.ItemArray[6]);
                }
                return tri;
            }
            return new Tribunal();
        }

        public static Tribunal pegaUltimoTribunal()
        {
            Sql sql = new Sql();
            sql.strSql = "Select top 1 id_portaria from tbl_portaria "+
                         " where tipo = 2 "+
                         " and [delete] = 0"+
                         " order by data desc";
            return pegaDadosPeloID(sql.queryID());
        }

        public static DataSet listaTribunalDS()
        {
            Sql sql = new Sql();
            sql.strSql = "Select * from tbl_portaria where tipo = 2 order by data desc";
            return sql.queryDs();
        }
    }
}
