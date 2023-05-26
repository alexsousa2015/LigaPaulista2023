namespace LigaPaulista.Core.DataAccess.Sql.Campeonatos
{
    public class Periodos
    {
        public static string GetPeriodo()
        {
            return @"SELECT ID_PERIODO, PERIODO, ANO
                                FROM PERIODOS
                            WHERE ID_PERIODO = @ID_PERIODO";
        }
    }
}
