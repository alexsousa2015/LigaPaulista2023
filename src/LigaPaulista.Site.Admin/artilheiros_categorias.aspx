<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    Inherits="LigaPaulista.Site.Admin.adm_artilheiros_categorias" CodeBehind="artilheiros_categorias.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <legend>Categorias para Ranking</legend>
        <dxwgv:ASPxGridView ID="gridCateg" runat="server" AutoGenerateColumns="False" ClientInstanceName="grid"
            DataSourceID="sql_categorias" KeyFieldName="ID_CATEGORIA">
            <Columns>
                <dxw:GridViewCommandColumn Caption="Editar" ShowEditButton="True" VisibleIndex="0">
                </dxw:GridViewCommandColumn>
                <dxwgv:GridViewDataTextColumn Caption="Cód. Categoria" FieldName="ID_CATEGORIA" ReadOnly="false"
                    VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataComboBoxColumn Caption="Período" FieldName="ID_PERIODO"
                    SortIndex="0" SortOrder="Ascending" VisibleIndex="2">
                    <PropertiesComboBox DataSourceID="sql_periodos" TextField="PERIODO" ValueField="ID_PERIODO"
                        ValueType="System.String">
                    </PropertiesComboBox>
                </dxwgv:GridViewDataComboBoxColumn>
                <dxwgv:GridViewDataTextColumn Caption="Categoria" FieldName="CATEGORIA" VisibleIndex="3">
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <Templates>
                <StatusBar>
                    <input id="btnAdd" type="button" value="Novo" onclick="grid.AddNewRow();" />
                </StatusBar>
            </Templates>
            <Settings ShowStatusBar="Visible" ShowGroupPanel="True" />
            <SettingsText CommandCancel="Cancelar" CommandEdit="Editar" CommandNew="Novo" CommandUpdate="Gravar"
                EmptyDataRow="Sem categorias cadastradas." CommandDelete="Excluir" />
            <SettingsPager PageSize="15">
            </SettingsPager>
        </dxwgv:ASPxGridView>
        <!-- DataSource Artilheiros_Categorias -->
        <asp:SqlDataSource ID="sql_categorias" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            DeleteCommand="DELETE FROM artilheiros_categorias WHERE ID_CATEGORIA = @ID_CATEGORIA"
            InsertCommand="INSERT INTO artilheiros_categorias (ID_PERIODO,CATEGORIA) VALUES(@ID_PERIODO,@CATEGORIA)"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT ID_CATEGORIA, ID_PERIODO, CATEGORIA FROM artilheiros_categorias ORDER BY CATEGORIA"
            UpdateCommand="UPDATE artilheiros_categorias SET ID_PERIODO = @ID_PERIODO, CATEGORIA = @CATEGORIA WHERE ID_CATEGORIA = @ID_CATEGORIA">
            <UpdateParameters>
                <asp:Parameter Name="ID_PERIODO" Type="Int32" />
                <asp:Parameter Name="CATEGORIA" Type="String" />
                <asp:Parameter Name="ID_CATEGORIA" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ID_PERIODO" Type="Int32" />
                <asp:Parameter Name="CATEGORIA" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <!-- DataSource Periodos -->
        <asp:SqlDataSource ID="sql_periodos" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT ID_PERIODO, PERIODO FROM PERIODOS">
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>