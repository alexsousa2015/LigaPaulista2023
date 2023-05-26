using System;
using System.Data;

namespace LigaPaulista.Core.Campeonatos
{
    /// <summary>
    /// Classe Campeonato
    /// </summary>
    public class Campeonato
    {
        public int ID_Campeonato { get; set; }
        public int ID_Modalidade { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        /// <summary>
        /// Cadastra Campeonato
        /// </summary>
        /// <param name="id_modalidade"></param>
        /// <param name="nome"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int CadastrarCampeonato(int id_modalidade, string nome, DateTime data)
        {
            return 0;
        }

        /// <summary>
        /// Retorna todos os campeonatos
        /// </summary>
        /// <returns></returns>
        public DataSet RetornaCampeonato()
        {
            var sql = new Sql()
            {
                strSql = "Select ID_CAMPEONATO,NOME from CAMPEONATOS"
            };
            return sql.queryDs();
        }

        /// <summary>
        /// Retorna Consulta por id de modalidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataSet RetornaCampeonato(int id)
        {
            var sql = new Sql()
            {
                strSql =
                    string.Format("Select ID_CAMPEONATO,NOME from CAMPEONATOS where ID_MODALIDADE = {0} ORDER BY ID_CAMPEONATO DESC", id)
            };
            return sql.queryDs();
        }

        public string retornaNomeporID(int id_campeonato)
        {

            var sql = new Sql()
            {
                strSql =
                    string.Format("select nome from Campeonatos where id_campeonato = {0}", id_campeonato)
            };
            return sql.queryString();

        }
    }


}

