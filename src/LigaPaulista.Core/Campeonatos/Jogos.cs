using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LigaPaulista.Core.Campeonatos
{
    public class Jogos
    {
        public int ID_Jogo { get; set; }
        public DateTime Data { get; set; }
        public int Time1 { get; set; }
        public int Time2 { get; set; }
        public int Placar_Time1 { get; set; }
        public int Placar_Time2 { get; set; }
        public int ID_Localidade { get; set; }
        public int ID_Grupo { get; set; }
        public string Observacoes { get; set; }

        /// <summary>
        /// Cadastra Jogo
        /// </summary>
        /// <param name="data"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="id_localidade"></param>
        /// <param name="id_grupo"></param>
        /// <param name="id_jogo"></param>
        /// <returns></returns>
        public int CadastrarJogo(DateTime data, int time1, int time2,
                                 int id_localidade, int id_grupo, int id_jogo)
        {
            var sql = new Sql
                          {
                              strSql =
                                  string.Format(
                                  "Insert into jogos values({0},{1},{2},{3},{4}, where id_jogo = {5}",
                                  data, time1, time2, id_localidade, id_grupo, ID_Jogo)
                          };
            return sql.queryID();
        }

        /// <summary>
        /// Alterar dados do Jogo
        /// </summary>
        /// <param name="data"></param>
        /// <param name="time1"></param>
        /// <param name="placar1"></param>
        /// <param name="placar2"></param>
        /// <param name="time2"></param>
        /// <param name="id_localidade"></param>
        /// <param name="id_grupo"></param>
        /// <param name="obs"></param>
        /// <returns></returns>
        public string AlterarJogo(DateTime data, int time1, int placar1, int placar2, int time2,
                                  int id_localidade, int id_grupo, string obs)
        {
            var sql = new Sql
                          {
                              strSql =
                                  string.Format(
                                  "Update jogos set Data = {0},Time1 = {1},Placar_Time1 = {2},Placar_Time2 = {3},Time2 = {4},ID_LOCALIDADE={5},ID_Grupo = {6},Observacoes = {7} where id_jogo = {8}",
                                  data, time1, placar1, placar2, time2, id_localidade, id_grupo, @obs, ID_Jogo)
                          };
            return sql.queryString();
        }

        /// <summary>
        /// Retorna Tabela de Jogos por modalidade
        /// </summary>
        /// <param name="id_campeonato"></param>
        /// <returns></returns>
        public static DataSet RetornaTabela(int id_campeonato)
        {
            var sql = new Sql();

            var param = new SqlParameter();
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32;
            param.ParameterName = "@id_campeonato";
            param.Value = id_campeonato;

            return sql.querySP("stp_RetornaConfrontos", param);
        }

        public static DataSet RetornaTabelaAdm(int id_modalidade)
        {
            var sql = new Sql();

            var param = new SqlParameter();
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Int32;
            param.ParameterName = "@id_modalidade";
            param.Value = id_modalidade;

            return sql.querySP("stp_RetornaConfrontosAdm", param);
        }

        [Obsolete("Retornar com Object", true)]
        public static DataSet RetornaProxJogos()
        {
            var sb = new StringBuilder();
            sb.Append(
                "SELECT top 1 m.MODALIDADE AS Modalidade, j.DATA AS Data, j.HORA, e1.ENTIDADE AS 'Time 1', e2.ENTIDADE AS 'Time 2', l.LOCALIDADE AS Localidade FROM JOGOS AS j");
            sb.Append(" LEFT OUTER JOIN ENTIDADES AS e ON j.TIME2 = e.ID_ENTIDADE AND j.TIME1 = e.ID_ENTIDADE ");
            sb.Append(" LEFT OUTER JOIN LOCALIDADES AS l ON j.ID_LOCALIDADE = l.ID_LOCALIDADE ");
            sb.Append(" LEFT OUTER JOIN MODALIDADES AS m ON j.ID_MODALIDADE = m.ID_MODALIDADE ");
            sb.Append(" INNER JOIN ENTIDADES AS e1 ON e1.ID_ENTIDADE = j.TIME1  ");
            sb.Append(" INNER JOIN ENTIDADES AS e2 ON e2.ID_ENTIDADE = j.TIME2 ");
            sb.Append(" where DAY(j.DATA) >= DAY(GETDATE())");
            sb.Append(" and MONTH(j.DATA) >= MONTH(GETDATE())");
            sb.Append(" and YEAR(j.DATA) >= YEAR(GETDATE())");
            sb.Append(" ORDER BY Data DESC ");

            var sql = new Sql
                          {
                              StringSql = sb.ToString()
                          };

            return sql.queryDs();
        }

        public static Jogos RetornaProxJogoss()
        {
            var sb = new StringBuilder();
            sb.Append(
                "SELECT top 1 m.MODALIDADE AS Modalidade, j.DATA AS Data, j.HORA, e1.ENTIDADE AS 'Time 1', e2.ENTIDADE AS 'Time 2', l.LOCALIDADE AS Localidade FROM JOGOS AS j");
            sb.Append(" LEFT OUTER JOIN ENTIDADES AS e ON j.TIME2 = e.ID_ENTIDADE AND j.TIME1 = e.ID_ENTIDADE ");
            sb.Append(" LEFT OUTER JOIN LOCALIDADES AS l ON j.ID_LOCALIDADE = l.ID_LOCALIDADE ");
            sb.Append(" LEFT OUTER JOIN MODALIDADES AS m ON j.ID_MODALIDADE = m.ID_MODALIDADE ");
            sb.Append(" INNER JOIN ENTIDADES AS e1 ON e1.ID_ENTIDADE = j.TIME1  ");
            sb.Append(" INNER JOIN ENTIDADES AS e2 ON e2.ID_ENTIDADE = j.TIME2 ");
            sb.Append(" where DAY(j.DATA) >= DAY(GETDATE())");
            sb.Append(" and MONTH(j.DATA) >= MONTH(GETDATE())");
            sb.Append(" and YEAR(j.DATA) >= YEAR(GETDATE())");
            sb.Append(" ORDER BY Data DESC ");

            var sql = new Sql
            {
                StringSql = sb.ToString()
            };

            return Bind(sql.queryDs().Tables[0].Rows[0]);
        }

        private static Jogos Bind(DataRow dr)
        {
            var jogo = new Jogos();



            return jogo;
        }
    }
}