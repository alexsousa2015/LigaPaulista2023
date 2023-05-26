using System;
using System.Drawing;
using Formula;
using Formula.Data;
using Formula.Ferramentas;
//using Formula.Imagens;
using LigaPaulista.Core;
using LigaPaulista.Core.Campeonatos;
using LigaPaulista.Core.SDK.Utils;

namespace LigaPaulista.Site.Admin
{
    public partial class modalidade_manutencao : AdminTheme
    {
        private static string _nomefoto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]) && Request.QueryString["id"] != null)
                {
                    var id = Convert.ToInt32(Request.QueryString["id"]);
                    var modalidade = Modalidade.GetModalidadeById(id);
                    txtModalidade.Text = modalidade.Nome;
                    chkAtivo.Checked = modalidade.Ativo == 1;

                    imgFoto.ImageUrl = $@"../imagens/thumbs/{_nomefoto}";
                    if (!_nomefoto.IsNotNullOrEmpty())
                    {
                        imgFoto.ImageUrl = $@"../imagens/thumbs/{modalidade.Imagem}";
                        //imgFoto.ImageUrl = $@"../imagens/thumbs/{modalidade.RetornaModalidades(id).Tables[0].Rows[0].ItemArray[2].ToString()}";
                    }
                }
                else
                {
                    txtModalidade.Text = string.Empty;
                    fuplImagem = null;
                    imgFoto = null;
                    chkAtivo.Checked = true;
                }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && Request.QueryString["id"] != null)
            {
                var m = new Modalidade
                {
                    Nome = txtModalidade.Text,
                    IdModalidade = Convert.ToInt32(Request.QueryString["id"]),
                    Imagem = _nomefoto,
                    Ativo = chkAtivo.Checked ? 1 : 0,
                };

                m.AlteraModalidade();
                FechaTela();
            }
            else
            {
                var m = new Modalidade
                {
                    Nome = txtModalidade.Text,
                    Imagem = _nomefoto,
                    Ativo = chkAtivo.Checked ? 1 : 0,
                };

                m.CadastraModalidade();
                FechaTela();
            }
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            var temp = Server.MapPath(@"../imagens/temp/");
            var thumb = Server.MapPath(@"../imagens/thumbs/");

            if (fuplImagem.HasFile && Upload.VerificaExtensoes(fuplImagem.FileName, ".jpg", ".gif") == false)
            {
                Utils.showMsg(this, "favor incluir imagem no formato \".jpg\" ou \".gif\"");
            }
            else
            {
                if (!fuplImagem.HasFile)
                    Utils.showMsg(this, "Selecione uma foto para incluir");
                else if (fuplImagem.HasFile)
                {
                    var filename = Upload.salvaArquivo(fuplImagem, temp);
                    Image foto = Image.FromFile(temp + filename);
                    foto = ImageResize.FixedSize(foto, 20, 20, Color.White);

                    try
                    {
                        ImageResize.SalvarJpeg(thumb + filename, foto, 100);
                    }
                    catch (Exception ex)
                    {
                        foto = new Bitmap(foto);
                        ImageResize.SalvarJpeg(thumb + filename, foto, 100);
                    }

                    //Upload.deletaImagem(temp + filename, temp);

                    imgFoto.ImageUrl = $@"../imagens/thumbs/{filename}";
                    _nomefoto = filename;
                }
            }
        }

        private void FechaTela()
        {
            _nomefoto = null;
            Utils.chamaJavaScript(this, "window.parent.Grid.PerformCallback('databind');");
            Utils.chamaJavaScript(this, "window.parent.aspxPopup.Hide();");
        }
    }
}
