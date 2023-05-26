using System;
using System.Configuration;
using Formula;
using Formula.Data;
using Formula.Ferramentas;
using LigaPaulista.Core;


namespace LigaPaulista.Site.Admin
{
    public partial class CalendarioFormulario : AdminTheme
    {
        private static int _idCalendario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]) && Request.QueryString["id"] != null)
                {
                    _idCalendario = Convert.ToInt32(Request.QueryString["id"]);
                    var calendario = new Calendario().GetCalendarioById(_idCalendario);
                    txtAno.Text = calendario.Ano.ToString();
                    txtTemporada.Text = calendario.Temporada;
                    LineFileName.Visible = true;
                    lblFileName.Text = calendario.NomeArquivo;
                }
                else
                {
                    _idCalendario = 0;
                    txtAno.Text = string.Empty;
                    txtTemporada.Text = string.Empty;
                    txtUploadCalendario = null;
                    LineFileName.Visible = false;
                    lblFileName.Text = null;
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_idCalendario > 0)
            {
                var c = new Calendario().GetCalendarioById(_idCalendario);

                c.Ano = txtAno.Text.ToInt();
                c.Temporada = txtTemporada.Text;
                if (txtUploadCalendario.HasFile)
                {
                    c.NomeArquivo = txtUploadCalendario.FileName;
                    c.GuidArquivo = UploadCalendarioFile();
                }
                c.AlteraCalendario();
                FechaTela();
            }
            else
            {
                var c = new Calendario
                {
                    Ano = txtAno.Text.ToInt(),
                    Temporada = txtTemporada.Text
                };
                if (txtUploadCalendario.HasFile)
                {
                    c.NomeArquivo = txtUploadCalendario.FileName;
                    c.GuidArquivo = UploadCalendarioFile();
                }
                c.CadastraCalendario();
                FechaTela();
            }}

        protected string UploadCalendarioFile()
        {
            var path = ConfigurationManager.AppSettings["LigPaulistaPath"] + @"downloads\calendarios\";
            return Upload.salvaArquivo(txtUploadCalendario, path);
        }

        private void FechaTela()
        {
            Utils.chamaJavaScript(this, "window.parent.Grid.PerformCallback('databind');");
            Utils.chamaJavaScript(this, "window.parent.aspxPopup.Hide();");
        }
    }
}
