using System;
using DevExpress.Web;
using Formula.Ferramentas;

namespace LigaPaulista.Site.Admin
{
    public partial class pedidos_carteirinhas : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ASPxGridView1.DataBind();
            //ASPxGridView1.DetailRows.ExpandAllRows();
        }

        protected void gridModalidade_DataSelect(object sender, EventArgs e)
        {
            Session["IDPEDIDO"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void ExportarDados(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse(true);
        }

        protected void ASPxGridView1_DataBound(object sender, System.EventArgs e)
        {
            //ASPxGridView grid = (ASPxGridView)sender;
            //grid.DetailRows.ExpandRow(e.VisibleIndex);
            //((ASPxGridView)sender).DetailRows.ExpandAllRows();
            //((ASPxGridView)sender).SettingsDetail.ShowDetailButtons = false;
        }
    }
}