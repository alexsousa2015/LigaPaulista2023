using System;
using Formula;
using Formula.Ferramentas;
using LigaPaulista.Core.Campeonatos;

namespace LigaPaulista.Site.Admin
{
    public partial class jogos : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            CarregaModalidades();
        }

        private void CarregaCampeonatos(int id)
        {
            var ds = Campeonato.RetornaCampeonato(Convert.ToInt32(id));
            if (Utils.existeDataSet(ds))
            {
                ddlCampeonatos.Enabled = true;
                ddlCampeonatos.DataSource = ds.Tables[0].DefaultView;
                ddlCampeonatos.DataTextField = "NOME";
                ddlCampeonatos.DataValueField = "ID_CAMPEONATO";
                ddlCampeonatos.DataBind();
                ddlCampeonatos.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Escolha o Campeonato...", ""));
            }
        }

        private void CarregaModalidades()
        {
            ddlModalidades.DataSource = Modalidade.RetornaModalidade();
            ddlModalidades.DataTextField = "MODALIDADE";
            ddlModalidades.DataValueField = "ID_MODALIDADE";
            ddlModalidades.DataBind();
            ddlModalidades.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Escolha a Modalidade...", ""));
        }

        private void CarregaGrupos(int id)
        {
            var ds = LigaPaulista.Core.Campeonatos.Grupos.RetornaGruposPorID(id);
            if (Utils.existeDataSet(ds))
            {
                ddlGrupos.Enabled = true;
                ddlGrupos.DataSource = ds.Tables[0].DefaultView;
                ddlGrupos.DataTextField = "GRUPO";
                ddlGrupos.DataValueField = "ID_GRUPO";
                ddlGrupos.DataBind();
                ddlGrupos.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Escolha o Grupo...", ""));
            }
        }

        protected void ddlModalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCampeonatos.Items.Clear();
            ddlCampeonatos.Enabled = false;
            ddlCampeonatos.SelectedValue = null;
            ddlGrupos.Enabled = false;
            ddlGrupos.SelectedValue = null;
            pJogos.Visible = false;

            if (!string.IsNullOrEmpty(ddlModalidades.SelectedValue))
            {
                CarregaCampeonatos(Convert.ToInt32(ddlModalidades.SelectedValue));
            }
            else
            {
                //ddlCampeonatos.Enabled = false;
                //ddlCampeonatos.SelectedValue = null;
                //ddlGrupos.Enabled = false;
                //ddlGrupos.SelectedValue = null;
                //pJogos.Visible = false;
            }
        }

        protected void ddlCampeonatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGrupos.Items.Clear();
            ddlGrupos.Enabled = false;
            ddlGrupos.SelectedValue = null;
            pJogos.Visible = false;

            if (!string.IsNullOrEmpty(ddlCampeonatos.SelectedValue))
            {
                CarregaGrupos(Convert.ToInt32(ddlCampeonatos.SelectedValue));
                //Grid.DataBind();
                //pJogos.Visible = true;
            }
            else
            {
                //ddlGrupos.Enabled = false;
                //ddlGrupos.SelectedValue = null;
                //pJogos.Visible = false;
            }
        }

        protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pJogos.Visible = false;

            if (!string.IsNullOrEmpty(ddlGrupos.SelectedValue))
            {
                Grid.DataBind();
                pJogos.Visible = true;
            }
            else
            {
                //pJogos.Visible = false;
            }
        }
    }
}
