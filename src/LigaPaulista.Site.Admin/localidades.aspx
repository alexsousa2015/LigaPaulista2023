<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="localidades.aspx.cs" Inherits="LigaPaulista.Site.Admin.localidade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Localidades</legend>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="SqlDataSource1" KeyFieldName="ID_LOCALIDADE" ClientInstanceName="Grid">
            <Settings ShowFooter="true" />
            <SettingsText EmptyDataRow="Não há localidades!" />
            <Templates>
                <FooterRow>
                    <input type="button" value="Novo" onclick="Grid.AddNewRow();" style="width: 40px" />
                </FooterRow>
            </Templates>
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="true" ShowCancelButton="true" ShowUpdateButton="True"/>
                <dxwgv:GridViewDataTextColumn FieldName="ID_LOCALIDADE" ReadOnly="True" VisibleIndex="1"
                    Caption="Código">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="LOCALIDADE" VisibleIndex="2" Caption="Localidade">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ENDERECO" VisibleIndex="3" Caption="Endereco">
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <SettingsCommandButton>
                <EditButton Text="Editar"/>
                <CancelButton Text="Cancelar"/>
                <UpdateButton Text="Gravar"/>
                <CancelButton Text="Cancelar"/>
            </SettingsCommandButton>
        </dxwgv:ASPxGridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            DeleteCommand="DELETE FROM [LOCALIDADES] WHERE [ID_LOCALIDADE] = @ID_LOCALIDADE"
            InsertCommand="INSERT INTO [LOCALIDADES] ([LOCALIDADE], ENDERECO) VALUES (@LOCALIDADE, @ENDERECO)"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [LOCALIDADES]"
            UpdateCommand="UPDATE [LOCALIDADES] SET [LOCALIDADE] = @LOCALIDADE, ENDERECO = @ENDERECO WHERE [ID_LOCALIDADE] = @ID_LOCALIDADE">
            <DeleteParameters>
                <asp:Parameter Name="ID_LOCALIDADE" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ENDERECO" Type="String" />
                <asp:Parameter Name="LOCALIDADE" Type="String" />
                <asp:Parameter Name="ID_LOCALIDADE" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ENDERECO" Type="String" />
                <asp:Parameter Name="LOCALIDADE" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    </fieldset>
</asp:Content>
