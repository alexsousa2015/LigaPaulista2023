using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaPaulista.Site.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            var sql = new Sql(string.Format(@"insert into CADASTRO (NOME, SOBRENOME, EMAIL, TELEFONE, CELULAR, NASC, IDADE, SEXO, CIVIL, ENDERECO, NUMERO, COMPLEMENTO, BAIRRO, CEP, CIDADE, ESTADO, PAIS, CPF, RG, TITULO, FACULDADE, ORIGEM, DATA, SENHA, FOTO)
                values ('{0}', '{1}', '{2}', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', {3}, 'cadastro-simples', getdate(), 'null@%$', '-')"
                , TxtNome.Text, TxtSobrenome.Text, TxtEmail.Text, ddlEntidade.SelectedItem.Value));
            sql.query();

            Literal1.Text = "Atleta " + TxtNome.Text + " da Entidade " + ddlEntidade.SelectedItem.Value + " cadastrado com sucesso!";

            TxtNome.Text = "";
            TxtSobrenome.Text = "";
            TxtEmail.Text = "";
            ddlEntidade.SelectedIndex = -1;

        }
    }
}