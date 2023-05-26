<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="True" CodeBehind="album_fotos.aspx.cs" Inherits="LigaPaulista.Site.Admin.album_fotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<fieldset>
        <legend>Álbum - Incluir Fotos</legend>
            <div class="required">
                <label for="txt_categoria">Categoria:</label>
                <asp:label runat="server" id="lbl_categoria" Text=""></asp:label>
            </div>
            
            <div class="required">
                <label for="txt_album">Album:</label>
                <asp:label runat="server" id="lbl_album" Text=""></asp:label>
            </div>
            
            <div class="required">
                <label for="lbl_descricao">Descrição:</label>
                <asp:label runat="server" id="lbl_descricao" Text=""></asp:label>
            </div>
    </fieldset>     
    
    <asp:Panel ID="Panel1" runat="server">
    <fieldset>
        <legend>Passo 1/2 - Selecionar as Fotos</legend>
            <div class="required">
                <label for="upl_imagem">Foto 1:</label>
                <asp:FileUpload id="FileUpload1" runat="server"></asp:FileUpload>
            </div>

            <div class="required">
                <label for="upl_imagem">Foto 2:</label>
                <asp:FileUpload id="FileUpload2" runat="server"></asp:FileUpload>
            </div>
            
            <div class="required">
                <label for="upl_imagem">Foto 3:</label>
                <asp:FileUpload id="FileUpload3" runat="server"></asp:FileUpload>
            </div>
            
            <div class="required">
                <label for="upl_imagem">Foto 4:</label>
                <asp:FileUpload id="FileUpload4" runat="server"></asp:FileUpload>
            </div>
            
            <div class="required">
                <label for="upl_imagem">Foto 5:</label>
                <asp:FileUpload id="FileUpload5" runat="server"></asp:FileUpload>
            </div>
        </fieldset>
        <fieldset>
            <asp:Button ID="Button1" runat="server" Text="Ok" OnClick="btn_addFoto_Click" />
        </fieldset>
        
    </asp:Panel>
    
    <asp:Panel ID="Panel2" runat="server">
        <fieldset>
            <legend>Passo 2/2 - Confirmar as Fotos</legend>
            
            <div class="required">
                <label for="TextBox1">Foto 1:</label>
                <asp:TextBox ID="TextBox1" runat="server" Visible="false" MaxLength="30"></asp:TextBox><br />
                <small><asp:Label runat="server" ID="Label1"></asp:Label></small>
                <div style="MARGIN-TOP: 10px">
                    <asp:Image id="Image1" runat="server" Visible="false"></asp:Image>
                    <asp:ImageButton ID="ImageButton1" runat="server" Visible="false" ImageUrl="~/App_Themes/Admin/images/del_16.gif" CommandArgument="1" OnClick="btn_apagarImagem_Click" CausesValidation="false" />
                </div>
            </div>
            
            <div class="required">
                <label for="TextBox2">Foto 2:</label>
                <asp:TextBox ID="TextBox2" runat="server" Visible="false" MaxLength="30"></asp:TextBox><br />
                <small><asp:Label runat="server" ID="Label2"></asp:Label></small>
                <div style="MARGIN-TOP: 10px">
                    <asp:Image id="Image2" runat="server" Visible="false"></asp:Image>
                    <asp:ImageButton ID="ImageButton2" runat="server" Visible="false" ImageUrl="~/App_Themes/Admin/images/del_16.gif" CommandArgument="2" OnClick="btn_apagarImagem_Click" CausesValidation="false" />
                </div>
            </div>
            
            <div class="required">
                <label for="TextBox3">Foto 3:</label>
                <asp:TextBox ID="TextBox3" runat="server" Visible="false" MaxLength="30"></asp:TextBox><br />
                <small><asp:Label runat="server" ID="Label3"></asp:Label></small>
                <div style="MARGIN-TOP: 10px">
                    <asp:Image id="Image3" runat="server" Visible="false"></asp:Image>
                    <asp:ImageButton ID="ImageButton3" runat="server" Visible="false" ImageUrl="~/App_Themes/Admin/images/del_16.gif" CommandArgument="3" OnClick="btn_apagarImagem_Click" CausesValidation="false" />
                </div>
            </div>
            
            <div class="required">
                <label for="TextBox4">Foto 4:</label>
                <asp:TextBox ID="TextBox4" runat="server" Visible="false" MaxLength="30"></asp:TextBox><br />
                <small><asp:Label runat="server" ID="Label4"></asp:Label></small>
                <div style="MARGIN-TOP: 10px">
                    <asp:Image id="Image4" runat="server" Visible="false"></asp:Image>
                    <asp:ImageButton ID="ImageButton4" runat="server" Visible="false" ImageUrl="~/App_Themes/Admin/images/del_16.gif" CommandArgument="4" OnClick="btn_apagarImagem_Click" CausesValidation="false" />
                </div>
            </div>
            
            <div class="required">
                <label for="TextBox5">Foto 5:</label>
                <asp:TextBox ID="TextBox5" runat="server" Visible="false" MaxLength="30"></asp:TextBox><br />
                <small><asp:Label runat="server" ID="Label5"></asp:Label></small>
                <div style="MARGIN-TOP: 10px">
                    <asp:Image id="Image5" runat="server" Visible="false"></asp:Image>
                    <asp:ImageButton ID="ImageButton5" runat="server" Visible="false" ImageUrl="~/App_Themes/Admin/images/del_16.gif" CommandArgument="5" OnClick="btn_apagarImagem_Click" CausesValidation="false" />
                </div>
            </div>
            
        </fieldset>
        <fieldset>
            <asp:Button ID="Button2" runat="server" Text="Ok" OnClick="btn_Confirm_Click" />
        </fieldset>
    </asp:Panel>
</asp:Content>
