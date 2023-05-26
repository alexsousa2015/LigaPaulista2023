using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Formula.Ferramentas;

namespace LigaPaulista.Site.Admin
{
    public partial class cadastro : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExportarDados(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(true);
        }
    }
}
