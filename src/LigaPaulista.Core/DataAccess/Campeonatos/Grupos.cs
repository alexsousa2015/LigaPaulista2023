using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Campeonatos
{
    public sealed class Grupos
    {
        public Objects.Campeonatos.Grupos GetGrupo(Objects.Campeonatos.Grupos entity, bool CarregarDependencias, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ID_GRUPO";
            parametro.Value = entity.IDGrupo;
            listaParametros.Add(parametro);

            string SQL = Sql.Campeonatos.Grupos.GetGrupo();
            Objects.Campeonatos.Grupos item;

            if (baseDataAccess == null)
                item = new BaseDataAccess().ExecuteReader<Objects.Campeonatos.Grupos>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
            else
                item = baseDataAccess.ExecuteReaderTransacrion<Objects.Campeonatos.Grupos>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

            if(CarregarDependencias)
            {
                item.Entidades =
                    new Entidades().GetEntidadesDoGrupo(
                        new Objects.Campeonatos.Grupos() {IDGrupo = item.IDGrupo});
            }

            return item;
        }

        public List<Objects.Campeonatos.Grupos> GetGruposDoCampeonato(Objects.Campeonatos.Campeonatos entity, bool CarregarDependencias, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ID_CAMPEONATO";
            parametro.Value = entity.IDCampeonato;
            listaParametros.Add(parametro);

            string SQL = Sql.Campeonatos.Grupos.GetGruposDoCampeonato();
            List<Objects.Campeonatos.Grupos> list;

            if (baseDataAccess == null)
                list = new BaseDataAccess().ExecuteReader<Objects.Campeonatos.Grupos>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();
            else
                list = baseDataAccess.ExecuteReaderTransacrion<Objects.Campeonatos.Grupos>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();

            if (CarregarDependencias)
            {
                
            }

            return list;
        }
    }
}
