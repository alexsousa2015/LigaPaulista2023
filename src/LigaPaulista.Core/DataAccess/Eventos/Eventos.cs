using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Eventos
{
    public sealed class Eventos
    {
        public List<Objects.Eventos.Eventos> GetEventos(int IdCadastro, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IDCADASTRO";
            parametro.Value = IdCadastro;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.Eventos.GetEventos();
            List<Objects.Eventos.Eventos> list;

            if (baseDataAccess == null)
                list = new BaseDataAccess().ExecuteReader<Objects.Eventos.Eventos>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();
            else
                list = baseDataAccess.ExecuteReaderTransacrion<Objects.Eventos.Eventos>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();

            foreach (var item in list)
            {
                item.Docs = new Business.Eventos.EventosDocs().GetEventosDocs(item);
            }
            return list;
        }

        public Objects.Eventos.Eventos GetEvento(Objects.Eventos.Eventos entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IdEvento";
            parametro.Value = entity.IdEvento;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.Eventos.GetEvento();
            Objects.Eventos.Eventos item;

            if (baseDataAccess == null)
                item = new BaseDataAccess().ExecuteReader<Objects.Eventos.Eventos>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
            else
                item = baseDataAccess.ExecuteReaderTransacrion<Objects.Eventos.Eventos>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

            item.Docs = new Business.Eventos.EventosDocs().GetEventosDocs(item);

            return item;
        }
    }
}
