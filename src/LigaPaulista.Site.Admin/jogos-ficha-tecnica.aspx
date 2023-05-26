<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="jogos-ficha-tecnica.aspx.cs" Inherits="LigaPaulista.Site.Admin.jogos_ficha_tecnica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>
        <asp:Literal runat="server" ID="txtCampeonato" /></h2>
    <h3>
        <asp:Literal runat="server" ID="txtGrupo" /></h3>
    <p>
        <b>Jogo:</b>
        <asp:Literal runat="server" ID="txtJogo" /><br />
        <b>Data/hora/local:</b>
        <asp:Literal runat="server" ID="txtLocal" />
    </p>

    <fieldset style="width: 48%; float: left;">
        <legend>Ficha Técnica Online</legend>
        <table>
            <tr>
                <td width="100px">
                    <label>Equipe</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlEquipe" OnSelectedIndexChanged="ddlAtleta_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Atleta</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlAtleta">
                    </asp:DropDownList>
                    <a href="cadastro-simples.aspx" target="_blank">Cadastrar Novo</a>
                </td>
            </tr>
            <tr>
                <td><label>Ocorrência</label></td>
                <td><asp:DropDownList runat="server" ID="ddlOcorrencia"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><label>Quantidade</label></td>
                <td><asp:TextBox runat="server" ID="TxtQtd" /></td>
           </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button runat="server" ID="BtnSalvar" Text="Salvar" OnClick="BtnSalvar_Click" /></td>
            </tr>
        </table>
        <div>
            <dxwgv:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" KeyFieldName="ID_ITEM"
                DataSourceID="SqlTabela" ClientInstanceName="Grid" Width="100%" SettingsBehavior-AutoExpandAllGroups="true">
                <SettingsEditing Mode="Inline" />
                <SettingsText EmptyDataRow="Não há eventos na Ficha Técnica" />
                <Settings ShowGroupPanel="false" />
                <SettingsPager Mode="ShowAllRecords" />
                <Columns>
                    <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowDeleteButton="true" />
                    <dxwgv:GridViewDataTextColumn FieldName="ID_ITEM" VisibleIndex="1" ReadOnly="True" Caption="Código" Visible="false">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataComboBoxColumn FieldName="IDEVENTO" VisibleIndex="2" Caption="Ocorrência" GroupIndex="0">
                        <PropertiesComboBox DataSourceID="SqlOcorrencia" TextField="descricao" ValueField="idevento">
                        </PropertiesComboBox>
                    </dxwgv:GridViewDataComboBoxColumn>
                    <dxwgv:GridViewDataDateColumn FieldName="NOMECOMPLETO" Caption="Atleta" VisibleIndex="4">
                    </dxwgv:GridViewDataDateColumn>
                    <dxwgv:GridViewDataDateColumn FieldName="Entidade" VisibleIndex="5">
                    </dxwgv:GridViewDataDateColumn>
                    <dxwgv:GridViewDataDateColumn FieldName="PONTOS" Caption="Qtd" VisibleIndex="6">
                    </dxwgv:GridViewDataDateColumn>
                </Columns>
                <SettingsCommandButton>
                    <DeleteButton Text="Excluir" />
                </SettingsCommandButton>
            </dxwgv:ASPxGridView>
            <asp:SqlDataSource ID="SqlOcorrencia" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT idevento, descricao FROM [FICHATECNICA_EVENTOS]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlTabela" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT F.ID_ITEM, F.PONTOS, F.IDEVENTO
	                                    , NOMECOMPLETO = (C.NOME + ' ' + C.SOBRENOME), E.Entidade
                                    FROM [dbo].[JOGOFICHATECNICA] F
	                                    JOIN [dbo].[CADASTRO] C ON C.ID_CADASTRO = F.ID_CADASTRO
	                                    JOIN [dbo].[ENTIDADES] E ON E.ID_ENTIDADE = C.FACULDADE
                                    WHERE ID_JOGO = @idjogo"
                DeleteCommand="DELETE FROM JOGOFICHATECNICA WHERE ID_ITEM = @ID_ITEM">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="idjogo" Type="Int32" Name="idjogo" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="ID_ITEM" Type="Int32" />
                </DeleteParameters>
            </asp:SqlDataSource>
        </div>
    </fieldset>
    <fieldset style="width: 48%; float: left;">
        <legend>Parciais</legend>
        <div>
            <div>
                <label>Time 1</label>
                <asp:TextBox runat="server" ID="TextBox1" />
            </div>
            <div>
                <label>Time 2</label>
                <asp:TextBox runat="server" ID="TextBox2" />
            </div>
            <div>
                <asp:Button runat="server" ID="Button1" Text="Salvar" OnClick="BtnSalvarParcial_Click" />
            </div>
        </div>
        <div>
            <dxwgv:ASPxGridView ID="GridParcial" runat="server" AutoGenerateColumns="False" KeyFieldName="IDPARCIAL"
                DataSourceID="SqlParcial" ClientInstanceName="GridParcial" Width="100%" SettingsBehavior-AutoExpandAllGroups="true">
                <SettingsEditing Mode="Inline" />
                <SettingsText EmptyDataRow="Não há eventos na Ficha Técnica" />
                <Settings ShowGroupPanel="false" />
                <SettingsPager Mode="ShowAllRecords" />
                <Columns>
                    <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowDeleteButton="true" />
                    <dxwgv:GridViewDataTextColumn FieldName="IDPARCIAL" VisibleIndex="1" ReadOnly="True" Caption="Código" Visible="false">
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataDateColumn FieldName="TIME1" VisibleIndex="2">
                    </dxwgv:GridViewDataDateColumn>
                    <dxwgv:GridViewDataDateColumn FieldName="TIME2" VisibleIndex="3">
                    </dxwgv:GridViewDataDateColumn>
                </Columns>
                <SettingsCommandButton>
                    <DeleteButton Text="Excluir" />
                </SettingsCommandButton>
            </dxwgv:ASPxGridView>
            <asp:SqlDataSource ID="SqlParcial" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT IDPARCIAL, TIME1, TIME2
                                    FROM [dbo].[JOGOS_PARCIAIS] WHERE ID_JOGO = @idjogo ORDER BY IDPARCIAL"
                DeleteCommand="DELETE FROM JOGOS_PARCIAIS WHERE IDPARCIAL = @IDPARCIAL">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="idjogo" Type="Int32" Name="idjogo" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="IDPARCIAL" Type="Int32" />
                </DeleteParameters>
            </asp:SqlDataSource>
        </div>
    </fieldset>
    <fieldset style="width: 48%; float: left;">
        <legend>Upload da Súmula</legend>
        <asp:FileUpload ID="fuplArquivo" runat="server" /><br />
        <asp:Button ID="btnSubir" runat="server" Text="Subir Arquivo" OnClick="btnSubir_Click" />
        <br />
        <br />
        <asp:Literal runat="server" ID="TxtSumula"></asp:Literal>
    </fieldset>
</asp:Content>
