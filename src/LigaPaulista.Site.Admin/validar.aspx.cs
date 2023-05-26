using System;
using Formula;

namespace LigaPaulista.Site.Admin
{
    public partial class validar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginAdm.validarLogin();

            var id = Request["id"];

            var sql = new Sql("update cadastro set origem = '1' where id_cadastro = " + id).query();
        }
    }
}