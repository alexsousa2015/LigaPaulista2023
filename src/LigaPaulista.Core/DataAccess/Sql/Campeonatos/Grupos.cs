namespace LigaPaulista.Core.DataAccess.Sql.Campeonatos
{
    public class Grupos
    {
        public static string GetGrupo()
        {
            return @"SELECT ID_GRUPO, GRUPO
                                FROM GRUPOS
                            WHERE ID_GRUPO = @ID_GRUPO";
        }

        public static string GetGruposDoCampeonato()
        {
            return @"SELECT G.ID_GRUPO, G.GRUPO
                                FROM GRUPOS G
                                JOIN GRUPO_CAMPEONATO GC ON GC.ID_GRUPO = G.ID_GRUPO
                            WHERE GC.ID_CAMPEONATO = @ID_CAMPEONATO";
        }
    }
}
