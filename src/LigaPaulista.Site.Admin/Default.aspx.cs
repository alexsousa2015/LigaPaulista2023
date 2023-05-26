using System;
using Formula;
using Formula.Ferramentas;

namespace LigaPaulista.Site.Admin
{
    public partial class _Default : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginAdm.validarLogin();
        }
    }
}
