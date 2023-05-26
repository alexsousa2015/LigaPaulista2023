<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="eventos-inscricoes.aspx.cs" Inherits="LigaPaulista.Site.Admin.eventos_inscricoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Inscrições</legend>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            ClientIDMode="AutoID" DataSourceID="SqlDataSource1" KeyFieldName="IDINSCRICAO" OnInit="ASPxGridView1_Init" >
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True"/>
                <dxwgv:GridViewDataTextColumn FieldName="IDINSCRICAO" ReadOnly="True" VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="IDEVENTO" VisibleIndex="2" ReadOnly="True"
                    Visible="False">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="IDCADASTRO" VisibleIndex="3" ReadOnly="True"
                    Visible="False">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataDateColumn FieldName="DATACADASTRO" VisibleIndex="4" ReadOnly="True">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataDateColumn>
                <dxwgv:GridViewDataTextColumn FieldName="TITULO" VisibleIndex="5" ReadOnly="True">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="NOME" VisibleIndex="6" ReadOnly="True">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ENTIDADE" VisibleIndex="7" ReadOnly="True">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataComboBoxColumn FieldName="STATUS" VisibleIndex="8">
                    <PropertiesComboBox ValueType="System.String">
                        <Items>
                            <dxe:ListEditItem Text="Aguardando Validação" Value="1" />
                            <dxe:ListEditItem Text="Aguardando Documentos" Value="2" />
                            <dxe:ListEditItem Text="Documentos Entregues" Value="4" />
                            <dxe:ListEditItem Text="Documentos Confirmados" Value="3" />
                            <dxe:ListEditItem Text="Inscrição Cancelada" Value="5" />
                        </Items>
                    </PropertiesComboBox>
                </dxwgv:GridViewDataComboBoxColumn>
                <dxwgv:GridViewDataTextColumn FieldName="CODIGOPGTO" VisibleIndex="9" ReadOnly="True">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataComboBoxColumn FieldName="ORIGEM" VisibleIndex="10" ReadOnly="True" Caption="STATUS ATLETA">
                    <EditFormSettings Visible="False" />
                    <PropertiesComboBox ValueType="System.String">
                        <Items>
                            <dxe:ListEditItem Text="Não Validado" Value="0" />
                            <dxe:ListEditItem Text="Validado" Value="1" />
                        </Items>
                    </PropertiesComboBox>
                </dxwgv:GridViewDataComboBoxColumn>
                <dxwgv:GridViewDataComboBoxColumn FieldName="ANO" VisibleIndex="10" ReadOnly="True" Caption="ANO">
                    <EditFormSettings Visible="False" />
                    <PropertiesComboBox ValueType="System.String"></PropertiesComboBox>
                </dxwgv:GridViewDataComboBoxColumn>
                <dxwgv:GridViewDataTextColumn VisibleIndex="11">
                                <EditFormSettings Visible="False" />
                    <DataItemTemplate>
                        <a href="validar.aspx?id=<%#Eval("IDCADASTRO") %>" target="_blank">VALIDAR</a>
                    </DataItemTemplate>
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <Templates>
                <DetailRow>
                    <img src="http://ligapaulista.com/ligapaulista/downloads/usuarios/<%#Eval("FOTO") %>"/>
                    <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
                        ClientIDMode="AutoID" DataSourceID="SqlDataSource2" KeyFieldName="IDDOC" OnBeforePerformDataSelect="gridModalidade_DataSelect">
                        <Columns>
                            <dxwgv:GridViewDataTextColumn FieldName="IDDOC" ReadOnly="True" VisibleIndex="0">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="DESCRICAO" VisibleIndex="1">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="ARQUIVO" VisibleIndex="2">
                                <DataItemTemplate>
                                    <a href="http://ligapaulista.com/ligapaulista/downloads/usuarios/docs/<%#Eval("ARQUIVO") %>" target="_blank">
                                        <%#Eval("ARQUIVO") %></a>
                                </DataItemTemplate>
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="STATUS" VisibleIndex="3">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataDateColumn FieldName="DATAHORA" VisibleIndex="4">
                            </dxwgv:GridViewDataDateColumn>
                        </Columns>
                    </dxwgv:ASPxGridView>
                </DetailRow>
            </Templates>
            <Settings ShowFilterBar="Visible" ShowFilterRow="True" ShowGroupPanel="True" />
            <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
            <SettingsText CommandCancel="Cancelar" CommandEdit="Editar" CommandNew="Novo" CommandUpdate="Gravar"
                EmptyDataRow="Sem eventos cadastrados." />
            <SettingsPager Mode="ShowPager" PageSize="25">
            </SettingsPager>
        </dxwgv:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
            SelectCommand="select i.IDINSCRICAO, i.IDEVENTO, i.IDCADASTRO, i.DATACADASTRO, e.TITULO, NOME = (c.NOME + ' ' + c.SOBRENOME), en.ENTIDADE,
	                    i.STATUS, i.CODIGOPGTO, c.ORIGEM, c.FOTO, I.ANO, I.ATIVO
                    from dbo.EVENTOS_INSCRICOES i
	                    join dbo.EVENTOS e on e.IDEVENTO = i.IDEVENTO
	                    join dbo.CADASTRO c on c.ID_CADASTRO = i.IDCADASTRO
	                    join dbo.ENTIDADES en on en.ID_ENTIDADE = c.FACULDADE
                    where i.STATUS <> 5
                        and I.ATIVO = 1
                    order by i.DATACADASTRO desc" UpdateCommand="update dbo.EVENTOS_INSCRICOES set STATUS = @STATUS where IDINSCRICAO = @IDINSCRICAO">
            <UpdateParameters>
                <asp:Parameter Name="STATUS" Type="Int32" />
                <asp:Parameter Name="IDINSCRICAO" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
            SelectCommand="select id.IDDOC, ed.DESCRICAO, id.ARQUIVO, id.STATUS, id.DATAHORA from dbo.EVENTOS_INSCRICOES_DOCS id
                join dbo.EVENTOS_DOCS ed on ed.IDEVENTODOC = id.IDEVENTODOC WHERE (id.[IDINSCRICAO] = @IDINSCRICAO)">
            <SelectParameters>
                <asp:SessionParameter Name="IDINSCRICAO" SessionField="IDINSCRICAO" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
                           SelectCommand="select distinct ano from dbo.EVENTOS_INSCRICOES">
            <SelectParameters>
                <asp:SessionParameter Name="IDINSCRICAO" SessionField="IDINSCRICAO" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>


    </fieldset>
</asp:Content>
