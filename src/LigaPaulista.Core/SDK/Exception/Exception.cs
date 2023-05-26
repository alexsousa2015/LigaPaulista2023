using System.Diagnostics;

namespace LigaPaulista.Core.SDK.Exception
{
    public enum EnumErroSQL
    {
        Constraint = 547
    }

    public static class Exception 
    {
        /// <summary>
        /// Metodo responsavel por criar um grupo no event viewr para ser o agrupador dos erros
        /// </summary>
        /// <param name="Source">Nome da categoria : Niplan - MyVillage</param>
        /// <param name="appName">Nome da Aplicação: Orcamento, Custo, Materiais</param>
        /// <param name="machineName">Nome da maquina onde sera criado a categoria</param>
        private static void CriarCategoriaEventViewr(string LogName, string appName, string machineName) {
            System.Diagnostics.EventSourceCreationData sourceData = new EventSourceCreationData(appName, LogName);
            sourceData.MachineName = machineName;

            System.Diagnostics.EventLog.CreateEventSource(sourceData);
        }

        /// <summary>
        /// Metodo responsavel por escrever no event viewr
        /// </summary>
        /// <param name="machineName">Nome da maquina que sera escrito</param>
        /// <param name="tipoEvento">Tipo do Evento: Erro, Informacao etc..</param>
        /// <param name="Message">MenMyVillageem de erro</param>
        public static void RegistrarEventViewr(EventLogEntryType tipoEvento, string Message) {

            string sLogName = string.Empty;
            string sAppName = string.Empty;
            string sMachineName = string.Empty;

            sLogName = System.Configuration.ConfigurationManager.AppSettings["NMGrupoEventViewr"].ToString();
            sAppName = System.Configuration.ConfigurationManager.AppSettings["NMSistemaEventViewr"].ToString();
            sMachineName = System.Configuration.ConfigurationManager.AppSettings["ServiceMachineName"].ToString();

            if (!(EventLog.SourceExists(sLogName, sMachineName)))
            {
                CriarCategoriaEventViewr(sLogName, sAppName, sMachineName);
            }

            EventLog.WriteEntry(sAppName, Message, tipoEvento);
        
        }

    }
}
