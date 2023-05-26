namespace LigaPaulista.Core.DataAccess.Sql.Campeonatos
{
    public class Artilharia
    {
        public static string GetTop5ArtilheirosDoAno()
        {
            return @"SELECT TOP 5
	                    A.ID_ARTILHEIRO,
	                    A.ID_CATEGORIA,
	                    A.ID_ENTIDADE,
	                    A.NOME,
	                    A.GOLS
                    FROM ARTILHEIROS A
	                    JOIN ARTILHEIROS_CATEGORIAS C ON C.ID_CATEGORIA = A.ID_CATEGORIA
	                    JOIN PERIODOS P ON P.ID_PERIODO = C.ID_PERIODO
                    WHERE (P.ANO = @ANO) AND (C.CATEGORIA LIKE @Modalidade) 
                    ORDER BY A.GOLS  DESC";
        }

        public class Categorias
        {
            public static string GetCategoria()
            {
                return @"SELECT ID_PERIODO, ID_CATEGORIA, CATEGORIA
                                FROM ARTILHEIROS_CATEGORIAS
                            WHERE ID_CATEGORIA = @ID_CATEGORIA";
            }
        }
    }
}
