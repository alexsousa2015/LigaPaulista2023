namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for Conexoes
    /// </summary>
    public class Conexoes
    {
        //public const string strConexaoGaleria = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = c:\Inetpub\wwwroot\ligaPaulista\App_Data\galeria.mdb;Persist Security Info=False";
        //public const string strConexaoCadastro = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = c:\Inetpub\wwwroot\ligaPaulista\App_Data\cadastros.mdb;Persist Security Info=False";
        //public const string strConexaoBanco = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = c:\Inetpub\wwwroot\ligaPaulista\App_Data\banco.mdb;Persist Security Info=False";

        //public const string strConexaoGaleria = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = e:\home\ligaabc\web\ligapaulista\App_Data\galeria.mdb;Persist Security Info=False";
        //public static readonly string strConexaoCadastro = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + HttpContext.Current.Server.MapPath("~/App_Data/banco.mdb")+";Persist Security Info=False";
        //public static readonly string strConexaoAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + HttpContext.Current.Server.MapPath("~/App_Data/banco.mdb") + ";Persist Security Info=False";
        public static readonly string strConexaoSql =
            "Persist Security Info=False;User ID=ligaabc; Password=lp2080;Data Source=187.45.196.5";

        //public const string strConexaoGaleria = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = d:\webserver\ligapaulista\App_Data\galeria.mdb;Persist Security Info=False";
        //public const string strConexaoCadastro = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = d:\webserver\ligapaulista\App_Data\banco.mdb;Persist Security Info=False";
        //public const string strConexaoAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = D:\WebServer\ligapaulista\LigaPaulista.Site\App_Data\banco.mdb;Persist Security Info=False";

        public Conexoes()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
