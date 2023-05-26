using System.Collections.Generic;
using System.Linq;

namespace LigaPaulista.Core.Business.Eventos
{
    public sealed class EventosDocs
    {
        public List<Objects.Eventos.EventosDocs> GetEventosDocs(Objects.Eventos.Eventos entity)
        {
            return new DataAccess.Eventos.EventosDocs().GetEventosDocs(entity);
        }
    }
}
