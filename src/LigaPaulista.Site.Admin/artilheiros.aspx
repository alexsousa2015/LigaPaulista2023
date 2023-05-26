<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    Inherits="LigaPaulista.Site.Admin.adm_artilheiros" CodeBehind="artilheiros.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <legend>Gols e Cestas</legend>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upt_artilharia">
            <ProgressTemplate>
                Carregando...
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="upt_artilharia" runat="server">
            <ContentTemplate>
                <label>
                    Selecione o Período:
                </label>
                <asp:DropDownList ID="ddl_periodo" AutoPostBack="True" OnSelectedIndexChanged="ddl_periodo_SelectedIndexChanged"
                    runat="server">
                </asp:DropDownList>
                <dxwgv:ASPxGridView ID="gridArtilharia" runat="server" ClientInstanceName="grid"
                    DataSourceID="sql_artilharia" KeyFieldName="ID_ARTILHEIRO" Settings-ShowFilterBar="Visible"
                    Settings-ShowFilterRow="true" AutoGenerateColumns="False">
                    <Columns>
                        <dxw:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" Caption="Editar">
                        </dxw:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Cód." FieldName="ID_ARTILHEIRO" ReadOnly="True"
                            VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Categoria" FieldName="ID_CATEGORIA" VisibleIndex="2"
                            GroupIndex="0" SortIndex="0" SortOrder="Ascending">
                            <PropertiesComboBox DataSourceID="sql_categorias" TextField="categoria" ValueField="ID_CATEGORIA"
                                ValueType="System.String">
                            </PropertiesComboBox>
                            <EditFormSettings ColumnSpan="2" />
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nome" FieldName="NOME" VisibleIndex="3">
                            <EditFormSettings ColumnSpan="2" />
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="Entidade" FieldName="ID_ENTIDADE" VisibleIndex="4">
                            <PropertiesComboBox DataSourceID="sql_entidades" TextField="entidade" ValueField="ID_ENTIDADE"
                                ValueType="System.String">
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Pts" FieldName="GOLS" VisibleIndex="5">
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <Templates>
                        <StatusBar>
                            <input id="btnAdd" type="button" value="Novo" onclick="grid.AddNewRow();" />
                        </StatusBar>
                    </Templates>
                    <SettingsBehavior AutoExpandAllGroups="true" />
                    <Settings ShowStatusBar="Visible" ShowGroupPanel="True" />
                    <SettingsText CommandCancel="Cancelar" CommandEdit="Editar" CommandNew="Novo" CommandUpdate="Gravar"
                        EmptyDataRow="Sem artilheiros cadastrados." />
                    <SettingsPager PageSize="40">
                    </SettingsPager>
                    <SettingsEditing Mode="PopupEditForm" PopupEditFormHorizontalAlign="WindowCenter"
                        PopupEditFormModal="True" PopupEditFormVerticalAlign="WindowCenter" PopupEditFormWidth="400px" />
                </dxwgv:ASPxGridView>
                <asp:SqlDataSource ID="sql_artilharia" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    DeleteCommand="DELETE FROM [artilheiros] WHERE [id_artilheiro] = @id_artilheiro"
                    InsertCommand="INSERT INTO [artilheiros] ([id_categoria], [nome], [id_entidade], [gols]) VALUES (@id_categoria, @nome, @id_entidade, @gols)"
                    ProviderName ="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                    SelectCommand="SELECT a.ID_ARTILHEIRO,a.ID_CATEGORIA,a.ID_ENTIDADE,a.NOME,a.GOLS, c.id_periodo FROM artilheiros a inner join artilheiros_categorias c on a.id_categoria= c.id_categoria where (c.id_periodo=@id_periodo)  ORDER BY a.GOLS  DESC"
                    UpdateCommand="UPDATE [artilheiros] SET [id_categoria] = @id_categoria, [nome] = @nome, [id_entidade] = @id_entidade, [gols] = @gols WHERE [id_artilheiro] = @id_artilheiro">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_PERIODO" SessionField="ID_PERIODO" Type="Int32" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="ID_ARTILHEIRO" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ID_CATEGORIA" Type="Int32" />
                        <asp:Parameter Name="NOME" Type="String" />
                        <asp:Parameter Name="ID_ENTIDADE" Type="int32" />
                        <asp:Parameter Name="GOLS" Type="Int32" />
                        <asp:Parameter Name="ID_ARTILHEIRO" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ID_CATEGORIA" Type="Int32" />
                        <asp:Parameter Name="NOME" Type="String" />
                        <asp:Parameter Name="ID_ENTIDADE" Type="int32" />
                        <asp:Parameter Name="GOLS" Type="Int32" />
                    </InsertParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sql_categorias" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [artilheiros_categorias]  where id_periodo = @id_periodo ORDER BY [categoria]">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID_PERIODO" SessionField="ID_PERIODO" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sql_entidades" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [entidades] ORDER BY [entidade]">
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
</asp:Content>
