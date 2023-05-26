using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Campeonatos
{
    public sealed class Periodos
    {
        public Objects.Campeonatos.Periodos GetPeriodo(Objects.Campeonatos.Periodos entity, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ID_PERIODO";
            parametro.Value = entity.IDPeriodo;
            listaParametros.Add(parametro);

            string SQL = Sql.Campeonatos.Periodos.GetPeriodo();
            Objects.Campeonatos.Periodos item;

            if (baseDataAccess == null)
                item = new BaseDataAccess().ExecuteReader<Objects.Campeonatos.Periodos>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
            else
                item = baseDataAccess.ExecuteReaderTransacrion<Objects.Campeonatos.Periodos>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

            return item;
        }
    }
}
