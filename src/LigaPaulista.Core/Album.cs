using System;
using System.Data;
using Formula;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for Album
    /// </summary>
    public class Album
    {
        public int id_album, id_categoria;
        public string album, descricao, capa, ordem, ano;

        public void incluir()
        {
            var sql = new Sql
            {
                strSql = ("INSERT INTO ALBUM (ID_CAT, ALBUM, DESCRICAO,ORDEM,ANO,DELETA ) VALUES(" +
                          id_categoria + ",'" + album + "','" + descricao + "'," + ordem + "," + ano + ",0);")
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
                strSql = ("UPDATE ALBUM SET ID_CAT = " + id_categoria + ", ALBUM = '" + album +
                          "', DESCRICAO = '" + descricao + "', ORDEM = " + ordem + ", ANO=" + ano +
                          "  WHERE (ALBUM.[ID_ALBUM]=" + id_album + ") ;")
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

        public void excluir()
        {
            var sql = new Sql
            {
                strSql = ("DELETE FROM FOTOS WHERE ID_ALBUM = " + id_album + ";")
            };

            try
            {
                sql.query();
            }
            catch (Exception e)
            {
                Utils.logConsole(e.Message);
            }

            sql = new Sql
            {
                strSql = ("DELETE FROM ALBUM WHERE ID_ALBUM = " + id_album + ";")
            };

            try
            {
                sql.query();
            }
            catch (Exception)
            {
                //Utils.logConsole(e.Message);
            }
        }

        public static Album pegaDadosPeloID(int id)
        {
            var sql = new Sql
            {
                strSql = ("select id_album,id_cat,album,descricao,ordem,ano from ALBUM WHERE id_album = " + id)
            };
            DataSet ds = sql.queryDs();

            var alb = new Album
            {
                id_album = Converter.objToInt(ds.Tables[0].Rows[0].ItemArray[0]),
                id_categoria = Converter.objToInt(ds.Tables[0].Rows[0].ItemArray[1]),
                album = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[2]),
                descricao = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[3]),
                ordem = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[4]),
                ano = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[5])
            };
            //alb.capa = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[4]);

            return alb;
        }


        public static DataSet preencheFotos(int id)
        {
            var sql = new Sql
            {
                strSql = ("Select * from FOTOS WHERE (id_album = " + id + ")")
            };

            DataSet ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
                return ds;

            return null;
        }

        public static Album pegaDadosPeloTitulo(string album, string desc)
        {
            var sql = new Sql
            {
                //strSql = ("select id_album,id_cat,album,descricao,ordem,ano from ALBUM WHERE ALBUM = '" + album + "' and DESCRICAO = '" + desc + "'")
                strSql = "select id_album,id_cat,album,descricao,ordem,ano from ALBUM WHERE ALBUM = '" + album + "' and PatIndex('" + desc + "',DESCRICAO) > 0"
            };
            var ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
            {
                var alb = new Album
                {
                    id_album = Converter.objToInt(ds.Tables[0].Rows[0].ItemArray[0]),
                    id_categoria = Converter.objToInt(ds.Tables[0].Rows[0].ItemArray[1]),
                    album = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[2]),
                    descricao = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[3]),
                    ordem = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[4]),
                    ano = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[5])
                };
                //alb.capa = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[4]);

                return alb;
            }
            return new Album();
        }

        public static DataSet carregaAlbum(int id_categoria)
        {
            var sql = new Sql
            {
                strSql =
                ("SELECT * FROM ALBUM A WHERE A.id_album in (SELECT id_album FROM FOTOS) and ID_CAT = " +
                 id_categoria)
            };

            return sql.queryDs();
        }

        public static void apagarAlbumFotos(int id)
        {
            var sql = new Sql
            {
                strSql = ("select id_foto from FOTOS where id_album = " + id)
            };
            DataSet ds = sql.queryDs();

            foreach (DataRow dr in ds.Tables[0].Rows)
                Foto.apagarFoto(Convert.ToInt32(dr.ItemArray[0]));

            sql = new Sql
            {
                strSql = ("delete from ALBUM where id_album =" + id)
            };
            sql.query();

            ds.Dispose();
        }

        public static DataSet preencheAnosAlbuns()
        {
            var sql = new Sql
            {
                strSql = "select Distinct(ANO) from ALBUM order by ANO desc"
            };

            return sql.queryDs();
        }

        public static bool verificaAno(int ano)
        {
            var sql = new Sql
            {
                strSql = "Select * from ALBUM where ANO=" + ano
            };

            return Utils.existeDataSet(sql.queryDs());
        }
    }
}
