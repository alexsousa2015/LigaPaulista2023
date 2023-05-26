namespace LigaPaulista.Core.SDK.Exception
{
    public static class Settings
    {
        public static string ServicemachineName
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["ServiceMachineName"].ToString(); }
        }

        public static string NMGrupoEventViewr
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["NMGrupoEventViewr"].ToString(); }
        }

        public static string NMSistemaEventViewr
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["NMSistemaEventViewr"].ToString(); }
        }

    }
}
