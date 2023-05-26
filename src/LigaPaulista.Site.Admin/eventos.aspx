<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="eventos.aspx.cs" Inherits="LigaPaulista.Site.Admin.eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Eventos</legend>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" ClientInstanceName="grid" AutoGenerateColumns="False"
            ClientIDMode="AutoID" DataSourceID="SqlDataSource1" KeyFieldName="IDEVENTO" Width="100%">
            <Templates>
                <DetailRow>
                    <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
                        ClientIDMode="AutoID" DataSourceID="SqlDataSource2" KeyFieldName="IDEVENTODOC"
                        OnBeforePerformDataSelect="gridModalidade_DataSelect">
                        <SettingsCommandButton>
                            <NewButton Text="Novo">
                            </NewButton>
                            <UpdateButton Text="Gravar">
                            </UpdateButton>
                            <CancelButton Text="Cancelar">
                            </CancelButton>
                            <EditButton Text="Editar">
                            </EditButton>
                            <DeleteButton Text="Excluir">
                            </DeleteButton>
                        </SettingsCommandButton>
                        <Columns>
                            <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True"/>
                            <dxwgv:GridViewDataTextColumn FieldName="IDEVENTODOC" ReadOnly="True" VisibleIndex="1">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="IDEVENTO" VisibleIndex="2" ReadOnly="True">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="DESCRICAO" VisibleIndex="3">
                            </dxwgv:GridViewDataTextColumn>
                        </Columns>
                    </dxwgv:ASPxGridView>
                
</DetailRow>
                <StatusBar>
                    <input id="btnAdd" type="button" value="Novo" onclick="grid.AddNewRow();" />
                </StatusBar>
            </Templates>
            <Settings ShowStatusBar="Visible" />
            <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
            <SettingsText CommandCancel="Cancelar" CommandEdit="Editar" CommandNew="Novo" CommandUpdate="Gravar"
                EmptyDataRow="Sem eventos cadastrados." />
            <SettingsPager Mode="ShowAllRecords">
            </SettingsPager>
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True" Width="5%"/>
                <dxwgv:GridViewDataTextColumn FieldName="IDEVENTO" ReadOnly="True" VisibleIndex="1" Width="5%">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="TITULO" VisibleIndex="2" Width="30%">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="DESCRICAO" VisibleIndex="3" Width="30%">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataDateColumn FieldName="DATAINICIO" VisibleIndex="4" Width="5%">
                </dxwgv:GridViewDataDateColumn>
                <dxwgv:GridViewDataDateColumn FieldName="DATAFIM" VisibleIndex="5" Width="5%">
                </dxwgv:GridViewDataDateColumn>
                <dxwgv:GridViewDataTextColumn FieldName="LOCAL" VisibleIndex="6" Width="10%">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="VALOR" VisibleIndex="7" Width="15%">
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <Templates>
                <DetailRow>
                    <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
                        ClientIDMode="AutoID" DataSourceID="SqlDataSource2" KeyFieldName="IDEVENTODOC"
                        OnBeforePerformDataSelect="gridModalidade_DataSelect">
                        <Columns>
                            <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True"/>
                            <dxwgv:GridViewDataTextColumn FieldName="IDEVENTODOC" ReadOnly="True" VisibleIndex="0">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="IDEVENTO" VisibleIndex="1" ReadOnly="True">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="DESCRICAO" VisibleIndex="2">
                            </dxwgv:GridViewDataTextColumn>
                        </Columns>
                    </dxwgv:ASPxGridView>
                </DetailRow>
            </Templates>
        </dxwgv:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
            DeleteCommand="DELETE FROM [EVENTOS] WHERE [IDEVENTO] = @IDEVENTO" InsertCommand="INSERT INTO [EVENTOS] ([TITULO], [DESCRICAO], [DATAINICIO], [DATAFIM], [LOCAL], [VALOR]) VALUES (@TITULO, @DESCRICAO, @DATAINICIO, @DATAFIM, @LOCAL, @VALOR)"
            SelectCommand="SELECT * FROM [EVENTOS] ORDER BY [DATAINICIO] DESC" UpdateCommand="UPDATE [EVENTOS] SET [TITULO] = @TITULO, [DESCRICAO] = @DESCRICAO, [DATAINICIO] = @DATAINICIO, [DATAFIM] = @DATAFIM, [LOCAL] = @LOCAL, [VALOR] = @VALOR WHERE [IDEVENTO] = @IDEVENTO">
            <DeleteParameters>
                <asp:Parameter Name="IDEVENTO" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="TITULO" Type="String" />
                <asp:Parameter Name="DESCRICAO" Type="String" />
                <asp:Parameter Name="DATAINICIO" Type="DateTime" />
                <asp:Parameter Name="DATAFIM" Type="DateTime" />
                <asp:Parameter Name="LOCAL" Type="String" />
                <asp:Parameter Name="VALOR" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="TITULO" Type="String" />
                <asp:Parameter Name="DESCRICAO" Type="String" />
                <asp:Parameter Name="DATAINICIO" Type="DateTime" />
                <asp:Parameter Name="DATAFIM" Type="DateTime" />
                <asp:Parameter Name="LOCAL" Type="String" />
                <asp:Parameter Name="VALOR" Type="Decimal" />
                <asp:Parameter Name="IDEVENTO" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
            DeleteCommand="DELETE FROM [EVENTOS_DOCS] WHERE [IDEVENTODOC] = @IDEVENTODOC"
            InsertCommand="INSERT INTO [EVENTOS_DOCS] ([IDEVENTO], [DESCRICAO]) VALUES (@IDEVENTO, @DESCRICAO)"
            SelectCommand="SELECT * FROM [EVENTOS_DOCS] WHERE ([IDEVENTO] = @IDEVENTO) ORDER BY [DESCRICAO]"
            UpdateCommand="UPDATE [EVENTOS_DOCS] SET [IDEVENTO] = @IDEVENTO, [DESCRICAO] = @DESCRICAO WHERE [IDEVENTODOC] = @IDEVENTODOC">
            <DeleteParameters>
                <asp:Parameter Name="IDEVENTODOC" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:SessionParameter Name="IDEVENTO" SessionField="IDEVENTO" Type="Int32" />
                <asp:Parameter Name="DESCRICAO" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="IDEVENTO" SessionField="IDEVENTO" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="IDEVENTO" Type="Int32" />
                <asp:Parameter Name="DESCRICAO" Type="String" />
                <asp:Parameter Name="IDEVENTODOC" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>
