namespace LigaPaulista.Core.DataAccess.Sql.Eventos
{
    public class EventosInscricoes
    {
        public static string EstaInscrito()
        {
            return @"SELECT * FROM EVENTOS_INSCRICOES
                        WHERE IDCADASTRO = @IDCADASTRO AND IDEVENTO = @IDEVENTO";
        }

        public static string PegarInscricoes()
        {
            return @"SELECT * FROM EVENTOS_INSCRICOES
                        WHERE IDCADASTRO = @IDCADASTRO 
                        AND (ISNULL(IDEVENTO, 0) = @IDEVENTO OR @IDEVENTO = 0)
                        AND (ISNULL(ANO, 0) = @ANO OR @ANO = 0)
                        AND (ISNULL(ATIVO, 0) = @ATIVO OR @ATIVO = 0) ";
        }

        public static string Inscrever()
        {
            return @"INSERT INTO EVENTOS_INSCRICOES (IDEVENTO, IDCADASTRO, DATACADASTRO, STATUS, ANO, ATIVO)
                        VALUES(@IDEVENTO, @IDCADASTRO, GETDATE(), @STATUS, @ANO, @ATIVO);

                     SELECT * FROM EVENTOS_INSCRICOES WHERE IDINSCRICAO = @@IDENTITY;";
        }

        public static string InativarAnteriores()
        {
            return @"update EVENTOS_INSCRICOES 
                        set ATIVO = 0 
                     where IDCADASTRO = @IDCADASTRO and IDEVENTO = @IDEVENTO and ANO = @ANO and ATIVO = @ATIVO ";
        }

        public static string Atualizar()
        {
            return @"UPDATE EVENTOS_INSCRICOES SET STATUS = @STATUS, CODIGOPGTO = @CODIGOPGTO
                        WHERE IDINSCRICAO = @IDINSCRICAO;

                     SELECT * FROM EVENTOS_INSCRICOES WHERE IDINSCRICAO = @@IDENTITY;";
        }

    }
}
