using System;
using System.Data;
using System.IO;
using System.Web.UI;
using Formula;
using Formula.Ferramentas;
using LigaPaulista.Core;

namespace LigaPaulista.Site.Admin
{
    public partial class album_add : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Login.validarLoginAdm();
            if (!Page.IsPostBack)
            {
                txt_ano.Text = DateTime.Now.Year.ToString();
                carregarCategorias();
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    Session[GaleriaFotos.Session.album] = Album.pegaDadosPeloID(Convert.ToInt32(Request["id"]));
                    preencheAlbum();
                }
                else
                {
                    Session[GaleriaFotos.Session.album] = null;
                    //Session[GaleriaFotos.Session.imgCapa] = "";
                }

                string msg = Request["msg"];
                if (msg != "" && msg != null)
                    Utils.showMsg(this, msg);
            }
        }

        private void preencheAlbum()
        {
            var alb = (Album)Session[GaleriaFotos.Session.album];
            ddl_categoria.Items.FindByValue(alb.id_categoria.ToString()).Selected = true;
            txt_titulo.Text = alb.album;
            txt_descricao.Text = alb.descricao;
            txt_ordem.Text = alb.ordem;
            txt_ano.Text = alb.ano;

            //if (alb.capa != null && alb.capa != "")
            //{
            //    Session[GaleriaFotos.Session.imgCapa] = alb.capa;

            //    img_capa.ImageUrl = "../images/albuns/capa/" + alb.capa;
            //    img_capa.Visible = true;
            //    btn_apagarImagem.Visible = true;
            //}
        }

        private void carregarCategorias()
        {
            DataSet ds = Categoria.carregaCategoriasAdm();
            ddl_categoria.DataSource = ds;
            ddl_categoria.DataTextField = "categoria";
            ddl_categoria.DataValueField = "id_cat";
            ddl_categoria.DataBind();

            ddl_categoria.Items.Insert(0, "");
        }

        protected void btn_addFoto_Click(object sender, EventArgs e)
        {
            //string foto = "";

            if (upl_imagem.HasFile && Upload.verificaExtensao(upl_imagem.FileName, ".jpg") == false)
            {
                //ScriptManager.RegisterStartupScript(updPanelFoto, updPanelFoto.GetType(), "alertMe", "alert('Por favor, selecione uma foto no formato \".jpg\"');", true);
                Utils.showMsg(this, "Por favor, selecione uma foto no formato \".jpg\"");
            }
            else// se tiver foto
            {
                // se não tiver foto
                if (!upl_imagem.HasFile)
                    Utils.showMsg(this, "Selecione uma foto para incluir!");
                else if (upl_imagem.HasFile)
                {
                    // upa o arquivo
                    string filename = Upload.salvaArquivo(upl_imagem, GaleriaFotos.pathTemp);
                    // redimensiono depois de salvar, salvando outra e apagando a antiga.. =/ (POG)
                    //Upload.redimensionarImagem(129, 97, GaleriaFotos.pathTemp + filename,
                    //                           GaleriaFotos.pathCapa + filename);
                    Upload.deletaImagem(filename, GaleriaFotos.pathTemp);

                    //foto = filename;
                    //img_capa.ImageUrl = "../images/albuns/capa/" + filename;
                    //img_capa.Visible = true;

                    //Session[GaleriaFotos.Session.imgCapa] = filename;
                    btn_apagarImagem.Visible = true;
                }
            }
        }

        protected void btn_apagarImagem_Click(object sender, ImageClickEventArgs e)
        {
            //    img_capa.ImageUrl = "../images/albuns/capa/";
            //    img_capa.Visible = false;

            //    Upload.deletaImagem(Session[GaleriaFotos.Session.imgCapa].ToString(), GaleriaFotos.pathCapa);

            //    Session[GaleriaFotos.Session.imgCapa] = "";
            //    btn_apagarImagem.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Se não existir, Album novo
            if (!Utils.existeSession(GaleriaFotos.Session.album))
            {
                /*
                // se não tiver capa na session
                if (!Utils.existeSession(GaleriaFotos.Session.imgCapa))
                {
                    //erro;
                    Utils.showMsg(this, "É necessário inserir uma capa no álbum!");
                }
                else // se tiver
                {
                 */
                var alb = new Album
                    {
                        id_categoria = Convert.ToInt32(ddl_categoria.SelectedValue),
                        album = txt_titulo.Text,
                        descricao = txt_descricao.Text,
                        ordem = txt_ordem.Text,
                        ano= txt_ano.Text
                    };
                //alb.capa = Session[GaleriaFotos.Session.imgCapa].ToString();
                //Session[GaleriaFotos.Session.imgCapa] = "";

                alb.incluir();

                var a = Album.pegaDadosPeloTitulo(alb.album, alb.descricao);
                Session[GaleriaFotos.Session.album] = a;

                var di = new DirectoryInfo(GaleriaFotos.pathFotos + a.id_album);
                if (!di.Exists)
                    Directory.CreateDirectory(GaleriaFotos.pathFotos + a.id_album);

                var dit = new DirectoryInfo(GaleriaFotos.pathThumbs + a.id_album);
                if (!dit.Exists)
                    Directory.CreateDirectory(GaleriaFotos.pathThumbs + a.id_album);

                Response.Redirect("album_fotos.aspx?msg=Álbum incluído com sucesso!");
                //}
            }
            //Senão é alteração de album
            else
            {
                // se não tiver capa na session
                //if (!Utils.existeSession(GaleriaFotos.Session.imgCapa))
                //{
                //erro;
                //    Utils.showMsg(this, "É necessário inserir uma capa no álbum!");
                //}
                //else // se tiver
                //{
                var alb = (Album)Session[GaleriaFotos.Session.album];
                alb.id_categoria = Convert.ToInt32(ddl_categoria.SelectedValue);
                alb.album = txt_titulo.Text;
                alb.descricao = txt_descricao.Text;
                alb.ordem = txt_ordem.Text;
                alb.ano = txt_ano.Text;
                //alb.capa = Session[GaleriaFotos.Session.imgCapa].ToString();
                //Session[GaleriaFotos.Session.imgCapa] = "";

                alb.alterar();
                Response.Redirect("album.aspx?msg=Album alterado com sucesso!");
            }
        }
    }
}
