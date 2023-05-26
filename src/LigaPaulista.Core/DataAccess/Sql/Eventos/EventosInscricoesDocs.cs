namespace LigaPaulista.Core.DataAccess.Sql.Eventos
{
    public class EventosInscricoesDocs
    {
        public static string GetEventosInscricoesDocs()
        {
            return @"SELECT * FROM EVENTOS_INSCRICOES_DOCS WHERE IDINSCRICAO = @IDINSCRICAO";
        }

        public static string InserirDoc()
        {
            return @"INSERT INTO EVENTOS_INSCRICOES_DOCS(IDINSCRICAO, IDEVENTODOC, ARQUIVO, DATAHORA, STATUS)
                        VALUES(@IDINSCRICAO, @IDEVENTODOC, @ARQUIVO, GETDATE(), @STATUS);

                     SELECT * FROM EVENTOS_INSCRICOES_DOCS WHERE IDDOC = @@IDENTITY";

        }
    }
}
