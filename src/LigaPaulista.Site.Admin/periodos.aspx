<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="periodos.aspx.cs" Inherits="LigaPaulista.Site.Admin.periodos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Períodos</legend>
        <dxwgv:ASPxGridView ID="gridPeriodos" ClientInstanceName="gridPeriodos" runat="server"
            AutoGenerateColumns="False" DataSourceID="sql_periodos" KeyFieldName="ID_PERIODO">
            <Settings ShowFooter="true" />
            <SettingsText ConfirmDelete="Tem certeza que deseja excluir este item?" EmptyDataRow="Sem períodos atualmente" CommandDelete="Excluir" CommandEdit="Editar" CommandNew="Novo" />
            <Columns>
                <dxpc:GridViewCommandColumn ShowInCustomizationForm="True" Caption="Editar" VisibleIndex="0" ShowEditButton="True" ShowNewButtonInHeader="True"></dxpc:GridViewCommandColumn>
                <dxpc:GridViewDataTextColumn FieldName="PERIODO" ShowInCustomizationForm="True" Caption="Per&#237;odo" VisibleIndex="3"></dxpc:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ID_PERIODO" ReadOnly="True" Visible="False"
                    VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Período" FieldName="PERIODO" VisibleIndex="2">
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <Templates>
                <FooterRow>
                    <input id="btnAdd" type="button" runat="server" value="Novo" onclick="gridPeriodos.AddNewRow();" />
                </FooterRow>
            </Templates>
        </dxwgv:ASPxGridView>
        <asp:SqlDataSource ID="sql_periodos" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            DeleteCommand="DELETE FROM PERIODOS WHERE ID_PERIODO = @ID_PERIODO" InsertCommand="INSERT INTO PERIODOS (PERIODO) VALUES (@PERIODO)"
            SelectCommand="SELECT ID_PERIODO, PERIODO FROM PERIODOS" UpdateCommand="UPDATE PERIODOS SET PERIODO = @PERIODO WHERE ID_PERIODO = @ID_PERIODO">
            <DeleteParameters>
                <asp:Parameter Name="ID_PERIODO" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="PERIODO" Type="String" />
                <asp:Parameter Name="ID_PERIODO" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="PERIODO" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <!-- Antigo DataSource -->
        <%--        <asp:AccessDataSource ID="access_periodos" runat="server" DataFile="~/App_Data/banco.mdb"
            DeleteCommand="DELETE FROM PERIODOS WHERE [id_periodo] = ?" InsertCommand="INSERT INTO [periodos] ( [periodo]) VALUES ( ?)"
            SelectCommand="SELECT [id_periodo], [periodo] FROM [periodos]" UpdateCommand="UPDATE [periodos] SET [periodo] = ? WHERE [id_periodo] = ?">
            <DeleteParameters>
                <asp:Parameter Name="id_periodo" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="periodo" Type="String" />
                <asp:Parameter Name="id_periodo" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="periodo" Type="String" />
            </InsertParameters>
        </asp:AccessDataSource>--%>
    </fieldset>
</asp:Content>
