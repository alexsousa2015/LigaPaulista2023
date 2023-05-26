using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Campeonatos
{
    public sealed class Campeonatos
    {
        public Objects.Campeonatos.Campeonatos GetCampeonato(Objects.Campeonatos.Campeonatos entity, bool CarregarDependencias, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ID_CAMPEONATO";
            parametro.Value = entity.IDCampeonato;
            listaParametros.Add(parametro);

            string SQL = Sql.Campeonatos.Campeonatos.GetCampeonato();
            Objects.Campeonatos.Campeonatos item;

            if (baseDataAccess == null)
                item = new BaseDataAccess().ExecuteReader<Objects.Campeonatos.Campeonatos>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
            else
                item = baseDataAccess.ExecuteReaderTransacrion<Objects.Campeonatos.Campeonatos>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

            if (CarregarDependencias)
            {
                item.Grupos =
                    new Grupos().GetGruposDoCampeonato(new Objects.Campeonatos.Campeonatos()
                                                           {IDCampeonato = item.IDCampeonato}, true);
                item.Modalidade =
                    new Modalidades().GetModalidade(new Objects.Campeonatos.Modalidades()
                                                        {IDModalidade = item.IDModalidade});
            }

            return item;
        }
    }
}
