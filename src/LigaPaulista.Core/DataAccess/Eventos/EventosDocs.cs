using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Eventos
{
    public sealed class EventosDocs
    {
        public List<Objects.Eventos.EventosDocs> GetEventosDocs(Objects.Eventos.Eventos entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IdEvento";
            parametro.Value = entity.IdEvento;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.EventosDocs.GetEventosDocs();
            List<Objects.Eventos.EventosDocs> list;

            if (baseDataAccess == null)
                list = new BaseDataAccess().ExecuteReader<Objects.Eventos.EventosDocs>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();
            else
                list = baseDataAccess.ExecuteReaderTransacrion<Objects.Eventos.EventosDocs>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();

            return list;
        }
    }
}
