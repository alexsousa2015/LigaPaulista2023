using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Eventos
{
    public sealed class EventosInscricoesDocs
    {
        public List<Objects.Eventos.EventosInscricoesDocs> GetEventosInscricoesDocs(Objects.Eventos.EventosInscricoes entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IdInscricao";
            parametro.Value = entity.IdInscricao;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.EventosInscricoesDocs.GetEventosInscricoesDocs();
            List<Objects.Eventos.EventosInscricoesDocs> list;

            if (baseDataAccess == null)
                list = new BaseDataAccess().ExecuteReader<Objects.Eventos.EventosInscricoesDocs>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();
            else
                list = baseDataAccess.ExecuteReaderTransacrion<Objects.Eventos.EventosInscricoesDocs>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();

            return list;
        }

        public Objects.Eventos.EventosInscricoesDocs InserirDoc(Objects.Eventos.EventosInscricoesDocs entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IdInscricao";
            parametro.Value = entity.IdInscricao;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IDEVENTODOC";
            parametro.Value = entity.IdEventoDoc;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ARQUIVO";
            parametro.Value = entity.Arquivo;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@STATUS";
            parametro.Value = entity.Status;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.EventosInscricoesDocs.InserirDoc();
            Objects.Eventos.EventosInscricoesDocs item;

            if (baseDataAccess == null)
                item = new BaseDataAccess().ExecuteReader<Objects.Eventos.EventosInscricoesDocs>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
            else
                item = baseDataAccess.ExecuteReaderTransacrion<Objects.Eventos.EventosInscricoesDocs>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

            return item;
        }
    }
}
