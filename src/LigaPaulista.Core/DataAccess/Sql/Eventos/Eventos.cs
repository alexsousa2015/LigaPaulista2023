namespace LigaPaulista.Core.DataAccess.Sql.Eventos
{
    public class Eventos
    {
        public static string GetEventos()
        {
            return @"SELECT E.*
	                    , ANDAMENTO = (SELECT count(IDEVENTO)
					                    FROM EVENTOS_INSCRICOES
					                    WHERE IDCADASTRO = @IDCADASTRO
						                    AND IDEVENTO = E.IDEVENTO
						                    AND STATUS IN (1, 2, 4))
	                    , APROVADO = (SELECT count(IDEVENTO)
					                    FROM EVENTOS_INSCRICOES
					                    WHERE IDCADASTRO = @IDCADASTRO
						                    AND IDEVENTO = E.IDEVENTO
						                    AND STATUS IN (3))
	                    , CANCELADO = (SELECT count(IDEVENTO)
					                    FROM EVENTOS_INSCRICOES
					                    WHERE IDCADASTRO = @IDCADASTRO
						                    AND IDEVENTO = E.IDEVENTO
						                    AND STATUS IN (5))
                    FROM EVENTOS E
                    ORDER BY DATAINICIO";
        }

        public static string GetEvento()
        {
            return @"SELECT * FROM EVENTOS WHERE IDEVENTO = @IDEVENTO";
        }
    }
}
