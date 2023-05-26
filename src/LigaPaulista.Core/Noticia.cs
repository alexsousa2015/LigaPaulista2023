using System;
using System.Data;
using System.Text;
using Formula;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for Noticia
    /// </summary>
    public class Noticia
    {
        public int id_noticia;
        public DateTime data;
        public string titulo;
        public string descricao;
        public string foto;
        public string arquivo;
        public string link;
        public bool deleta;
        public int tipo;

        public static class Session
        {
            public const string noticia = "noticia";
        }

        public static Noticia pegaDadosPeloID(int idNot)
        {
            var sql = new Sql
            {
                strSql = ("Select * from tbl_noticias where id_noticia = " + idNot)
            };
            var ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
            {
                var not = new Noticia();

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    not.id_noticia = idNot;
                    not.data = Convert.ToDateTime(dr.ItemArray[1]);
                    not.titulo = dr.ItemArray[2].ToString();
                    not.descricao = dr.ItemArray[3].ToString();
                    not.foto = dr.ItemArray[4].ToString();
                    not.arquivo = dr.ItemArray[5].ToString();
                    not.link = dr.ItemArray[6].ToString();
                    not.deleta = Convert.ToBoolean(dr.ItemArray[7]);
                    not.tipo = Convert.ToInt32(dr.ItemArray[8]);
                }
                return not;
            }
            return new Noticia();
        }

        public static DataSet listaNoticiasDS()
        {
            var sql = new Sql
            {
                strSql = ("Select * from tbl_noticias " +
                          " where tipo = 1 " +
                          " and deleta = 0" +
                          " order by data desc")
            };
            return sql.queryDs();
        }

        public static DataSet listaNoticiasTop7DS()
        {
            var sql = new Sql
            {
                strSql = ("Select top 7 * from tbl_noticias " +
                          " where tipo = 1 " +
                          " and deleta = 0" +
                          " order by data desc")
            };
            return sql.queryDs();
        }

        public static Noticia pegaUltimaNoticia()
        {
            var sql = new Sql
            {
                strSql = ("Select top 1 id_noticia from tbl_noticias " +
                          " where tipo = 1 " +
                          " and deleta = 0" +
                          " order by data desc")
            };
            return pegaDadosPeloID(sql.queryID());
        }

        public static DataSet listaBaladasDS()
        {
            var sql = new Sql
            {
                strSql = ("Select * from tbl_noticias " +
                          " where tipo = 2 " +
                          " and deleta = 0" +
                          " order by data desc")
            };
            return sql.queryDs();
        }

        public static Noticia pegaUltimaBalada()
        {
            var sql = new Sql
            {
                strSql = ("Select top 1 id_noticia from tbl_noticias " +
                          " where tipo = 2 " +
                          " and deleta = 0" +
                          " order by data desc")
            };
            return pegaDadosPeloID(sql.queryID());
        }

        public static DataSet BuscaNoticia(string arg)
        {
            Utils.SqlInjectionPrevent(arg);
            var sb = new StringBuilder();
            sb.Append("Select * from tbl_noticias where ");
            sb.AppendFormat("Titulo Like '%{0}%' or Descricao Like '%{0}%'", arg);

            var sql = new Sql
            {
                StringSql = sb.ToString()
            };

            return Utils.existeDataSet(sql.queryDs()) ? sql.queryDs() : null;
        }
    }
}
