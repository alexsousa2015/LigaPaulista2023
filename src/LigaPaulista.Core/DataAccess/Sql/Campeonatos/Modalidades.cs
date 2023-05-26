namespace LigaPaulista.Core.DataAccess.Sql.Campeonatos
{
    public class Modalidades
    {
        public static string GetModalidade()
        {
            return @"SELECT ID_MODALIDADE, MODALIDADE, IMAGEM
                                FROM MODALIDADES
                            WHERE ID_MODALIDADE = @ID_MODALIDADE";
        }
    }
}
