using System.Collections.Generic;

namespace LigaPaulista.Core.Business.Eventos
{
    public sealed class EventosInscricoesDocs
    {
        public List<Objects.Eventos.EventosInscricoesDocs> GetEventosInscricoesDocs(Objects.Eventos.EventosInscricoes entity)
        {
            return new DataAccess.Eventos.EventosInscricoesDocs().GetEventosInscricoesDocs(entity);
        }

        public Objects.Eventos.EventosInscricoesDocs InserirDoc(Objects.Eventos.EventosInscricoesDocs entity)
        {
            return new DataAccess.Eventos.EventosInscricoesDocs().InserirDoc(entity);
        }
    }
}
