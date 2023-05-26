using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Campeonatos
{
    public sealed class Entidades
    {
        public Objects.Campeonatos.Entidades GetEntidade(Objects.Campeonatos.Entidades entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ID_ENTIDADE";
            parametro.Value = entity.IDEntidade;
            listaParametros.Add(parametro);

            string SQL = Sql.Campeonatos.Entidades.GetEntidade();
            Objects.Campeonatos.Entidades item;

            if (baseDataAccess == null)
                item = new BaseDataAccess().ExecuteReader<Objects.Campeonatos.Entidades>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
            else
                item = baseDataAccess.ExecuteReaderTransacrion<Objects.Campeonatos.Entidades>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

            return item;
        }

        public List<Objects.Campeonatos.Entidades> GetEntidadesDoGrupo(Objects.Campeonatos.Grupos entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ID_GRUPO";
            parametro.Value = entity.IDGrupo;
            listaParametros.Add(parametro);

            string SQL = Sql.Campeonatos.Entidades.GetEntidadesDoGrupo();
            List<Objects.Campeonatos.Entidades> list;

            if (baseDataAccess == null)
                list = new BaseDataAccess().ExecuteReader<Objects.Campeonatos.Entidades>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();
            else
                list = baseDataAccess.ExecuteReaderTransacrion<Objects.Campeonatos.Entidades>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();

            return list;
        }
    }
}
