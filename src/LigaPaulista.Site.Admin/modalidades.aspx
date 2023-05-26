<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="modalidades.aspx.cs" Inherits="LigaPaulista.Site.Admin.Modalidades" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">
        function Atualiza() {
            aspxPopup.Hide();
            alert("Modalidade salva com sucesso!");
            Grid.DataBind();
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Modalidades</legend>
        <dxwgv:ASPxGridView ID="Grid1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlModalidades"
            KeyFieldName="ID_MODALIDADE" ClientInstanceName="Grid" OnCustomCallback="CustomCallbackGrid">
            <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
            <Columns>
                <dxw:GridViewCommandColumn VisibleIndex="0">
                </dxw:GridViewCommandColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ID_MODALIDADE" ReadOnly="True" VisibleIndex="1"
                    Caption="Código">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataImageColumn FieldName="IMAGEM" VisibleIndex="2" Caption="Imagem"
                    EditFormSettings-Visible="True">
                    <EditFormSettings Visible="True"></EditFormSettings>
                    <DataItemTemplate>
                        <img src="../imagens/thumbs/<%# DataBinder.Eval(Container.DataItem,"IMAGEM")%>" alt="<%# DataBinder.Eval(Container.DataItem,"IMAGEM")%>" />
                    </DataItemTemplate>
                </dxwgv:GridViewDataImageColumn>
                <dxwgv:GridViewDataTextColumn FieldName="MODALIDADE" EditFormSettings-ColumnSpan="2" SortOrder="Ascending" VisibleIndex="3" Caption="Modalidade">
                    <EditFormSettings ColumnSpan="2"></EditFormSettings>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataCheckColumn FieldName="Ativo" VisibleIndex="4" Width="10px">
                    <DataItemTemplate>
                        <dxwgv:ASPxCheckBox ID="chk" runat="server" ValueType="System.Int32"
                            ReadOnly="True" ValueChecked="1" ValueUnchecked="0" Value='<%# Eval("ATIVO") %>'>
                        </dxwgv:ASPxCheckBox>
                    </DataItemTemplate>
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataCheckColumn>
                <dxwgv:GridViewDataMemoColumn FieldName="OBSERVACOES" EditFormSettings-ColumnSpan="2" VisibleIndex="5" Caption="Observacoes">
                    <EditFormSettings ColumnSpan="2"></EditFormSettings>
                </dxwgv:GridViewDataMemoColumn>
                <dxwgv:GridViewDataHyperLinkColumn Caption="#" Visible="true" VisibleIndex="6" Width="70px">
                    <EditFormSettings Visible="False" />
                    <DataItemTemplate>
                        <a href="javascript:ShowPopupResize('modalidade-manutencao.aspx', 'Cadastro de Modalidade',600, 300);">
                            <img src="../App_Themes/Admin/Images/add-trans.png" alt="Incluir" /></a>
                        <a href="javascript:ShowPopupResize('modalidade-manutencao.aspx?id=<%# Eval("ID_MODALIDADE") %>','Alteração de Modalidade',450,300)">
                            <img src="../App_Themes/Admin/Images/edit_16.gif" alt="Editar" /></a>
                        <a href="javascript:ShowPopupResize('modalidade-arquivos.aspx?id=<%# Eval("ID_MODALIDADE") %>','Arquivos',450,650)">
                            <img src="../App_Themes/Admin/Images/down.png" alt="Arquivo" /></a>
                    </DataItemTemplate>
                </dxwgv:GridViewDataHyperLinkColumn>
            </Columns>
            <Templates>
                <DetailRow>
                    <dxwgv:ASPxGridView ID="Grid2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlCampeonatos"
                        KeyFieldName="ID_CAMPEONATO" OnBeforePerformDataSelect="gridModalidade_DataSelect"
                        OnCustomButtonCallback="Grid2_CustomButtonCallback" Caption="Campeonatos">
                        <Columns>
                            <dxwgv:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" ButtonType="Image" ShowNewButtonInHeader="True">
                                <CustomButtons>
                                    <dxwgv:GridViewCommandColumnCustomButton Visibility="AllDataRows" Image-Url="../App_Themes/Admin/Images/srch_16.png"
                                        ID="prox">
                                        <Image Url="../App_Themes/Admin/Images/srch_16.png">
                                        </Image>
                                    </dxwgv:GridViewCommandColumnCustomButton>
                                    <dxwgv:GridViewCommandColumnCustomButton Visibility="AllDataRows" ID="federados">
                                        <Image Url="~/App_Themes/Admin/Images/add-trans.png">
                                        </Image>
                                    </dxwgv:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                            </dxwgv:GridViewCommandColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="ID_CAMPEONATO" ReadOnly="True" VisibleIndex="1"
                                Visible="False">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="ID_MODALIDADE" VisibleIndex="2" Visible="False"
                                Caption="Código">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="NOME" VisibleIndex="3" Caption="Nome">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataDateColumn FieldName="DATA" VisibleIndex="4" Caption="Data" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                </PropertiesDateEdit>
                            </dxwgv:GridViewDataDateColumn>
                        </Columns>
                        <SettingsCommandButton>
                            <NewButton Text="Novo" Image-Url="">
                                <Image Url="../App_Themes/Admin/Images/6098_16x16.png">
                                </Image>
                            </NewButton>
                            <EditButton Text="Editar" Image-Url="../App_Themes/Admin/Images/edit_16.gif">
                                <Image Url="../App_Themes/Admin/Images/edit_16.gif">
                                </Image>
                            </EditButton>
                            <CancelButton Text="Cancelar" Image-Url="../App_Themes/Admin/Images/delete.gif">
                                <Image Url="../App_Themes/Admin/Images/delete.gif">
                                </Image>
                            </CancelButton>
                            <UpdateButton Text="Gravar">
                                <Image Url="../App_Themes/Admin/Images/Save_16.png">
                                </Image>
                            </UpdateButton>
                        </SettingsCommandButton>
                    </dxwgv:ASPxGridView>
                    <asp:SqlDataSource ID="SqlCampeonatos" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
                        DeleteCommand="DELETE FROM [CAMPEONATOS] WHERE [ID_CAMPEONATO] = @ID_CAMPEONATO"
                        InsertCommand="INSERT INTO [CAMPEONATOS] ([ID_MODALIDADE], [NOME], [DATA]) VALUES (@ID_MODALIDADE, @NOME, @DATA)" SelectCommand="SELECT * FROM [CAMPEONATOS] WHERE ([ID_MODALIDADE] = @ID_MODALIDADE)"
                        UpdateCommand="UPDATE [CAMPEONATOS] SET [ID_MODALIDADE] = @ID_MODALIDADE, [NOME] = @NOME, [DATA] = @DATA WHERE [ID_CAMPEONATO] = @ID_CAMPEONATO">
                        <SelectParameters>
                            <asp:SessionParameter Name="ID_MODALIDADE" SessionField="id_modalidade" Type="Int32" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="ID_CAMPEONATO" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:SessionParameter Name="ID_MODALIDADE" SessionField="id_modalidade" Type="Int32" />
                            <asp:Parameter Name="NOME" Type="String" />
                            <asp:Parameter Name="DATA" Type="DateTime" />
                            <asp:Parameter Name="ID_CAMPEONATO" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:SessionParameter Name="ID_MODALIDADE" SessionField="id_modalidade" Type="Int32" />
                            <asp:Parameter Name="NOME" Type="String" />
                            <asp:Parameter Name="DATA" Type="DateTime" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                </DetailRow>
            </Templates>
            <SettingsDetail ShowDetailRow="True" />
            <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="500px" />
        </dxwgv:ASPxGridView>

        <asp:SqlDataSource ID="SqlModalidades" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
            DeleteCommand="DELETE FROM [MODALIDADES] WHERE [ID_MODALIDADE] = @ID_MODALIDADE" SelectCommand="SELECT ID_MODALIDADE, MODALIDADE, OBSERVACOES, IMAGEM, ATIVO FROM MODALIDADES"
            UpdateCommand="UPDATE [MODALIDADES] SET [MODALIDADE] = @MODALIDADE, OBSERVACOES = @OBSERVACOES WHERE [ID_MODALIDADE] = @ID_MODALIDADE">
            <DeleteParameters>
                <asp:Parameter Name="ID_MODALIDADE" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="MODALIDADE" Type="String" />
                <asp:Parameter Name="OBSERVACOES" Type="String" />
                <asp:Parameter Name="ID_MODALIDADE" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <dxpc:ASPxPopupControl ID="ASPxPopupControl1" runat="server" PopupHorizontalAlign="WindowCenter"
            PopupVerticalAlign="WindowCenter" EnableViewState="true" ClientInstanceName="aspxPopup"
            Modal="true">
            <Border BorderColor="#7EACB1" BorderStyle="Solid" BorderWidth="1px" />
            <FooterStyle ForeColor="#6896A0">
                <border borderwidth="0px" />
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
