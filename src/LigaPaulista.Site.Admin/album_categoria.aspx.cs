using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Formula;
using LigaPaulista.Core;

namespace LigaPaulista.Site.Admin
{
    public partial class album_categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //   Login.validarLoginAdm();
            if (!Page.IsPostBack)
            {
                if (Utils.existeSession("categoria"))
                {
                    txt_catAlterar.Text = ((Categoria)Session["categoria"]).categoria;
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                }
                else
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var cat = new Categoria {categoria = txt_categoria.Text};

            cat.incluir();
            txt_categoria.Text = "";
            //gridCategoria.DataBind();

            Utils.showMsg(this, "Categoria incluída com sucesso!");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var cat = (Categoria)Session["categoria"];
            cat.categoria = txt_catAlterar.Text;

            cat.alterar();
            //txt_catAlterar.Text = "";
            Session["categoria"] = "";
            //gridCategoria.DataBind();

            Response.Redirect("album.aspx?msg=Categoria alterada com sucesso!");
            //Utils.showMsg(this, "Categoria alterada com sucesso!");
        }
    }
}
