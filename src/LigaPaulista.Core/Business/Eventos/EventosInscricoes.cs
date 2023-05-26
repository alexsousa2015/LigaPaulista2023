using System.Collections.Generic;

namespace LigaPaulista.Core.Business.Eventos
{
    public sealed class EventosInscricoes
    {
        public int EstaInscrito(Objects.Eventos.EventosInscricoes entity)
        {
            return new DataAccess.Eventos.EventosInscricoes().EstaInscrito(entity);
        }

        public List<Objects.Eventos.EventosInscricoes> PegarInscricoes(Objects.Eventos.EventosInscricoes entity)
        {
            return new DataAccess.Eventos.EventosInscricoes().PegarInscricoes(entity);
        }

        public Objects.Eventos.EventosInscricoes Inscrever(Objects.Eventos.EventosInscricoes entity)
        {
            new DataAccess.Eventos.EventosInscricoes().InativarAnteriores(entity);

            return new DataAccess.Eventos.EventosInscricoes().Inscrever(entity);
        }

        public Objects.Eventos.EventosInscricoes Atualizar(Objects.Eventos.EventosInscricoes entity)
        {
            return new DataAccess.Eventos.EventosInscricoes().Atualizar(entity);
        }



    }
}
