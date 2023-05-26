using System.Collections.Generic;

namespace LigaPaulista.Core.Business.Eventos
{
    public sealed class Eventos
    {
        public List<Objects.Eventos.Eventos> GetEventos(int IdCadastro)
        {
            return new DataAccess.Eventos.Eventos().GetEventos(IdCadastro);
        }

        public Objects.Eventos.Eventos GetEvento(Objects.Eventos.Eventos entity)
        {
            return new DataAccess.Eventos.Eventos().GetEvento(entity);
        }

    }
}
