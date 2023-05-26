namespace LigaPaulista.Core.DataAccess.Sql.Campeonatos
{
    public class Entidades
    {
        public static string GetEntidade()
        {
            return @"SELECT ID_ENTIDADE, ENTIDADE
                                FROM ENTIDADES
                            WHERE ID_ENTIDADE = @ID_ENTIDADE";
        }

        public static string GetEntidadesDoGrupo()
        {
            return @"SELECT E.ID_ENTIDADE, E.ENTIDADE
                                FROM ENTIDADES E
                                    JOIN GRUPOS_ENTIDADES GE ON GE.ID_ENTIDADE = E.ID_ENTIDADE
                            WHERE G.ID_GRUPO = @ID_GRUPO";
        }
    }
}
