<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="True" CodeBehind="album_add.aspx.cs" Inherits="LigaPaulista.Site.Admin.album_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<fieldset>
        <legend>Álbum - Incluir / Alterar</legend>
        <div class="required">
            <label for="ddl_categoria">
                Categoria:</label>
            <asp:DropDownList ID="ddl_categoria" runat="server">
            </asp:DropDownList>
        </div>
        <div class="required">
            <label for="txt_titulo">
                Titulo:</label>
            <asp:TextBox ID="txt_titulo" runat="server" Width="280px" MaxLength="50"></asp:TextBox>
        </div>
        <div class="required">
            <label for="txt_descricao">
                Descrição:</label>
            <asp:TextBox ID="txt_descricao" runat="server" Width="280px" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="required">
            <label for="txt_descricao">
                Ordem:</label>
            <asp:TextBox ID="txt_ordem" runat="server" Width="280px" MaxLength="3" ></asp:TextBox>
        </div>
        <div class="required">
            <label for="txt_ano">
                Ano:</label>
            <asp:TextBox ID="txt_ano" runat="server" Width="280px" MaxLength="4" ></asp:TextBox>
        </div>
        <div class="required" style="display: none;">
            <label for="upl_imagem">
                Capa do Álbum:</label>
            <asp:FileUpload ID="upl_imagem" runat="server"></asp:FileUpload>
            <asp:Button ID="btn_addFoto" runat="server" Text="Incluir Imagem" CausesValidation="False"
                OnClick="btn_addFoto_Click"></asp:Button>
            <div style="margin-top: 10px">
                <asp:Image ID="img_capa" runat="server" Visible="false"></asp:Image>
                <asp:ImageButton ID="btn_apagarImagem" runat="server" ImageUrl="~/adm/images/del_16.gif"
                    OnClick="btn_apagarImagem_Click" Visible="false" CausesValidation="false" />
            </div>
        </div>
    </fieldset>
    <fieldset>
        <asp:Button ID="Button1" runat="server" Text="Ok" ValidationGroup="valForm" OnClick="Button1_Click" />
    </fieldset>
</asp:Content>
