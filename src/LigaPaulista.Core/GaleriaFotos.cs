using System.Data;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for GaleriaFotos
    /// </summary>
    public class GaleriaFotos
    {
        public Categoria _categoria;
        public Album _album;
        public Foto _foto;

        /*
    //e:\home\ligaabc\web\album\fotos\
    public static readonly string pathFotos = HttpContext.Current.Server.MapPath("~/album/fotos/novas/");
    public static readonly string pathCapa = HttpContext.Current.Server.MapPath("~/album/capa/");
    public static readonly string pathThumbs = HttpContext.Current.Server.MapPath("~/album/fotos/thumbs/");
    public static readonly string pathTemp = HttpContext.Current.Server.MapPath("~/album/fotos/");
    */

        //public static readonly string pathTemp = HttpContext.Current.Server.MapPath(@"../web/album/fotos/temp/");
        //public static readonly string pathCapa = HttpContext.Current.Server.MapPath(@"../web/album/fotos/capa/");
        //public static readonly string pathThumbs = HttpContext.Current.Server.MapPath(@"../web/album/fotos/thumbs/");
        //public static readonly string pathFotos = HttpContext.Current.Server.MapPath(@"../web/album/fotos/novas/");

        public static readonly string pathTemp = @"e:\home\ligaabc\web\album\fotos\temp\";
        public static readonly string pathCapa = @"e:\home\ligaabc\web\album\fotos\capa\";
        public static readonly string pathThumbs = @"e:\home\ligaabc\web\album\fotos\thumbs\";
        public static readonly string pathFotos = @"e:\home\ligaabc\web\album\fotos\novas\";

        //public static readonly string pathTemp   = @"c:\dev\ligapaulista\album\fotos\temp\";
        //public static readonly string pathCapa   = @"c:\dev\ligapaulista\album\fotos\capa\";
        //public static readonly string pathThumbs = @"c:\dev\ligapaulista\album\fotos\thumbs\";
        //public static readonly string pathFotos  = @"c:\dev\ligapaulista\album\fotos\novas\";


        public static class Session
        {
            public const string album = "album";
            public const string imgCapa = "imgCapa";
        }

        public static DataSet mostrarAlbumDestaque()
        {
            var sql = new Sql
            {
                strSql = ("SELECT A.ID_ALBUM, A.FOTO, T.TITULO FROM (FOTOS A " +
                          "INNER JOIN ALBUM T on T.ID_ALBUM = A.ID_ALBUM) " +
                          "order by rand() limit 1;")
            };
            //"select A.ID_ALBUM, A.TITULO, A.CAPA from ALBUNS A where ID_ALBUM in (select ID_ALBUM from ALBUNS_FOTOS) order by rand() limit 1";
            //"select A.TITULO, F.FOTO from ALBUNS A inner join ALBUNS_FOTOS F on F.ID_ALBUM = A.ID_ALBUM order by rand() limit 1";

            return sql.queryDs();
        }

        public static DataSet listarFotos(int id)
        {
            var sql = new Sql
            {
                strSql =
                ("SELECT F.*, C.id_cat, C.categoria, A.album, A.descricao as tit_desc FROM ((FOTOS F " +
                 "INNER JOIN ALBUM A ON A.id_album = F.id_album) " +
                 "INNER JOIN CATEGORIAS C ON A.id_cat = C.id_cat) " +
                 "WHERE (F.id_album = " + id + ")")
                /** A string sql está com parênteses () após o FROM e após o WHERE por limitações do Access
             *       Se tirar os parênteses occorerá um erro de falta de parâmetros, caso o banco seja Access
             */
            };
            return sql.queryDs();
        }
    }
}
