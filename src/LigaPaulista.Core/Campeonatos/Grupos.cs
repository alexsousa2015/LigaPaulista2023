using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LigaPaulista.Core.Campeonatos
{
    public class Grupos
    {
        public int ID_Grupo { get; set; }
        public string NomeGrupo { get; set; }

        /// <summary>
        /// Cadastrar Grupo
        /// </summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public int CadastrarGrupo(string grupo)
        {
            return 0;
        }

        /// <summary>
        /// Retorna Grupos
        /// </summary>
        /// <returns></returns>
        public DataSet ConsultaGrupo()
        {
            var sql = new Sql()
                          {
                              strSql = "Select * from Grupos"
                          };
            var ds = sql.queryDs();
            return ds;
        }

        /// <summary>
        /// Retorna Consulta por id_modalidade e id de campeonato
        /// </summary>
        /// <param name="id_modalidade"></param>
        /// <param name="id_campeonato"></param>
        /// <returns>Retorna Dataset com grupos</returns>
        public DataSet RetornaGrupos(int id_modalidade, int id_campeonato)
        {
            var ds = new DataSet();

            var sql = new Sql
                          {
                              strSql = string.Format("select gc.id_Grupo from "+
                              "grupo_campeonato gc inner join grupos g on g.ID_GRUPO = gc.ID_GRUPO "+
                              "where gc.ID_CAMPEONATO = {0} and isnull(g.ESCONDER,0) = 0 "+
                              "order by g.grupo asc", id_campeonato)
                          };
            //Retorna quantidade de grupos por campeonato
            var cod = sql.queryDataTable();

            for (var i = 0; i < cod.Rows.Count; i++)
            {
                var param = new SqlParameter[]
                                       {
                                           new SqlParameter("@id_grupo",cod.Rows[i].ItemArray[0]),
                                           new SqlParameter("@id_modalidade", id_modalidade),
                                           new SqlParameter("@id_campeonato",id_campeonato)
                                        };

                var dsTable = sql.querySP("stp_RetornaTabela", param);
                DataTable dt = dsTable.Tables[0];

                if (dt != null)
                {
                    dt.TableName = "Tabela" + i;
                    ds.Tables.Add(dt.Copy());
                }
            }

            return ds;

        }

        /// <summary>
        /// Retorna Grupos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataSet RetornaGruposPorID(int id)
        {
            var sb = new StringBuilder();
            sb.Append("select gc.ID_GRUPO,");
            sb.Append("g.GRUPO ");
            sb.Append("from GRUPO_CAMPEONATO gc ");
            sb.Append("join GRUPOS g ");
            sb.Append("on g.ID_GRUPO = gc.ID_GRUPO ");
            sb.AppendFormat("where ID_CAMPEONATO = {0}",id);

            var sql = new Sql
                          {
                              strSql = sb.ToString()
                          };

            return sql.queryDs();
        }
    }
}
