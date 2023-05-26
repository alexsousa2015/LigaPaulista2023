using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using LigaPaulista.Core.SDK.DAO;

namespace LigaPaulista.Core.DataAccess.Campeonatos
{
    public sealed class Artilharia
    {
        public IEnumerable<Objects.Campeonatos.Artilharia> GetTop5ArtilheirosDoAno(string Modalidade, bool CarregarDependencias, BaseDataAccess baseDataAccess = null)
        {
            string DbProviderName = "System.Data.SqlClient";
            DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

            List<DbParameter> listaParametros = new List<DbParameter>();
            DbParameter parametro;

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@ANO";
            parametro.Value = DateTime.Now.Year;
            listaParametros.Add(parametro);

            parametro = factory.CreateParameter();
            parametro.ParameterName = "@Modalidade";
            parametro.Value = Modalidade;
            listaParametros.Add(parametro);

            //string SQL = Sql.Campeonatos.Artilharia.GetTop5ArtilheirosDoAno();
            string SQL = string.Format(@"SELECT TOP 5
	                    A.ID_ARTILHEIRO,
	                    A.ID_CATEGORIA,
	                    A.ID_ENTIDADE,
	                    A.NOME,
	                    A.GOLS
                    FROM ARTILHEIROS A
	                    JOIN ARTILHEIROS_CATEGORIAS C ON C.ID_CATEGORIA = A.ID_CATEGORIA
	                    JOIN PERIODOS P ON P.ID_PERIODO = C.ID_PERIODO
                    WHERE (P.ANO = {0}) AND (C.CATEGORIA LIKE '%{1}%') 
                    ORDER BY A.GOLS  DESC", DateTime.Now.Year, Modalidade);

            List<Objects.Campeonatos.Artilharia> list;

            if (baseDataAccess == null)
                list = new BaseDataAccess().ExecuteReader<Objects.Campeonatos.Artilharia>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();
            else
                list = baseDataAccess.ExecuteReaderTransacrion<Objects.Campeonatos.Artilharia>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).ToList();

            if (CarregarDependencias)
            {
                foreach (Objects.Campeonatos.Artilharia item in list)
                {
                    item.Categoria = new Categorias().GetCategoria(new Objects.Campeonatos.Artilharia.Categorias() { IDCategoria = item.IDCategoria }, false);
                    item.Entidade = new Entidades().GetEntidade(new Objects.Campeonatos.Entidades() { IDEntidade= item.IDEntidade});
                }

            }

            return list;
        }

        public sealed class Categorias
        {
            public Objects.Campeonatos.Artilharia.Categorias GetCategoria(Objects.Campeonatos.Artilharia.Categorias entity, bool CarregarDependencias, BaseDataAccess baseDataAccess = null)
            {
                string DbProviderName = "System.Data.SqlClient";
                DbProviderFactory factory = DbProviderFactories.GetFactory(DbProviderName);

                List<DbParameter> listaParametros = new List<DbParameter>();
                DbParameter parametro;

                parametro = factory.CreateParameter();
                parametro.ParameterName = "@ID_CATEGORIA";
                parametro.Value = entity.IDCategoria;
                listaParametros.Add(parametro);

                string SQL = Sql.Campeonatos.Artilharia.Categorias.GetCategoria();
                Objects.Campeonatos.Artilharia.Categorias item;

                if (baseDataAccess == null)
                    item = new BaseDataAccess().ExecuteReader<Objects.Campeonatos.Artilharia.Categorias>(factory, BaseDataAccess.ConectionServer.Connection_Sql, System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();
                else
                    item = baseDataAccess.ExecuteReaderTransacrion<Objects.Campeonatos.Artilharia.Categorias>(System.Data.CommandType.Text, SQL, listaParametros.ToArray()).FirstOrDefault();

                if (CarregarDependencias)
                {
                    item.Periodo = new Periodos().GetPeriodo(new Objects.Campeonatos.Periodos() {IDPeriodo = item.IDPeriodo});
                }

                return item;
            }
        }
    }
}
