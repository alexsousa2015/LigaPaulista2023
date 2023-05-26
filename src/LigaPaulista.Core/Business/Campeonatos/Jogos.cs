using System.Collections.Generic;
using System.Linq;

namespace LigaPaulista.Core.Business.Campeonatos
{
    public sealed class Jogos
    {
        public Objects.Campeonatos.Jogos ListarProximo(bool CarregarDependencias)
        {
            return new DataAccess.Campeonatos.Jogos().ListarProximo(new Objects.Campeonatos.Jogos(), CarregarDependencias);
        }

    }
}
