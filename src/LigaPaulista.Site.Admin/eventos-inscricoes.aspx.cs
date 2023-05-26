using System;
using DevExpress.Data.Filtering;
using DevExpress.Web;
using Formula.Ferramentas;
using LigaPaulista.Core.Campeonatos;

namespace LigaPaulista.Site.Admin
{
    public partial class eventos_inscricoes : AdminTheme
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridModalidade_DataSelect(object sender, EventArgs e)
        {
            Session["IDINSCRICAO"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void ASPxGridView1_Init(object sender, EventArgs e)
        {
            var grid = sender as ASPxGridView;
            var column = grid.Columns["ANO"] as GridViewDataComboBoxColumn;
            var anos = Modalidade.RetornaAnosDocumentosModalidade();

            column.PropertiesComboBox.DataSource = anos;
        }
    }
}