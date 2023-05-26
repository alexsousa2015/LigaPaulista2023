<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="album_fotos_lista.aspx.cs" Inherits="LigaPaulista.Site.Admin.album_fotos_lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <fieldset>
            <legend>Album - Alterar Legenda da Foto</legend><a name="alterar"></a>
            <div class="required">
                <span>Cód:</span>
                <asp:Label ID="lbl_id" runat="server"></asp:Label><br />
            </div>
            <div class="required">
                <label>
                    Legenda</label>
                <asp:TextBox ID="txt_legenda" runat="server"></asp:TextBox>
                <asp:Button ID="btn_alterar" runat="server" Text="Ok" OnClick="gravarLegenda" />
            </div>
            <div>
                <asp:Image ID="Image1" runat="server" />
            </div>
        </fieldset>
    </asp:Panel>
    <fieldset>
        <legend>Album - Listagem de Fotos</legend>
        <h3 class="nomeAlbum">
            <asp:Label runat="server" ID="lbl_nomeAlbum"></asp:Label>
        </h3>
        <asp:Repeater runat="server" ID="rpt_fotos">
            <ItemTemplate>
                <div class="foto">
                    <a href="http://www.ligaabc.com.br/album/fotos/<%# DataBinder.Eval(Container.DataItem, "[\"foto\"]")%>"
                        rel="lightbox">
                        <img src="http://www.ligaabc.com.br/album/fotos/<%# DataBinder.Eval(Container.DataItem, "[\"foto\"]")%>"
                            alt="<%# DataBinder.Eval(Container.DataItem, "[\"descricao\"]")%>" />
                    </a>
                    <p>
                        <%# DataBinder.Eval(Container.DataItem, "[\"descricao\"]")%>
                    </p>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Admin/Images/bt_excluir.gif"
                        OnClientClick="return confirm('Tem certeza que deseja excluir esta foto?');"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "[\"id_foto\"]")%>'
                        OnClick="apagarFoto" />
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/App_Themes/Admin/Images/edit_16.gif"
                        OnClick="alterarFoto" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "[\"id_foto\"]")%>'
                        CommandName='<%# DataBinder.Eval(Container.DataItem, "[\"descricao\"]")%>' AlternateText='<%# DataBinder.Eval(Container.DataItem, "[\"foto\"]")%>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
</asp:Content>
