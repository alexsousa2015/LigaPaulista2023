using System;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Formula.Imagens;
using ImageModify = System.Drawing.Image;
using Formula;
using LigaPaulista.Core;

namespace LigaPaulista.Site.Admin
{
    public partial class album_fotos : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Login.validarLoginAdm();
            Server.ScriptTimeout = 5000;
            if (!Page.IsPostBack)
            {
                if (Utils.existeSession(GaleriaFotos.Session.album))
                {
                    lbl_album.Text = ((Album)Session[GaleriaFotos.Session.album]).album;
                    lbl_descricao.Text = ((Album)Session[GaleriaFotos.Session.album]).descricao;
                    lbl_categoria.Text = Categoria.retornaNome(((Album)Session[GaleriaFotos.Session.album]).id_categoria);

                    Panel2.Visible = false;

                    string msg = Request["msg"];
                    if (msg != "" && msg != null)
                        Utils.showMsg(this, msg);
                }
                else
                    Response.Redirect("album_categoria.aspx");
            }
        }

        protected void btn_addFoto_Click(object sender, EventArgs e)
        {
            var a = ((Album) Session[GaleriaFotos.Session.album]).id_album;

            var di = new DirectoryInfo(GaleriaFotos.pathFotos + a);
            if (!di.Exists)
                Directory.CreateDirectory(GaleriaFotos.pathFotos + a);

            var dit = new DirectoryInfo(GaleriaFotos.pathThumbs + a);
            if (!dit.Exists)
                Directory.CreateDirectory(GaleriaFotos.pathThumbs + a);
            
            incluirFoto(FileUpload1, Image1);
            incluirFoto(FileUpload2, Image2);
            incluirFoto(FileUpload3, Image3);
            incluirFoto(FileUpload4, Image4);
            incluirFoto(FileUpload5, Image5);

            confirmarFotos();

        }

        private void confirmarFotos()
        {
            var id = ((Album)Session[GaleriaFotos.Session.album]).id_album;

            Panel1.Visible = false;
            Panel2.Visible = true;

            if (Utils.existeSession("FileUpload1"))
            {
                Image1.ImageUrl = "http://www.ligaabc.com.br/album/fotos/thumbs/" + id + "/" + Session["FileUpload1"];
                Image1.Visible = true;
                TextBox1.Visible = true;
                ImageButton1.Visible = true;
                Label1.Text = Session["FileUpload1"].ToString();
            }
            if (Utils.existeSession("FileUpload2"))
            {
                Image2.ImageUrl = "http://www.ligaabc.com.br/album/fotos/thumbs/" + id + "/" + Session["FileUpload2"];
                Image2.Visible = true;
                TextBox2.Visible = true;
                ImageButton2.Visible = true;
                Label2.Text = Session["FileUpload2"].ToString();
            }
            if (Utils.existeSession("FileUpload3"))
            {
                Image3.ImageUrl = "http://www.ligaabc.com.br/album/fotos/thumbs/" + id + "/" + Session["FileUpload3"];
                Image3.Visible = true;
                TextBox3.Visible = true;
                ImageButton3.Visible = true;
                Label3.Text = Session["FileUpload3"].ToString();
            }
            if (Utils.existeSession("FileUpload4"))
            {
                Image4.ImageUrl = "http://www.ligaabc.com.br/album/fotos/thumbs/" + id + "/" + Session["FileUpload4"];
                Image4.Visible = true;
                TextBox4.Visible = true;
                ImageButton4.Visible = true;
                Label4.Text = Session["FileUpload4"].ToString();
            }
            if (Utils.existeSession("FileUpload5"))
            {
                Image5.ImageUrl = "http://www.ligaabc.com.br/album/fotos/thumbs/" + id + "/" + Session["FileUpload5"];
                Image5.Visible = true;
                TextBox5.Visible = true;
                ImageButton5.Visible = true;
                Label5.Text = Session["FileUpload5"].ToString();
            }
        }

        public void incluirFoto(FileUpload upl_imagem, Image img_album)
        {
            var id = ((Album)Session[GaleriaFotos.Session.album]).id_album;
            if (upl_imagem.HasFile && Upload.verificaExtensao(upl_imagem.FileName, ".jpg") == false)
                Utils.showMsg(this, "Por favor, selecione uma foto no formato \".jpg\"");
            else// se tiver foto
            {
                // se não tiver foto
                //if (!upl_imagem.HasFile)
                //Utils.showMsg(this, "Selecione uma foto para incluir!");
                if (upl_imagem.HasFile)
                {
                    // upa o arquivo
                    string filename = Upload.salvaArquivo(upl_imagem, GaleriaFotos.pathTemp);

                    var imgPhoto = ImageModify.FromFile(GaleriaFotos.pathTemp + filename);
                    GC.Collect();

                    int largura = imgPhoto.Width;
                    int altura = imgPhoto.Height;

                    int tamanhoL = 400;
                    int tamanhoA = 385;

                    if (largura > altura)//foto paisagem
                    {
                        imgPhoto = ImageResize.ConstrainProportions(imgPhoto, tamanhoL, ImageResize.Dimensions.Width);
                        imgPhoto.Save(GaleriaFotos.pathFotos + id + "/" + filename, ImageFormat.Jpeg);

                        imgPhoto = ImageResize.Crop(imgPhoto, 129, 97, ImageResize.AnchorPosition.Center);
                        imgPhoto.Save(GaleriaFotos.pathThumbs + id + "/" + filename, ImageFormat.Jpeg);
                    }
                    else//foto retrato
                    {
                        imgPhoto = ImageResize.ConstrainProportions(imgPhoto, tamanhoA, ImageResize.Dimensions.Height);
                        imgPhoto.Save(GaleriaFotos.pathFotos + id + "/" + filename, ImageFormat.Jpeg);

                        imgPhoto = ImageResize.ConstrainProportions(imgPhoto, 97, ImageResize.Dimensions.Height);
                        imgPhoto.Save(GaleriaFotos.pathThumbs + id + "/" + filename, ImageFormat.Jpeg);
                    }
                    //129 x 97

                    imgPhoto.Dispose();
                    Session[upl_imagem.ID] = filename;
                }
            }

        }

        protected void btn_apagarImagem_Click(object sender, ImageClickEventArgs e)
        {
            var id = ((Album)Session[GaleriaFotos.Session.album]).id_album;
            int id_foto = Convert.ToInt32(((ImageButton)sender).CommandArgument);

            switch (id_foto)
            {
                case 1:
                    Image1.ImageUrl = "../../album/fotos/thumbs/" + id + "/";
                    Image1.Visible = false;
                    TextBox1.Visible = false;
                    ImageButton1.Visible = false;

                    Upload.deletaImagem(Session["FileUpload1"].ToString(), GaleriaFotos.pathFotos + id + "/");
                    Upload.deletaImagem(Session["FileUpload1"].ToString(), GaleriaFotos.pathThumbs + id + "/");
                    Session["FileUpload1"] = "";
                    break;
                case 2:
                    Image2.ImageUrl = "../../album/fotos/thumbs/" + id + "/";
                    Image2.Visible = false;
                    TextBox2.Visible = false;
                    ImageButton2.Visible = false;

                    Upload.deletaImagem(Session["FileUpload2"].ToString(), GaleriaFotos.pathFotos + id + "/");
                    Upload.deletaImagem(Session["FileUpload2"].ToString(), GaleriaFotos.pathThumbs + id + "/");
                    Session["FileUpload2"] = "";
                    break;
                case 3:
                    Image3.ImageUrl = "../../album/fotos/thumbs/" + id + "/";
                    Image3.Visible = false;
                    TextBox3.Visible = false;
                    ImageButton3.Visible = false;

                    Upload.deletaImagem(Session["FileUpload3"].ToString(), GaleriaFotos.pathFotos + id + "/");
                    Upload.deletaImagem(Session["FileUpload3"].ToString(), GaleriaFotos.pathThumbs + id + "/");
                    Session["FileUpload3"] = "";
                    break;
                case 4:
                    Image4.ImageUrl = "../../album/fotos/thumbs/" + id + "/";
                    Image4.Visible = false;
                    TextBox4.Visible = false;
                    ImageButton4.Visible = false;

                    Upload.deletaImagem(Session["FileUpload4"].ToString(), GaleriaFotos.pathFotos + id + "/");
                    Upload.deletaImagem(Session["FileUpload4"].ToString(), GaleriaFotos.pathThumbs + id + "/");
                    Session["FileUpload4"] = "";
                    break;
                case 5:
                    Image5.ImageUrl = "../../album/fotos/thumbs/" + id + "/";
                    Image5.Visible = false;
                    TextBox5.Visible = false;
                    ImageButton5.Visible = false;

                    Upload.deletaImagem(Session["FileUpload5"].ToString(), GaleriaFotos.pathFotos + id + "/");
                    Upload.deletaImagem(Session["FileUpload5"].ToString(), GaleriaFotos.pathThumbs + id + "/");
                    Session["FileUpload5"] = "";
                    break;
            }
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (Utils.existeSession(GaleriaFotos.Session.album))
            {
                int id_album = ((Album)Session[GaleriaFotos.Session.album]).id_album;
                Foto fot = new Foto();

                if (Utils.existeSession("FileUpload1"))
                {
                    fot.id_album = id_album;
                    fot.foto = Session["FileUpload1"].ToString();
                    fot.descricao = TextBox1.Text;

                    fot.incluir();
                    Session["FileUpload1"] = "";
                }

                if (Utils.existeSession("FileUpload2"))
                {
                    fot.id_album = id_album;
                    fot.foto = Session["FileUpload2"].ToString();
                    fot.descricao = TextBox2.Text;

                    fot.incluir();
                    Session["FileUpload2"] = "";
                }

                if (Utils.existeSession("FileUpload3"))
                {
                    fot.id_album = id_album;
                    fot.foto = Session["FileUpload3"].ToString();
                    fot.descricao = TextBox3.Text;

                    fot.incluir();
                    Session["FileUpload3"] = "";
                }

                if (Utils.existeSession("FileUpload4"))
                {
                    fot.id_album = id_album;
                    fot.foto = Session["FileUpload4"].ToString();
                    fot.descricao = TextBox4.Text;

                    fot.incluir();
                    Session["FileUpload4"] = "";
                }

                if (Utils.existeSession("FileUpload5"))
                {
                    fot.id_album = id_album;
                    fot.foto = Session["FileUpload5"].ToString();
                    fot.descricao = TextBox5.Text;

                    fot.incluir();
                    Session["FileUpload5"] = "";
                }

                Response.Redirect("album_fotos.aspx?msg=Fotos incluídas com sucesso!&id=" + id_album);
            }
            else
                Response.Redirect("album_categoria.aspx?msg=Sessão do álbum foi expirada! Tente novamente!");
        }
    }
}
