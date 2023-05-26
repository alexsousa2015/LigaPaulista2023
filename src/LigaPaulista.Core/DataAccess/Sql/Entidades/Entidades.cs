namespace LigaPaulista.Core.DataAccess.Sql.Entidades
{
    public class Entidades
    {
        public static string GetEntidade()
        {
            return @"select * from dbo.ENTIDADES
                        where ID_ENTIDADE = @IdEntidade
	                        and SENHA = @Senha
	                        and ([EMAILLEGAL] = @Email OR
                                    [EMAIL1] = @Email OR
                                    [EMAIL2] = @Email OR
                                    [EMAIL3] = @Email)";
        }
    }
}
