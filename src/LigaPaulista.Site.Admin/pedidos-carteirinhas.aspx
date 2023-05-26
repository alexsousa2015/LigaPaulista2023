<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="pedidos-carteirinhas.aspx.cs" Inherits="LigaPaulista.Site.Admin.pedidos_carteirinhas" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Pedidos de Carteirinhas</legend>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            ClientIDMode="AutoID" DataSourceID="SqlDataSource1" KeyFieldName="IDPEDIDO" OnDataBound="ASPxGridView1_DataBound">
            <Settings ShowStatusBar="Visible" ShowFilterRow="True" ShowFilterBar="Visible" />

            <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
            <SettingsText CommandCancel="Cancelar" CommandEdit="Editar" CommandNew="Novo" CommandUpdate="Gravar"
                EmptyDataRow="Nenhum pedido solicitado." />
            <SettingsPager Mode="ShowAllRecords">
            </SettingsPager>
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True"/>
                <dxwgv:GridViewDataTextColumn VisibleIndex="0">
                    <DataItemTemplate>
                        <a href="export.aspx?idpedido=<%#Eval("IDPEDIDO") %>&entidade=<%#Eval("ID_ENTIDADE") %>" target="_blank">Exportar Pedido</a>
                    </DataItemTemplate>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="IDPEDIDO" ReadOnly="True" VisibleIndex="0">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataComboBoxColumn Caption="ENTIDADE" FieldName="ID_ENTIDADE" VisibleIndex="1">
                    <PropertiesComboBox DataSourceID="SqlDataSource3" TextField="ENTIDADE" ValueField="ID_ENTIDADE"
                        ValueType="System.Int32">
                    </PropertiesComboBox>
                </dxwgv:GridViewDataComboBoxColumn>
                <dxwgv:GridViewDataDateColumn FieldName="DATAPEDIDO" VisibleIndex="2">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataDateColumn>
                <dxwgv:GridViewDataDateColumn FieldName="DATALIBERACAO" VisibleIndex="3">
                </dxwgv:GridViewDataDateColumn>
                <dxwgv:GridViewDataComboBoxColumn FieldName="STATUS" VisibleIndex="4">
                    <PropertiesComboBox ValueType="System.String">
                        <Items>
                            <dxe:ListEditItem Text="Aguardando Processamento" Value="0" />
                            <dxe:ListEditItem Text="Em Fabricaçao" Value="1" />
                            <dxe:ListEditItem Text="Prontas para Retirada" Value="3" />
                            <dxe:ListEditItem Text="Entregue" Value="2" />
                        </Items>
                    </PropertiesComboBox>
                </dxwgv:GridViewDataComboBoxColumn>
                <dxwgv:GridViewDataTextColumn FieldName="REPRESENTANTE" VisibleIndex="5">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="VALORTOTAL" VisibleIndex="6">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="OBSERVACOES" VisibleIndex="7">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="CONFERIDAPOR" VisibleIndex="8">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="RETIRADAPOR" VisibleIndex="9">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataDateColumn FieldName="RETIRADAEM" VisibleIndex="10">
                </dxwgv:GridViewDataDateColumn>
            </Columns>
            <Templates>
                <DetailRow>
                    <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
                        KeyFieldName="ID_CADASTRO" ClientIDMode="AutoID" OnBeforePerformDataSelect="gridModalidade_DataSelect"
                        DataSourceID="SqlDataSource2">
                        <Columns>
                            <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True"/>
                            <dxwgv:GridViewDataTextColumn FieldName="IDPEDIDO" Visible="False" VisibleIndex="0">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="NOME" VisibleIndex="1">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="RG" Caption="DOCUMENTO" VisibleIndex="1">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataCheckColumn FieldName="ATLETA" VisibleIndex="2">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataCheckColumn>
                            <dxwgv:GridViewDataCheckColumn FieldName="FEDERADO" VisibleIndex="3">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataCheckColumn>
                            <dxwgv:GridViewDataCheckColumn FieldName="DIRIGENTE" VisibleIndex="4">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataCheckColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="CREF" VisibleIndex="4">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataDateColumn FieldName="DATAPEDIDO" VisibleIndex="5">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataDateColumn>
                            <dxwgv:GridViewDataComboBoxColumn FieldName="STATUS" VisibleIndex="6">
                                <PropertiesComboBox ValueType="System.String">
                                    <Items>
                                        <dxe:ListEditItem Text="Aguardando Processamento" Value="0" />
                                        <dxe:ListEditItem Text="Em Fabricaçao" Value="1" />
                                        <dxe:ListEditItem Text="Entregue" Value="2" />
                                        <dxe:ListEditItem Text="Rejeitada" Value="3" />
                                    </Items>
                                </PropertiesComboBox>
                            </dxwgv:GridViewDataComboBoxColumn>
                        </Columns>
                    </dxwgv:ASPxGridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
                        SelectCommand="SELECT P.*, NOME = (C.NOME + ' ' + C.SOBRENOME), C.RG
                            FROM [PEDIDOS_ATLETAS] P
                            JOIN dbo.CADASTRO C ON C.ID_CADASTRO = P.ID_CADASTRO
                            WHERE ([IDPEDIDO] = @IDPEDIDO)" UpdateCommand="UPDATE PEDIDOS_ATLETAS SET STATUS = @STATUS WHERE IDPEDIDO = @IDPEDIDO AND ID_CADASTRO = @ID_CADASTRO">
                        <SelectParameters>
                            <asp:SessionParameter Name="IDPEDIDO" SessionField="IDPEDIDO" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ID_CADASTRO" Type="Int32" />
                            <asp:Parameter Name="STATUS" Type="Int32" />
                            <asp:Parameter Name="IDPEDIDO" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </DetailRow>
            </Templates>
        </dxwgv:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
            SelectCommand="SELECT * FROM [PEDIDOS_CARTEIRINHA] ORDER BY [DATAPEDIDO] DESC"
            DeleteCommand="DELETE FROM [PEDIDOS_CARTEIRINHA] WHERE [IDPEDIDO] = @IDPEDIDO"
            InsertCommand="INSERT INTO [PEDIDOS_CARTEIRINHA] ([ID_ENTIDADE], [DATAPEDIDO], [DATALIBERACAO], [STATUS], [REPRESENTANTE], [VALORTOTAL], [OBSERVACOES], [CONFERIDAPOR], [RETIRADAPOR], [RETIRADAEM]) VALUES (@ID_ENTIDADE, @DATAPEDIDO, @DATALIBERACAO, @STATUS, @REPRESENTANTE, @VALORTOTAL, @OBSERVACOES, @CONFERIDAPOR, @RETIRADAPOR, @RETIRADAEM)"
            UpdateCommand="UPDATE [PEDIDOS_CARTEIRINHA] SET [ID_ENTIDADE] = @ID_ENTIDADE, [DATAPEDIDO] = @DATAPEDIDO, [DATALIBERACAO] = @DATALIBERACAO, [STATUS] = @STATUS, [REPRESENTANTE] = @REPRESENTANTE, [VALORTOTAL] = @VALORTOTAL, [OBSERVACOES] = @OBSERVACOES, [CONFERIDAPOR] = @CONFERIDAPOR, [RETIRADAPOR] = @RETIRADAPOR, [RETIRADAEM] = @RETIRADAEM WHERE [IDPEDIDO] = @IDPEDIDO">
            <DeleteParameters>
                <asp:Parameter Name="IDPEDIDO" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID_ENTIDADE" Type="Int32" />
                <asp:Parameter Name="DATAPEDIDO" Type="DateTime" />
                <asp:Parameter Name="DATALIBERACAO" Type="DateTime" />
                <asp:Parameter Name="STATUS" Type="Int32" />
                <asp:Parameter Name="REPRESENTANTE" Type="String" />
                <asp:Parameter Name="VALORTOTAL" Type="Decimal" />
                <asp:Parameter Name="OBSERVACOES" Type="String" />
                <asp:Parameter Name="CONFERIDAPOR" Type="String" />
                <asp:Parameter Name="RETIRADAPOR" Type="String" />
                <asp:Parameter Name="RETIRADAEM" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ID_ENTIDADE" Type="Int32" />
                <asp:Parameter Name="DATAPEDIDO" Type="DateTime" />
                <asp:Parameter Name="DATALIBERACAO" Type="DateTime" />
                <asp:Parameter Name="STATUS" Type="Int32" />
                <asp:Parameter Name="REPRESENTANTE" Type="String" />
                <asp:Parameter Name="VALORTOTAL" Type="Decimal" />
                <asp:Parameter Name="OBSERVACOES" Type="String" />
                <asp:Parameter Name="CONFERIDAPOR" Type="String" />
                <asp:Parameter Name="RETIRADAPOR" Type="String" />
                <asp:Parameter Name="RETIRADAEM" Type="DateTime" />
                <asp:Parameter Name="IDPEDIDO" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
            SelectCommand="SELECT ID_ENTIDADE, ENTIDADE FROM ENTIDADES ORDER BY [ENTIDADE]">
        </asp:SqlDataSource>
        
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" FileName="PedidosCarteirinha">
    </dx:ASPxGridViewExporter>
    </fieldset>
</asp:Content>
