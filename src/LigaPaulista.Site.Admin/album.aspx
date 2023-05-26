<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="True"
    CodeBehind="album.aspx.cs" Inherits="LigaPaulista.Site.Admin.album" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Album - Categorias</legend>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upt_anos">
            <ProgressTemplate>
                Carregando...
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="upt_anos" runat="server">
            <ContentTemplate>
                <h3>
                    Selecione o ano desejado:
                    <asp:DropDownList ID="ddl_anos" runat="server" OnSelectedIndexChanged="ddl_anos_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </h3>
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                    DataKeyNames="id_cat" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_DataBound"
                    BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" CellPadding="2">
                    <Columns>
                        <asp:BoundField DataField="id_cat" HeaderText="C&#243;d.">
                            <ItemStyle VerticalAlign="Top" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="A&#231;&#245;es">
                            <ItemStyle VerticalAlign="Top" />
                            <HeaderStyle Wrap="False" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_updCategoria" runat="server" ImageUrl="~/App_Themes/Admin/Images/edit_16.gif"
                                    CommandArgument='<%# Eval("id_cat") %>' OnClick="btn_upd_Click" CausesValidation="false"
                                    AlternateText="Editar" CssClass="cursorMouse" />
                                <asp:ImageButton ID="bt_delCategoria" runat="server" ImageUrl="~/App_Themes/Admin/Images/delete.gif"
                                    CommandArgument='<%# Eval("id_cat") %>' OnClick="btn_del_Click" CausesValidation="false"
                                    AlternateText="Apagar" CssClass="cursorMouse" OnClientClick="return confirmar('Tem certeza que deseja excluir esta categoria?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="categoria" HeaderText="Categoria">
                            <ItemStyle VerticalAlign="Top" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Albuns">
                            <ItemTemplate>
                                <asp:GridView ID="GridViewAlbuns" runat="server" AutoGenerateColumns="False" DataKeyNames="id_album"
                                    Width="100%" EmptyDataText="Sem álbuns cadastrados!">
                                    <Columns>
                                        <asp:BoundField DataField="id_album" HeaderText="C&#243;d." InsertVisible="False"
                                            ReadOnly="True" SortExpression="id_album">
                                            <HeaderStyle Width="30px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="A&#231;&#245;es">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btn_updCategoria" runat="server" ImageUrl="~/App_Themes/Admin/Images/edit_16.gif"
                                                    CommandArgument='<%# Eval("id_album") %>' OnClick="btn_updAlbum_Click" CausesValidation="false"
                                                    AlternateText="Editar" CssClass="cursorMouse" />
                                                <asp:ImageButton ID="btn_addFotos" runat="server" ImageUrl="~/App_Themes/Admin/Images/picts_16.png"
                                                    CommandArgument='<%# Eval("id_album") %>' OnClick="btn_addFoto_Click" CausesValidation="false"
                                                    AlternateText="Incluir Fotos" CssClass="cursorMouse" />
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Admin/Images/srch_16.png"
                                                    CommandArgument='<%# Eval("id_album") %>' AlternateText="Ver Fotos" CssClass="cursorMouse"
                                                    OnClick="btn_verFoto_Click" />
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/App_Themes/Admin/Images/delete.gif"
                                                    CommandArgument='<%# Eval("id_album") %>' AlternateText="Excluir Álbum" CssClass="cursorMouse"
                                                    OnClick="btn_delFoto_Click" OnClientClick="return confirm('Tem certeza que deseja excluir este álbum e todas as suas fotos?');" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="95px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="album" HeaderText="Titulo" SortExpression="titulo" />
                                    </Columns>
                                    <HeaderStyle BackColor="DarkKhaki" BorderStyle="None" ForeColor="Black" />
                                    <AlternatingRowStyle BackColor="#FFFFC0" />
                                    <RowStyle BackColor="#ffffff" />
                                </asp:GridView>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="PaleGoldenrod" />
                    <AlternatingRowStyle BackColor="ControlLight" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM categorias;">
                </asp:SqlDataSource>
<%--                <asp:AccessDataSource ID="AccessDataSource1" runat="server">
                </asp:AccessDataSource>--%>
                <asp:SqlDataSource ID="SqlDataSource" runat="server">
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
</asp:Content>
