using System;
using System.Configuration;
using Formula;
using Formula.Ferramentas;
using LigaPaulista.Core.Campeonatos;

namespace LigaPaulista.Site.Admin
{
    public partial class Modalidade_arquivos : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && Request.QueryString["id"] != null)
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var ano = txtAno.Text;

                var arquivo = ConfigurationManager.AppSettings["LigPaulistaPath"] + @"downloads\";

                if (fuplArquivo.HasFile && Upload.VerificaExtensoes(fuplArquivo.FileName, ".zip", ".doc", ".pdf") == false)
                {
                    Utils.showMsg(this, "favor incluir arquivo nos formatos \'.zip\',\'.doc\' ou \'.pdf\'");
                }
                else
                {
                    if (!fuplArquivo.HasFile)
                        Utils.showMsg(this, "Selecione um arquivo válido!");
                    else if (fuplArquivo.HasFile)
                    {
                        var filename = Upload.salvaArquivo(fuplArquivo, arquivo);

                        Modalidade.CadastrarDocumentoModalidade(id, filename, GetNome(fuplArquivo.FileName), ano);
                        Utils.showMsg(this, "Arquivo cadastrado com sucesso!");
                        Utils.Refresh(this);
                    }
                }
            }
            else
            {
                Utils.showMsg(this, "Não foi possivel incluir arquivo, contate o administrador!");
            }
        }

        private static string GetNome(string nomecaminho)
        {
            return nomecaminho.Substring(nomecaminho.LastIndexOf('\\') + 1, nomecaminho.Substring(nomecaminho.LastIndexOf('\\') + 1).Length);
        }
    }
}
