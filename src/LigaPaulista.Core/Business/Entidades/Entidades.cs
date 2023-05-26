namespace LigaPaulista.Core.Business.Entidades
{
    public sealed class Entidades
    {
        public Objects.Entidades.Entidades GetEntidade(Objects.Entidades.Entidades Entidade)
        {
            return new DataAccess.Entidades.Entidades().GetEntidade(Entidade);
        }
    }
}
