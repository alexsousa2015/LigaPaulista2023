using Formula;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web.UI.WebControls;
using Formula.Data;

namespace LigaPaulista.Site.Admin
{
    public partial class jogos_ficha_tecnica : System.Web.UI.Page
    {
        public string idjogo { get; set; }
        public DateTime DtJogo { get; set; }
        public int IdModalidade { get; set; }
        public int IdCampeonato { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            idjogo = Request["idjogo"];

            //PREENCHER DADOS DO JOGO
            var sql = new Sql(@"SELECT J.DATA, J.HORA,
	                                J.PLACAR_TIME1, T1.ENTIDADE AS TIME1,
	                                J.PLACAR_TIME2, T2.ENTIDADE AS TIME2,
	                                L.LOCALIDADE,
	                                G.GRUPO,
	                                M.MODALIDADE,
	                                C.NOME AS CAMPEONATO,
                                    SUMULA,
                                    J.ID_MODALIDADE,
                                    J.ID_CAMPEONATO
                                FROM [dbo].[JOGOS] J
	                                JOIN [dbo].[ENTIDADES] T1 ON T1.ID_ENTIDADE = J.TIME1
	                                JOIN [dbo].[ENTIDADES] T2 ON T2.ID_ENTIDADE = J.TIME2
	                                JOIN [dbo].[LOCALIDADES] L ON L.ID_LOCALIDADE = J.ID_LOCALIDADE
	                                JOIN [dbo].[GRUPOS] G ON G.ID_GRUPO = J.ID_GRUPO
	                                JOIN [dbo].[MODALIDADES] M ON M.ID_MODALIDADE = J.ID_MODALIDADE
	                                JOIN [dbo].[CAMPEONATOS] C ON C.ID_CAMPEONATO = J.ID_CAMPEONATO
                                WHERE J.ID_JOGO = " + idjogo);

            var dr = sql.queryDataRow();
            if(dr != null)
            {
                txtJogo.Text = dr["time1"] + " " + dr["placar_time1"] + " x " + dr["placar_time2"] + " " + dr["time2"];
                txtLocal.Text = Convert.ToDateTime(dr["data"]).ToShortDateString() + " " + dr["hora"] + " - " + dr["localidade"];
                txtCampeonato.Text = dr["modalidade"] + " | " + dr["campeonato"];
                txtGrupo.Text = dr["grupo"].ToString();
                IdModalidade = dr["ID_MODALIDADE"].ToInt();
                IdCampeonato = dr["ID_CAMPEONATO"].ToInt();

                string strDtJogo = dr["DATA"].DefaultDbNull<DateTime>(DateTime.Now).ToString("d").Substring(0, 10);
                string strHrJogo = dr["HORA"].DefaultDbNull<string>("00:00").Substring(0);

                DtJogo = string.Concat(strDtJogo, " ", strHrJogo).ToDateTime();

                if(!string.IsNullOrEmpty(dr["SUMULA"].ToString()))
                {
                    TxtSumula.Text = "<a href='http://ligapaulista.com/ligapaulista/downloads/" + dr["SUMULA"] + "' target='_blank'>Ver Sumula</a>";
                }
            }

            if(!IsPostBack)
            {
                //PREENCHER COMBO DE EQUIPES
                PreencherEquipes();

                //PREENCHER COMBO DE OCORRENCIAS
                ddlOcorrencia.DataSource = new Sql(string.Format(@"SELECT IDEVENTO, DESCRICAO FROM [dbo].[FICHATECNICA_EVENTOS]", 0)).queryDs();
                ddlOcorrencia.DataValueField = "IDEVENTO";
                ddlOcorrencia.DataTextField = "DESCRICAO";
                ddlOcorrencia.DataBind();
            }
        }

        private void PreencherEquipes()
        {
            //PREENCHER COMBO DE EQUIPES
            ddlEquipe.DataSource = new Sql(string.Format(@"SELECT DISTINCT
	                                            E.ID_ENTIDADE, E.ENTIDADE
                                            FROM [dbo].[ENTIDADES] E
	                                            JOIN [dbo].[JOGOS] J1 ON J1.TIME1 = E.ID_ENTIDADE
                                            WHERE J1.ID_JOGO = {0}

											UNION ALL

											SELECT DISTINCT
	                                            E.ID_ENTIDADE, E.ENTIDADE
                                            FROM [dbo].[ENTIDADES] E
	                                            JOIN [dbo].[JOGOS] J1 ON J1.TIME2 = E.ID_ENTIDADE
                                            WHERE J1.ID_JOGO = {0}", idjogo)).queryDs();
            ddlEquipe.DataValueField = "ID_ENTIDADE";
            ddlEquipe.DataTextField = "ENTIDADE";
            ddlEquipe.DataBind();

            ddlEquipe.Items.Insert(0, new ListItem("Selecione...", ""));

        }

        protected void ddlAtleta_SelectedIndexChanged(object sender, EventArgs e)
        {
            var identidade = ((DropDownList)sender).SelectedItem.Value;
            if(!string.IsNullOrEmpty(identidade))
            {
                //PREENCHER COMBO DE ATLETAS
                ddlAtleta.DataSource = new Sql(string.Format(@"SELECT ID_CADASTRO, (NOME + ' ' + SOBRENOME) AS NOMECOMPLETO
                                                FROM [dbo].[CADASTRO]
                                                WHERE FACULDADE = {0} AND (ORIGEM = '1' OR ORIGEM = 'cadastro-simples')
                                                ORDER BY (NOME + ' ' + SOBRENOME)", identidade)).queryDs();
                ddlAtleta.DataValueField = "ID_CADASTRO";
                ddlAtleta.DataTextField = "NOMECOMPLETO";
                ddlAtleta.DataBind();

                ddlAtleta.Items.Insert(0, new ListItem("Selecione...", ""));
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            TxtQtd.Text = (TxtQtd.Text.ToInt() == 0 ? 1 : TxtQtd.Text.ToInt()).ToString();
            var sql = new Sql(string.Format(@"insert into [JOGOFICHATECNICA] (ID_JOGO, IDEVENTO, ID_CADASTRO, PONTOS)
                                values ({0}, {1}, {2}, {3})"
                , idjogo, ddlOcorrencia.SelectedItem.Value, ddlAtleta.SelectedItem.Value, TxtQtd.Text));
            sql.query();

            GravarCartoesAtletas();

            TxtQtd.Text = "";
            ddlEquipe.SelectedIndex = 0;
            ddlAtleta.SelectedIndex = 0;
            ddlOcorrencia.SelectedIndex = 0;

            Grid.DataBind();
        }

        protected void BtnSalvarParcial_Click(object sender, EventArgs e)
        {
            var sql = new Sql(string.Format(@"insert into [JOGOS_PARCIAIS] (ID_JOGO, TIME1, TIME2) values ({0}, {1}, {2})"
                , idjogo, TextBox1.Text, TextBox2.Text));
            sql.query();

            TextBox1.Text = "";
            TextBox2.Text = "";
            GridParcial.DataBind();
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(idjogo))
            {
                //var arquivo = Server.MapPath(@"..\ligapaulista\downloads\");
                var arquivo = ConfigurationManager.AppSettings["LigaPaulistaPath"] + @"downloads\";

                if(fuplArquivo.HasFile && Upload.VerificaExtensoes(fuplArquivo.FileName, ".zip", ".doc", ".pdf", ".jpg") == false)
                {
                    Utils.showMsg(this, "Favor incluir arquivo nos formatos \'.zip\',\'.doc\', \'.pdf\' ou \'.jpg\'");
                }
                else
                {
                    if(!fuplArquivo.HasFile)
                        Utils.showMsg(this, "Selecione um arquivo válido!");
                    else if(fuplArquivo.HasFile)
                    {
                        var filename = Upload.salvaArquivo(fuplArquivo, arquivo);

                        var sql = new Sql(string.Format(@"update jogos set sumula = '{0}' where id_jogo = {1}", filename, idjogo));
                        sql.query();

                        Utils.showMsg(this, "Arquivo cadastrado com sucesso!");
                        Utils.Refresh(this);
                    }
                }
            }
            else
            {
                Utils.showMsg(this, "Não foi possivel incluir arquivo, contate o administrador!");
            }
        }

        protected void GravarCartoesAtletas()
        {
            if(ddlOcorrencia.SelectedItem.Value.ToInt() != (int)Cartao.Amarelo &&
                ddlOcorrencia.SelectedItem.Value.ToInt() != (int)Cartao.Vermelho)
                return;

            int idAtleta = ddlAtleta.SelectedItem.Value.ToInt();
            DataTable cartoesAtletas = VerificaCartoresAtleta(idAtleta);
            DateTime? dtCartaoAmarelo1 = null;
            DateTime? dtCartaoAmarelo2 = null;
            DateTime? dtCartaoVermelho = null;

            if(cartoesAtletas.Rows.Count == 0)
            {
                switch(ddlOcorrencia.SelectedItem.Value.ToInt())
                {
                    case (int)Cartao.Amarelo:
                        dtCartaoAmarelo1 = DtJogo;
                        break;
                    case (int)Cartao.Vermelho:
                        dtCartaoVermelho = DtJogo;
                        break;
                }
                var sql = new Sql($@"INSERT INTO [JOGOS_CARTOES_ATLETAS] ([ID_MODALIDADE], [ID_CAMPEONATO], [ID_CADASTRO], 
                                                 [DT_CARTAO_AMARELO_1], [DT_CARTAO_AMARELO_2], [DT_CARTAO_VERMELHO])
                              values ({IdModalidade}, {IdCampeonato}, {idAtleta}, 
                                      {DateTimeToSQLString(dtCartaoAmarelo1)}, 
                                      {DateTimeToSQLString(dtCartaoAmarelo2)}, 
                                      {DateTimeToSQLString(dtCartaoVermelho)})");
                sql.query();
            }
            else
            {
                int idCartoesAtletas = cartoesAtletas.Rows[0]["ID_CARTOESATLETAS"].ToInt();
                dtCartaoAmarelo1 = cartoesAtletas.Rows[0]["DT_CARTAO_AMARELO_1"].DefaultDbNull<DateTime?>(null);
                dtCartaoAmarelo2 = cartoesAtletas.Rows[0]["DT_CARTAO_AMARELO_2"].DefaultDbNull<DateTime?>(null);
                dtCartaoVermelho = cartoesAtletas.Rows[0]["DT_CARTAO_VERMELHO"].DefaultDbNull<DateTime?>(null);

                var sql = new Sql($@"UPDATE [JOGOS_CARTOES_ATLETAS]
                                  SET [DT_CARTAO_AMARELO_1] = {DateTimeToSQLString(dtCartaoAmarelo1)}, 
                                      [DT_CARTAO_AMARELO_2] = {DateTimeToSQLString(dtCartaoAmarelo2)}, 
                                      [DT_CARTAO_VERMELHO]  = {DateTimeToSQLString(dtCartaoVermelho)} 
                                  WHERE ID_CARTOESATLETAS   = {idCartoesAtletas};");
                sql.query();
            }
        }

        private DataTable VerificaCartoresAtleta(int idAtleta)
        {
            int idOcorrencia = ddlOcorrencia.SelectedItem.Value.ToInt();
            var sql = new Sql($@"SELECT TOP 1 ID_CARTOESATLETAS, DT_CARTAO_AMARELO_1, DT_CARTAO_AMARELO_2, DT_CARTAO_VERMELHO
                                 FROM JOGOS_CARTOES_ATLETAS
                                 WHERE ID_MODALIDADE = {IdModalidade} AND 
                                       ID_CAMPEONATO = {IdCampeonato} AND 
                                       ID_CADASTRO   = {idAtleta} AND 
                                       ((DT_CARTAO_AMARELO_2 IS NULL AND 4 = {idOcorrencia}) OR 
                                        (DT_CARTAO_VERMELHO  IS NULL AND 5 = {idOcorrencia}))
                                 ORDER BY ID_CARTOESATLETAS DESC");

            var cartoes = sql.queryDataTable();
            return AtualizaColunas(cartoes);
        }

        private enum Cartao
        {
            Amarelo = 4,
            Vermelho = 5
        }

        private DataTable AtualizaColunas(DataTable cartoes)
        {
            int idOcorrencia = ddlOcorrencia.SelectedItem.Value.ToInt();
            for(int i = 0; i < cartoes.Rows.Count; i++)
            {
                foreach(DataColumn column in cartoes.Columns)
                {
                    if(cartoes.Rows[i][column.ColumnName] != DBNull.Value) continue;
                    switch(idOcorrencia)
                    {
                        case (int)Cartao.Amarelo:
                            if(new[] { "DT_CARTAO_AMARELO_1", "DT_CARTAO_AMARELO_2" }.Contains(column.ColumnName))
                            {
                                cartoes.Rows[i][column.ColumnName] = DtJogo;
                                return cartoes;
                            }
                            break;
                        case (int)Cartao.Vermelho:
                            if(new[] { "DT_CARTAO_VERMELHO" }.Contains(column.ColumnName))
                            {
                                cartoes.Rows[i][column.ColumnName] = DtJogo;
                                return cartoes;
                            }
                            break;
                    }
                }
            }
            cartoes.Reset();
            return cartoes;
        }
        private string DateTimeToSQLString(DateTime? value)
        {
            string result;
            if(value == null)
                result = "null";
            else
            {
                DateTime dtResult = (DateTime)value;
                result = "'" + dtResult.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            return result;
        }
    }
    public static class MyExtensions
    {
        public static T DefaultDbNull<T>(this Object value, object defaultValue)
        {
            if(value == Convert.DBNull || value == null)
                return (T)defaultValue;
            return (T)value;
        }
    }
}