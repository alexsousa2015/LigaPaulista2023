using Formula;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaPaulista.Site.Admin
{
    public partial class export : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginAdm.validarLogin();

            int idpedido = Convert.ToInt32(Request["IDPEDIDO"]);
            string faculdade = new Sql(string.Format(@"select entidade from entidades where id_entidade = {0}", Utils.SqlInjectionPrevent(Request["entidade"]))).queryString();

            var sql = new Sql(string.Format(@"SELECT NOME = (C.NOME + ' ' + C.SOBRENOME), C.RG,
	E.ENTIDADE,
	P.ATLETA, P.FEDERADO, P.DIRIGENTE,P.CREF, P.IDPEDIDO
                            FROM [PEDIDOS_ATLETAS] P
                            JOIN dbo.CADASTRO C ON C.ID_CADASTRO = P.ID_CADASTRO
							JOIN [dbo].[ENTIDADES] E ON E.ID_ENTIDADE = C.FACULDADE
                            WHERE ([IDPEDIDO] = {0})", idpedido));

            DataTable dt = new DataTable();
            dt = sql.queryDs().Tables[0];

            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Default");
                ws.Cells["A1"].LoadFromDataTable(dt, true);

                pck.SaveAs(Response.OutputStream);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", string.Format("attachment;  filename=Entidade{1}-Pedido{0}.xlsx", idpedido, faculdade.Replace(" ","")));
            }

        }
    }
}