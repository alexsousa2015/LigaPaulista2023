namespace LigaPaulista.Core.DataAccess.Sql.Campeonatos
{
    public class Campeonatos
    {
        public static string GetCampeonato()
        {
            return @"SELECT ID_CAMPEONATO, ID_MODALIDADE, CAM_ID_CAMPEONATO, NOME, DATA
                                FROM CAMPEONATOS
                            WHERE ID_CAMPEONATO = @ID_CAMPEONATO";
        }
    }
}
