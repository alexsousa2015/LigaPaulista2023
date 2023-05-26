<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="calendarios.aspx.cs" Inherits="LigaPaulista.Site.Admin.Calendarios" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">
        function Atualiza() {
            aspxPopup.Hide();
            alert("Calendário salvo com sucesso!");
            Grid.DataBind();
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Calendários</legend>
        <dxwgv:ASPxGridView ID="Grid1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlCalendarios"
            KeyFieldName="ID_CALENDARIO" ClientInstanceName="Grid" OnCustomCallback="CustomCallbackGrid" EnableTheming="True" Theme="Default">
            <Settings ShowStatusBar="Visible" />
            <SettingsBehavior ConfirmDelete="True" />
            <SettingsCommandButton>
                <DeleteButton Text="Excluir">
                </DeleteButton>
            </SettingsCommandButton>
            <Columns>
                <dxw:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="0">
                </dxw:GridViewCommandColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ID_CALENDARIO" ReadOnly="True" VisibleIndex="1" Caption="Id" ShowInCustomizationForm="True">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ANO" EditFormSettings-ColumnSpan="2" VisibleIndex="2" Caption="Ano" ShowInCustomizationForm="True">
                    <EditFormSettings ColumnSpan="2"></EditFormSettings>
                </dxwgv:GridViewDataTextColumn>
                <dxw:GridViewDataTextColumn FieldName="TEMPORADA" VisibleIndex="3" Caption="Temporada" ShowInCustomizationForm="True">
                </dxw:GridViewDataTextColumn>
                <dxw:GridViewDataHyperLinkColumn Caption="Arquivo" FieldName="NOMEARQUIVO" VisibleIndex="4">
                    <DataItemTemplate>
                        <a href="http://ligapaulista.com/ligapaulista/downloads/calendarios/<%# Eval("GuidArquivo") %>" target="_blank"><%# Eval("NomeArquivo") %></a>
                    </DataItemTemplate>
                </dxw:GridViewDataHyperLinkColumn>

                <dxw:GridViewDataHyperLinkColumn Caption="#" Name="CustomButtons" VisibleIndex="5">
                    <EditFormSettings Visible="False" />
                    <DataItemTemplate>
                        <a href="javascript:ShowPopupResize('calendario-formulario.aspx', 'Cadastro de Calendários',600, 450);">
                            <img src="../App_Themes/Admin/Images/add-trans.png" alt="Incluir" /></a>
                        <a href="javascript:ShowPopupResize('calendario-formulario.aspx?id=<%# Eval("ID_CALENDARIO") %>','Alteração de Calendários',600,450);">
                            <img src="../App_Themes/Admin/Images/edit_16.gif" alt="Editar" /></a>
                    </DataItemTemplate>
                </dxw:GridViewDataHyperLinkColumn>
                <dxw:GridViewDataTextColumn Caption="GuidArquivo" FieldName="GUIDARQUIVO" Visible="False" VisibleIndex="6">
                </dxw:GridViewDataTextColumn>
            </Columns>
            <SettingsDetail ShowDetailRow="True" ShowDetailButtons="False" />
            <Templates>
                <StatusBar><a href="javascript:ShowPopupResize('calendario-formulario.aspx', 
                            'Cadastro de Calendários',600, 450);">Novo</a>
                </StatusBar>
            </Templates>
            <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="600px" />
        </dxwgv:ASPxGridView>

        <asp:SqlDataSource ID="SqlCalendarios" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>" SelectCommand="SELECT [ID_CALENDARIO], [ANO], [TEMPORADA], [NOMEARQUIVO], [GUIDARQUIVO] FROM [CALENDARIO]" DeleteCommand="DELETE FROM [CALENDARIO] WHERE [ID_CALENDARIO] = @ID_CALENDARIO" InsertCommand="INSERT INTO [CALENDARIO] ([ANO], [TEMPORADA], [NOMEARQUIVO], [GUIDARQUIVO]) VALUES (@ANO, @TEMPORADA, @NOMEARQUIVO, @GUIDARQUIVO)" UpdateCommand="UPDATE [CALENDARIO] SET [ANO] = @ANO, [TEMPORADA] = @TEMPORADA, [NOMEARQUIVO] = @NOMEARQUIVO, [GUIDARQUIVO] = @GUIDARQUIVO WHERE [ID_CALENDARIO] = @ID_CALENDARIO">
            <DeleteParameters>
                <asp:Parameter Name="ID_CALENDARIO" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ANO" Type="Int32" />
                <asp:Parameter Name="TEMPORADA" Type="String" />
                <asp:Parameter Name="NOMEARQUIVO" Type="String" />
                <asp:Parameter Name="GUIDARQUIVO" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ANO" Type="Int32" />
                <asp:Parameter Name="TEMPORADA" Type="String" />
                <asp:Parameter Name="NOMEARQUIVO" Type="String" />
                <asp:Parameter Name="GUIDARQUIVO" Type="String" />
                <asp:Parameter Name="ID_CALENDARIO" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <dxpc:ASPxPopupControl ID="ASPxPopupControl1" runat="server" PopupHorizontalAlign="WindowCenter"
            PopupVerticalAlign="WindowCenter" EnableViewState="true" ClientInstanceName="aspxPopup"
            Modal="true">
            <Border BorderColor="#7EACB1" BorderStyle="Solid" BorderWidth="1px" />
            <FooterStyle ForeColor="#6896A0">
                <Border BorderWidth="0px" />
                <Paddings Padding="5px" />
            </FooterStyle>
            <ContentStyle>
                <Paddings Padding="5px" />
            </ContentStyle>
            <HeaderStyle>
                <Paddings Padding="5px" />
            </HeaderStyle>
        </dxpc:ASPxPopupControl>
    </fieldset>
</asp:Content>
