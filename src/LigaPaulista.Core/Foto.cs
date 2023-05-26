using System;
using System.Data;
using System.Text;
using Formula;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for Foto
    /// </summary>
    public class Foto
    {
        public int id_foto, id_album;
        public string foto, descricao;

        public void incluir()
        {
            var sb = new StringBuilder();
            sb.Append("INSERT INTO FOTOS (ID_ALBUM,FOTO,DESCRICAO) VALUES(");
            sb.AppendFormat("{0}, 'novas/{0}/{1}', '{2}')", id_album,foto,descricao);

            /*
         * ("INSERT INTO FOTOS ('ID_ALBUM', 'FOTO', 'DESCRICAO') 
         * VALUES(" + id_album + ",'novas/" + id_album + "/" + foto + "','" + descricao + "')")
         * 
         */

            var sql = new Sql
            {
                strSql = sb.ToString()
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
                strSql =
                ("UPDATE FOTOS SET ID_ALBUM = " + id_album + ", FOTO = 'novas/" + id_album +
                 "/" + foto + "', DESCRICAO = '" + descricao + "' WHERE ID_FOTO = " + id_foto + ";")
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
                strSql = ("DELETE FROM FOTOS WHERE ID_FOTO = " + id_foto + ";")
            };

            try
            {
                sql.query();
            }
            catch (Exception e)
            {
                Utils.logConsole(e.Message);
            }
        }

        public static void apagarFoto(int id)
        {
            var sql = new Sql
            {
                strSql = ("SELECT foto FROM FOTOS where id_foto =" + id)
            };

            DataSet ds = sql.queryDs();
            string foto = ds.Tables[0].Rows[0].ItemArray[0].ToString();

            Upload.deletaArquivo(foto, GaleriaFotos.pathFotos);
            //Upload.deletaArquivo(foto, GaleriaFotos.pathThumbs);

            sql = new Sql
            {
                strSql = ("delete from FOTOS where id_foto =" + id)
            };
            sql.query();

            ds.Dispose();
        }

        public static void alterarLegenda(int id, string legenda)
        {
            var sql = new Sql
            {
                strSql = ("UPDATE FOTOS A SET descricao = '" + legenda + "' where id_foto = " + id)
            };
            sql.query();
        }
    }
}
