using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Formula.Ferramentas;
using Formula;
using LigaPaulista.Core;

namespace LigaPaulista.Site.Admin
{
    public partial class album : AdminTheme
    {
        public int ano;
        protected void Page_Load(object sender, EventArgs e)
        {
            var agora = DateTime.Now.Year;
            if (!Page.IsPostBack)
            {
                string msg = Request["msg"];
                if (!string.IsNullOrEmpty(msg))
                    Utils.showMsg(this, msg);

                ddl_anos.DataSource = Album.preencheAnosAlbuns();
                ddl_anos.DataValueField = "ANO";
                ddl_anos.DataValueField = "ANO";
                ddl_anos.DataBind();
                

                // Itera enquanto não houver um ano válido
                while (!Album.verificaAno(agora))
                {
                    agora = agora - 1;
                }
                ano = agora;
                ddl_anos.Items.FindByValue(agora.ToString()).Selected = true;

            }
        }
        protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //SqlDataSource sqlDS = (SqlDataSource)e.Row.FindControl("SqlDataSource1_albuns");
                //sqlDS.SelectParameters[0].DefaultValue = e.Row.Cells[0].Text;
                //Session["id_categoria"] = e.Row.Cells[0].Text;
                //((Label)e.Row.FindControl("lbl_id")).Text = e.Row.Cells[0].Text;

                int id_categoria = Convert.ToInt32(e.Row.Cells[0].Text);
                GridView gv = (GridView)e.Row.FindControl("GridViewAlbuns");
                //var dbSrc = new AccessDataSource
                //{
                //    DataFile = "../App_Data/banco.mdb",
                //    SelectCommand = ("SELECT id_album, titulo FROM ALBUM A where (id_cat = " +
                //                     id_categoria + ");"),
                //};
                SqlDataSource.ConnectionString = ConfigurationManager.ConnectionStrings["LigaabcConnectionString"].ToString();
                SqlDataSource.SelectCommand = ("SELECT id_album, album FROM ALBUM where id_cat = " + id_categoria + " and ano=" + ano);
                //AccessDataSource1.DataFile = "../App_Data/banco.mdb";
                //AccessDataSource1.SelectCommand = ("SELECT id_album, album FROM ALBUM where id_cat = " + id_categoria+" and ano="+ano);
                gv.DataSource = SqlDataSource;
                gv.DataBind();
            }
        }

        protected void btn_upd_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            Session["categoria"] = Categoria.pegaDadosPeloID(id);
            Response.Redirect("album_categoria.aspx");
            //txt_categoria.Text = ((Categoria) Session["categoria"]).categoria;
        }

        protected void btn_addFoto_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            Session[GaleriaFotos.Session.album] = Album.pegaDadosPeloID(id);
            Response.Redirect("album_fotos.aspx");
        }

        protected void btn_updAlbum_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            Response.Redirect("album_add.aspx?id=" + id);
        }

        protected void btn_del_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(((ImageButton)sender).CommandArgument);

            Categoria cat = new Categoria();
            cat.id_categoria = id;

            if (cat.excluir())
            {
                Utils.showMsg(this, "Categoria excluída com sucesso!");
                GridView1.DataBind();
            }
            else
                Utils.showMsg(this, "Apague os albuns desta categoria para poder exclui-la!");
        }

        protected void btn_verFoto_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            //Session[GaleriaFotos.Session.album] = Album.pegaDadosPeloID(id);
            Response.Redirect("album_fotos_lista.aspx?id=" + id);
        }

        protected void btn_delFoto_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            Album.apagarAlbumFotos(id);

            Utils.showMsg(this, "Álbum e fotos excluído com sucesso!");
            GridView1.DataBind();
        }

        protected void ddl_anos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux;
            aux = Convert.ToInt32(ddl_anos.SelectedValue);

            ano = aux;
            GridView1.DataBind();
        }
    }
}
