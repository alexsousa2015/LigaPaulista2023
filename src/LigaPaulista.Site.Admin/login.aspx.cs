using System;
using Formula;
using Formula.Ferramentas;

namespace LigaPaulista.Site.Admin
{
    public partial class login : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["logout"]))
                if (Convert.ToBoolean(Request["logout"]))
                    LoginAdm.encerrarSessao();
        }

        protected void ProcessLogin(object sender, EventArgs e)
        {
            var x = LoginAdm.Logar(txtUser.Text, txtPassword.Text);

            if (LoginAdm.Logar(txtUser.Text, txtPassword.Text))
                Response.Redirect("default.aspx");
            else
                ErrorMessage.InnerHtml = "Usuário ou senha inválidos. Tente novamente! "+ x;
        }

        protected bool TestaConexao()
        {
            //Sql.Conexao.strConexao
            return true;
        }
    }
}
