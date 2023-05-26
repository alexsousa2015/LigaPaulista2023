using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Eventos
{
    public sealed class EventosInscricoes
    {
        public int EstaInscrito(Objects.Eventos.EventosInscricoes entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IDCADASTRO";
            parametro.Value = entity.IdCadastro;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IDEVENTO";
            parametro.Value = entity.IdEvento;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.EventosInscricoes.EstaInscrito();
            List<Objects.Eventos.EventosInscricoes> list;

            if (baseDataAccess == null)
                list = new BaseDataAccess().ExecuteReader<Objects.Eventos.EventosInscricoes>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();
            else
                list = baseDataAccess.ExecuteReaderTransacrion<Objects.Eventos.EventosInscricoes>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();

            return list.Count;
        }

        public List<Objects.Eventos.EventosInscricoes> PegarInscricoes(Objects.Eventos.EventosInscricoes entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IDCADASTRO";
            parametro.Value = entity.IdCadastro;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IDEVENTO";
            parametro.Value = entity.IdEvento;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ANO";
            parametro.Value = entity.Ano;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ATIVO";
            parametro.Value = entity.Ativo;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.EventosInscricoes.PegarInscricoes();
            List<Objects.Eventos.EventosInscricoes> list;

            if (baseDataAccess == null)
                list = new BaseDataAccess().ExecuteReader<Objects.Eventos.EventosInscricoes>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();
            else
                list = baseDataAccess.ExecuteReaderTransacrion<Objects.Eventos.EventosInscricoes>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();

            foreach (Objects.Eventos.EventosInscricoes item in list)
            {
                item.ObjStatus = item.GetStatus();
                item.Evento = new Business.Eventos.Eventos().GetEvento(new Objects.Eventos.Eventos() { IdEvento = item.IdEvento });
                item.Docs = new Business.Eventos.EventosInscricoesDocs().GetEventosInscricoesDocs(item);
            }
            return list;
        }

        public Objects.Eventos.EventosInscricoes Inscrever(Objects.Eventos.EventosInscricoes entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IDEVENTO";
            parametro.Value = entity.IdEvento;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IdCadastro";
            parametro.Value = entity.IdCadastro;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@Status";
            parametro.Value = entity.Status;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@Ano";
            parametro.Value = entity.Ano;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@Ativo";
            parametro.Value = entity.Ativo;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.EventosInscricoes.Inscrever();
            Objects.Eventos.EventosInscricoes item;

            if (baseDataAccess == null)
                item = new BaseDataAccess().ExecuteReader<Objects.Eventos.EventosInscricoes>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
            else
                item = baseDataAccess.ExecuteReaderTransacrion<Objects.Eventos.EventosInscricoes>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

            return item;
        }

        public void InativarAnteriores(Objects.Eventos.EventosInscricoes entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IDEVENTO";
            parametro.Value = entity.IdEvento;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@IdCadastro";
            parametro.Value = entity.IdCadastro;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@Ano";
            parametro.Value = entity.Ano;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@Ativo";
            parametro.Value = entity.Ativo;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.EventosInscricoes.InativarAnteriores();

            if (baseDataAccess == null)
                new BaseDataAccess().ExecuteNonQuery(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray());
            else
                baseDataAccess.ExecuteNonQuery(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray());
        }

        public Objects.Eventos.EventosInscricoes Atualizar(Objects.Eventos.EventosInscricoes entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@Status";
            parametro.Value = entity.Status;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@CodigoPgto";
            parametro.Value = entity.CodigoPgto;
            listaParametros.Add(parametro);

            string SQL = Sql.Eventos.EventosInscricoes.Atualizar();
            Objects.Eventos.EventosInscricoes item;

            if (baseDataAccess == null)
                item = new BaseDataAccess().ExecuteReader<Objects.Eventos.EventosInscricoes>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
            else
                item = baseDataAccess.ExecuteReaderTransacrion<Objects.Eventos.EventosInscricoes>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

            item.Docs = new Business.Eventos.EventosInscricoesDocs().GetEventosInscricoesDocs(item);
            return item;
        }
    }
}
