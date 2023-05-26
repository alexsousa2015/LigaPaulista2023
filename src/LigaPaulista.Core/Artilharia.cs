using System.Data;
using System.Web.UI.WebControls;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for Artilharia
    /// </summary>
    public class Artilharia
    {
        public static DataSet trazCategorias(int id)
        {
            Sql sql = new Sql();
            sql.strSql = "SELECT * FROM [artilheiros_categorias] where id_periodo="+ id +" ORDER BY [categoria]";
            return sql.queryDs();
        }


        public static DataSet trazArtilheiros(string id_categoria)
        {
            Sql sql = new Sql();
            sql.strSql = "SELECT a.nome as Nome, e.entidade as Entidade, a.gols as Pts FROM artilheiros as a " +
                         "inner join entidades as e on e.id_entidade = a.id_entidade " +
                         "where a.id_categoria = " + id_categoria + " " +
                         "ORDER BY a.gols DESC";
            return sql.queryDs();
        }

        public static void pegaPeriodo(DropDownList ddl_periodo)
        {
            var sql = new Sql
            {
                strSql = "SELECT [id_periodo], [periodo] FROM [periodos] where [periodo] not like '%2016%'"
            };

            ddl_periodo.DataSource = sql.queryDs();
            ddl_periodo.DataTextField = "periodo";
            ddl_periodo.DataValueField = "id_periodo";
            ddl_periodo.DataBind();
        }
    }
}
