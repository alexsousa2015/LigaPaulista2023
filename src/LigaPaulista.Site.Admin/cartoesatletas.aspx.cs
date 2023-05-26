using System;
using Formula;
using Formula.Ferramentas;
using LigaPaulista.Core.Campeonatos;

namespace LigaPaulista.Site.Admin
{
    public partial class cartoesatletas : AdminTheme
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

        protected void ddlModalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCampeonatos.Items.Clear();
            ddlCampeonatos.Enabled = false;
            ddlCampeonatos.SelectedValue = null;
            pCartoes.Visible = false;

            if (!string.IsNullOrEmpty(ddlModalidades.SelectedValue))
            {
                CarregaCampeonatos(Convert.ToInt32(ddlModalidades.SelectedValue));
            }
        }

        protected void ddlCampeonatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pCartoes.Visible = false;

            if (!string.IsNullOrEmpty(ddlCampeonatos.SelectedValue))
            {
                Grid.DataBind();
                pCartoes.Visible = true;
            }
        }
    }
}
