namespace LigaPaulista.Core.DataAccess.Sql.Eventos
{
    public class EventosDocs
    {
        public static string GetEventosDocs()
        {
            return @"SELECT * FROM EVENTOS_DOCS WHERE IDEVENTO = @IDEVENTO";
        }
    }
}
