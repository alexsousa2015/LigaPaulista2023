using System;
using DevExpress.Web;
using Formula;
using Formula.Ferramentas;

namespace LigaPaulista.Site.Admin
{
    public partial class Modalidades : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridModalidade_DataSelect(object sender, EventArgs e)
        {
            Session["id_modalidade"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        public void Grid2_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            int id,idm;
            var grid = (ASPxGridView)sender;
            id = Int32.Parse(grid.GetRowValues(e.VisibleIndex, "ID_CAMPEONATO").ToString());
            idm = Int32.Parse(grid.GetRowValues(e.VisibleIndex, "ID_MODALIDADE").ToString());

            if (e.ButtonID == "prox")
                ASPxWebControl.RedirectOnCallback("grupos.aspx?id_campeonato=" + id + "&id_modalidade=" + idm);

            if (e.ButtonID == "federados")
                ASPxWebControl.RedirectOnCallback("campeonato-federados.aspx?id_campeonato=" + id + "&id_modalidade=" + idm);
        }

        protected void CustomCallbackGrid(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "databind")
            {
                Grid1.DataBind();
            }
        }

    }
}
