using System;
using Formula;

namespace LigaPaulista.Site.Admin
{
    public partial class Templates_Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginAdm.validarLogin();
        }
    }
}
