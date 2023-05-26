using System;
using Formula.Ferramentas;

namespace LigaPaulista.Site.Admin
{
    public partial class EntidadesAdm : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridEntidades_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["ATIVO"] = 1;
        }
    }
}
