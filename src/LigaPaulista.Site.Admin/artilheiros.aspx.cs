using System;
using Formula.Ferramentas;
using LigaPaulista.Core;

namespace LigaPaulista.Site.Admin
{
    public partial class adm_artilheiros : AdminTheme
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Artilharia.pegaPeriodo(ddl_periodo);
                ddl_periodo.SelectedIndex = 0;
                Session["ID_PERIODO"] = Convert.ToInt32(ddl_periodo.SelectedValue);
                gridArtilharia.DataBind();
            }
        }

        protected void ddl_periodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_PERIODO"] = Convert.ToInt32(ddl_periodo.SelectedValue);
            gridArtilharia.DataBind();
        }

        //protected void gridArtilharia_OnDataBound(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(Session["ID_PERIODO"].ToString()))
        //    {
        //        gridArtilharia.DataSource = sql_artilharia;
        //        gridArtilharia.DataBind();
        //    }
        //}
    }
}
