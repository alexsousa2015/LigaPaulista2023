<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modalidade-arquivos.aspx.cs"
    Inherits="LigaPaulista.Site.Admin.Modalidade_arquivos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" width="70%" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div >
        <h2>
            Manutenção de Arquivos</h2><asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset>
                    <legend>Cadastro</legend>
                    <table>
                        <tr>
                        <td>Arquivo:&nbsp;</td>
                        <td><asp:FileUpload ID="fuplArquivo" runat="server" Width="300"/><br /></td>
                        </tr>
                        <tr>
                            <td>Ano:</td>
                            <td><asp:TextBox runat="server" ID="txtAno" Width="184" MaxLength="4" />
                                <asp:Button ID="btnSubir" Width="110" runat="server" Text="Arquivar" OnClick="btnSubir_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend>Arquivos</legend>
                    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
                        DataSourceID="SqlConfrontos" KeyFieldName="ID_DOCUMENTO" Width="320">
                        <SettingsText EmptyDataRow="Não há Arquivos disponiveis!" />
                        <Columns>
                            <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowDeleteButton="True"/>
                            <dxwgv:GridViewDataTextColumn FieldName="ID_DOCUMENTO" ReadOnly="True" VisibleIndex="1"
                                Visible="false">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="ID_MODALIDADE" VisibleIndex="1" Visible="false">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="ANO" VisibleIndex="2">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataHyperLinkColumn Caption="Documento" VisibleIndex="3" Visible="true">
                                <DataItemTemplate>
                                    <a href="http://ligapaulista.com/ligapaulista/downloads/<%# Eval("DOCUMENTO") %>" target="_blank">
                                        <%# Eval("NOME") %></a>
                                </DataItemTemplate>
                            </dxwgv:GridViewDataHyperLinkColumn>
                        </Columns>
                        <SettingsCommandButton>
                            <DeleteButton Text="Excluir"/>
                        </SettingsCommandButton>
                    </dxwgv:ASPxGridView>
                    <asp:SqlDataSource ID="SqlConfrontos" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID_DOCUMENTO], [ID_MODALIDADE], [DOCUMENTO],[NOME], [ANO] FROM [DOCUMENTOS_MODALIDADES] WHERE ([ID_MODALIDADE] = @ID_MODALIDADE) ORDER BY ANO DESC "
                        DeleteCommand="DELETE DOCUMENTOS_MODALIDADES WHERE ID_DOCUMENTO = @ID_DOCUMENTO">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ID_MODALIDADE" QueryStringField="id" Type="Int32" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="ID_DOCUMENTO" />
                        </DeleteParameters>
                    </asp:SqlDataSource>
                </fieldset>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubir" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
