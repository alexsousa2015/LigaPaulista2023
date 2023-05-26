using System;
using System.Data;
using Formula;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for Categoria
    /// </summary>
    public class Categoria
    {
        public int id_categoria;
        public string categoria;

        public static DataSet carregacategoriasAdm()
        {
            var sql = new Sql
            {
                strSql = "SELECT * FROM categorias ORDER BY CATEGORIA"
            };

            return sql.queryDs();
        }

        public static DataSet carregaCategoriasAdm()
        {
            var sql = new Sql
            {
                strSql = "SELECT * FROM categorias"
            };

            return sql.queryDs();
        }

        public void incluir()
        {
            var sql = new Sql
            {
                strSql = ("INSERT INTO categorias (CATEGORIA) VALUES('" + categoria + "');")
            };
            Utils.logConsole(sql.strSql);

            try
            {
                sql.query();
            }
            catch (Exception e)
            {
                Utils.logConsole(e.Message);
            }
        }

        public void alterar()
        {
            var sql = new Sql
            {
                strSql = ("UPDATE categorias SET CATEGORIA = '" + categoria +
                          "' WHERE ID_CAT = " + id_categoria + ";")
            };
            Utils.logConsole(sql.strSql);

            try
            {
                sql.query();
            }
            catch (Exception e)
            {
                Utils.logConsole(e.Message);
            }
        }

        public bool excluir()
        {
            var sql = new Sql
            {
                strSql = ("SELECT ID_ALBUM FROM ALBUNS WHERE (ID_CAT = " + id_categoria + ");")
            };
            Utils.logConsole(sql.strSql);

            if (Utils.existeDataSet(sql.queryDs()))
                return false;
            else
            {
                sql = new Sql
                {
                    strSql = ("DELETE FROM categorias WHERE (ID_CAT = " + id_categoria + ");")
                };

                try
                {
                    sql.query();
                }
                catch (Exception e)
                {
                    Utils.logConsole(e.Message);
                }

                return true;
            }
        }

        public static Categoria pegaDadosPeloID(int id)
        {
            var sql = new Sql
            {
                strSql = ("select * from categorias where (ID_CAT = " + id + ")")
            };
            DataSet ds = sql.queryDs();

            var cat = new Categoria
            {
                id_categoria = Converter.objToInt(ds.Tables[0].Rows[0].ItemArray[0]),
                categoria = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[1])
            };

            return cat;
        }

        public static string retornaNome(int id)
        {
            var sql = new Sql
            {
                strSql = ("select CATEGORIA from categorias where (ID_CAT = " + id + ")")
            };
            DataSet ds = sql.queryDs();

            string categoria = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[0]);
            return categoria;
        }
    }
}
