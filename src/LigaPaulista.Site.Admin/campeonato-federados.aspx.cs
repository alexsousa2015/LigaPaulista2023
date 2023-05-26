using LigaPaulista.Core.Campeonatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaPaulista.Site.Admin
{
    public partial class campeonato_federados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var c = new Campeonato();
                var m = new Modalidade();
                if (Request.QueryString["id_campeonato"] != null && Request.QueryString["id_modalidade"] != null)
                {
                    var id_campeonato = Int32.Parse(Request.QueryString["id_campeonato"]);
                    var id_modalidade = Int32.Parse(Request.QueryString["id_modalidade"]);
                    lbltitulo.Text = c.retornaNomeporID(id_campeonato);
                    lblModalidade.Text = " - " + Convert.ToString(Modalidade.RetornaModalidade(id_modalidade).Tables[0].Rows[0].ItemArray[1]);

                    CarregarEntidades(id_campeonato, id_modalidade);
                }
            }
        }

        protected void CarregarEntidades(int id_campeonato, int id_modalidade)
        {
            var sql = new Sql(string.Format(@"select DISTINCT E.[ID_ENTIDADE], E.[ENTIDADE]
                                from [dbo].[CAMPEONATOS] C
                                    join [dbo].[GRUPO_CAMPEONATO] GC on GC.ID_CAMPEONATO = C.ID_CAMPEONATO
                                    join [dbo].[GRUPOS_ENTIDADES] GE on GE.ID_GRUPO = gc.ID_GRUPO
                                    join [dbo].[ENTIDADES] E on E.ID_ENTIDADE = GE.ID_ENTIDADE
                                where C.ID_CAMPEONATO = {0} and C.ID_MODALIDADE = {1}", id_campeonato, id_modalidade));
            
            DdlEntidade.DataSource = sql.queryDs();
            DdlEntidade.DataValueField = "ID_ENTIDADE";
            DdlEntidade.DataTextField = "ENTIDADE";
            DdlEntidade.DataBind();

            DdlEntidade.Items.Insert(0, new ListItem("", ""));
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            var sql = new Sql(string.Format(@"INSERT INTO CAMPEONATOS_FEDERADOS (ID_CAMPEONATO, ID_CADASTRO) VALUES({0},{1})", Request.QueryString["id_campeonato"], DdlAtletas.SelectedItem.Value));
            sql.query();

            Grid1.DataBind();
        }

        protected void DdlEntidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sql = new Sql(string.Format(@"select distinct ID_CADASTRO, NOME = (NOME + ' ' + SOBRENOME + ' | RG: ' + RG)
                                from [dbo].[CADASTRO]
                                where FACULDADE = {0} order by NOME", ((DropDownList)sender).SelectedItem.Value));

            DdlAtletas.DataSource = sql.queryDs();
            DdlAtletas.DataValueField = "ID_CADASTRO";
            DdlAtletas.DataTextField = "NOME";
            DdlAtletas.DataBind();
        }
    }
}