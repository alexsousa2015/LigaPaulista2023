using System.Collections.Generic;
using System.Linq;

namespace LigaPaulista.Core.Business.Campeonatos
{
    public sealed class Artilharia
    {
        public List<Objects.Campeonatos.Artilharia> GetTop5ArtilheirosDoAno(string Modalidade, bool CarregarDependencias)
        {
            return new DataAccess.Campeonatos.Artilharia().GetTop5ArtilheirosDoAno(Modalidade, CarregarDependencias).ToList();
        }

    }
}
