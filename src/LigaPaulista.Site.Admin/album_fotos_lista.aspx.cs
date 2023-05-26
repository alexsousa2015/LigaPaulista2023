using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Formula.Ferramentas;
using Formula;
using LigaPaulista.Core;

namespace LigaPaulista.Site.Admin
{
    public partial class album_fotos_lista : AdminTheme
    {
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                carregarAlbum();
        }

        private void carregarAlbum()
        {
            id = Convert.ToInt32(Request["id"]);
            if (id != 0)
            {
                DataSet ds = GaleriaFotos.listarFotos(id);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Utils.showMsg(this, "Esse álbum não contém fotos!", "album.aspx");
                }

                else
                {
                    rpt_fotos.DataSource = ds;
                    rpt_fotos.DataBind();
                    lbl_nomeAlbum.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                    lbl_nomeAlbum.Visible = true;
                }
            }
        }

        protected void apagarFoto(object sender, ImageClickEventArgs e)
        {
            var id_foto = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            Foto.apagarFoto(id_foto);

            Utils.showMsg(this, "Foto excluída com sucesso!");
            carregarAlbum();
        }
        // e:\home\ligaabc\web\album\fotos\
        protected void alterarFoto(object sender, ImageClickEventArgs e)
        {
            var id_legenda = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            string legenda = ((ImageButton)sender).CommandName;

            lbl_id.Text = id_legenda.ToString();
            txt_legenda.Text = legenda;
            Image1.ImageUrl = "../../album/fotos/thumbs/" + id + "/" + ((ImageButton)sender).AlternateText;

            Panel1.Visible = true;
            //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "moverBottom", "<script>scrollToBottom();</script>");
        }

        protected void gravarLegenda(object sender, EventArgs e)
        {
            int id_legenda = Convert.ToInt32(lbl_id.Text);
            string legenda = txt_legenda.Text;

            Foto.alterarLegenda(id_legenda, legenda);
            carregarAlbum();

            Panel1.Visible = false;
            Utils.showMsg(this, "Legenda alterada com sucesso!");
        }
    }
}
