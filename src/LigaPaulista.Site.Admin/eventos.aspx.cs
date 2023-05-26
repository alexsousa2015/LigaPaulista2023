using System;
using DevExpress.Web;
using Formula.Ferramentas;

namespace LigaPaulista.Site.Admin
{
    public partial class eventos : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridModalidade_DataSelect(object sender, EventArgs e)
        {
            Session["IDEVENTO"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}