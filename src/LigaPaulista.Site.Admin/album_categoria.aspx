<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="True" CodeBehind="album_categoria.aspx.cs" Inherits="LigaPaulista.Site.Admin.album_categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
        <fieldset>
            <legend>Incluir Categorias - Álbuns</legend>
            <div class="required">
                <label for="txt_categoria">
                    Categoria:</label>
                <asp:TextBox ID="txt_categoria" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
            </div>
        </fieldset>
        <fieldset>
            <asp:Button ID="Button1" runat="server" Text="Incluir" OnClick="Button1_Click" ValidationGroup="val_categoria" />
        </fieldset>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <fieldset>
            <legend>Alterar Categorias - Álbuns</legend>
            <div class="required">
                <label for="txt_categoria">
                    Categoria:</label>
                <asp:TextBox ID="txt_catAlterar" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
            </div>
        </fieldset>
        <fieldset>
            <asp:Button ID="Button2" runat="server" Text="Alterar" OnClick="Button2_Click" ValidationGroup="val_categoriaUpd" />
        </fieldset>
    </asp:Panel>
</asp:Content>
