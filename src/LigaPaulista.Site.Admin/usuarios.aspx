<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" Inherits="LigaPaulista.Site.Admin.adm_usuarios" Codebehind="usuarios.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <fieldset>
        <legend>Usuários da Administração</legend>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="ID">
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True">
                </dxwgv:GridViewCommandColumn>
                <dxwgv:GridViewDataTextColumn Caption="C&#243;d." FieldName="ID" ReadOnly="True"
                    VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Login" FieldName="LOGIN" VisibleIndex="2">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Senha" FieldName="SENHA" VisibleIndex="3">
                    <PropertiesTextEdit Password="True">
                    </PropertiesTextEdit>
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <SettingsText CommandCancel="Cancelar" CommandDelete="Apagar" CommandEdit="Editar"
                CommandNew="Novo" CommandUpdate="Salvar" ConfirmDelete="Tem certeza que deseja excluir este usu&#225;rio?"
                EmptyDataRow="Adicione um usu&#225;rio para ter acesso a administra&#231;&#227;o." />
        </dxwgv:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        	ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            DeleteCommand="DELETE FROM [adm] WHERE [id] = @ID" InsertCommand="INSERT INTO [adm] ([login], [senha]) VALUES (@login, @senha)"
            SelectCommand="SELECT * FROM [adm] ORDER BY [login]" UpdateCommand="UPDATE [adm] SET [login] = @login, [senha] = @senha WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="login" Type="String" />
                <asp:Parameter Name="senha" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="login" Type="String" />
                <asp:Parameter Name="senha" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>

