<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="campeonato-federados.aspx.cs" Inherits="LigaPaulista.Site.Admin.campeonato_federados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Federados e Confederados</h2>
    <fieldset>
        <legend>Grupos
            <asp:Label ID="lblModalidade" runat="server" /></legend>
        <h3>
            <asp:Label ID="lbltitulo" Text="" runat="server"></asp:Label></h3>

        <div>
            <label>Entidade:</label>
            <asp:DropDownList runat="server" ID="DdlEntidade" OnSelectedIndexChanged="DdlEntidade_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </div>
        <div>
            <label>Atletas:</label>
            <asp:DropDownList runat="server" ID="DdlAtletas">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button runat="server" ID="BtnSalvar" Text="Inserir" OnClick="BtnSalvar_Click" />
        </div>
    </fieldset>
    <div>
        <dxwgv:ASPxGridView ID="Grid1" runat="server" AutoGenerateColumns="False" ClientInstanceName="Grid" KeyFieldName="ID" DataSourceID="SqlModalidades">
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowDeleteButton="true"/>
                <dxwgv:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="NOME" SortOrder="Ascending" VisibleIndex="3" Caption="Atleta">
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <SettingsCommandButton>
                <DeleteButton Text="Remover"/>
            </SettingsCommandButton>
        </dxwgv:ASPxGridView>
        <asp:SqlDataSource ID="SqlModalidades" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            DeleteCommand="DELETE FROM [CAMPEONATOS_FEDERADOS] WHERE [ID] = @ID"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID], NOME = (e.entidade + ' | ' + NOME + ' ' + SOBRENOME + ' | RG: ' + cast(RG as varchar(255))) FROM [CAMPEONATOS_FEDERADOS] cf join CADASTRO c on c.ID_CADASTRO = cf.ID_CADASTRO join ENTIDADES e on e.ID_ENTIDADE = c.FACULDADE WHERE ID_CAMPEONATO = @ID_CAMPEONATO order by c.Nome">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter QueryStringField="id_campeonato" Name="ID_CAMPEONATO" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
