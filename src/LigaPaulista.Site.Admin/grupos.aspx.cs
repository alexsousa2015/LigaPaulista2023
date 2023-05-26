using System;
using System.Linq;
using DevExpress.Web;
using Formula.Ferramentas;
using LigaPaulista;
using LigaPaulista.Core.Campeonatos;

namespace LigaPaulista.Site.Admin
{
    public partial class Grupos : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var c = new Campeonato();
            var m = new Modalidade();
            if (Request.QueryString["id_campeonato"] != null)
                Session["id_campeonato"] = int.Parse(Request.QueryString["id_campeonato"]);
            if (Request.QueryString["id_campeonato"] != null)
                Session["id_modalidade"] = int.Parse(Request.QueryString["id_modalidade"]);

            if (Request.QueryString["id_campeonato"] != null && Request.QueryString["id_modalidade"] != null)
            {
                var id_campeonato = Int32.Parse(Request.QueryString["id_campeonato"]);
                var id_modalidade = Int32.Parse(Request.QueryString["id_modalidade"]);

                lbltitulo.Text = c.retornaNomeporID(id_campeonato);
                lblModalidade.Text = " - " + Convert.ToString(Modalidade.RetornaModalidade(id_modalidade).Tables[0].Rows[0].ItemArray[1]);
            }
            else
            {
                Response.Redirect("modalidades.aspx");
            }
        }

        protected void gridGrupos_DataSelect(object sender, EventArgs e)
        {
            if (Request.QueryString["id_campeonato"] != null)
                Session["id_campeonato"] = int.Parse(Request.QueryString["id_campeonato"]);

            Session["id_Grupo"] = (sender as ASPxGridView).GetMasterRowKeyValue().ToString().Split('|').Last();}
    }
}
