<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="LigaPaulista.Site.Admin.cadastro" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button runat="server" ID="btnExport" Text="Exportar Dados" OnClick="ExportarDados" Width="150px" />
    <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
    KeyFieldName="ID_CADASTRO">
        <SettingsCommandButton>
            <ApplyFilterButton Text="Aplicar Filtro">
            </ApplyFilterButton>
            <ClearFilterButton Text="Limpar Filtro">
            </ClearFilterButton>
            <NewButton Text="Novo">
            </NewButton>
            <CancelButton Text="Cancelar">
            </CancelButton>
            <EditButton Text="Editar">
            </EditButton>
            <DeleteButton Text="Excluir">
            </DeleteButton>
        </SettingsCommandButton>
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButton="True" ShowClearFilterButton="True" ShowDeleteButton="True"/>
            <dxwgv:GridViewDataTextColumn FieldName="ID_CADASTRO" ReadOnly="True" 
                VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="NOME" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SOBRENOME" VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="EMAIL" VisibleIndex="4">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="TELEFONE" VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CELULAR" VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="NASC" VisibleIndex="7">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="IDADE" VisibleIndex="8">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SEXO" VisibleIndex="9">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CIVIL" VisibleIndex="10">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ENDERECO" VisibleIndex="11">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="NUMERO" VisibleIndex="12">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="COMPLEMENTO" VisibleIndex="13">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="BAIRRO" VisibleIndex="14">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CEP" VisibleIndex="15">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CIDADE" VisibleIndex="16">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ESTADO" VisibleIndex="17">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="PAIS" VisibleIndex="18">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CPF" VisibleIndex="19">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="RG" VisibleIndex="20">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="TITULO" VisibleIndex="21">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataComboBoxColumn FieldName="FACULDADE" VisibleIndex="22" Caption="ENTIDADE">
                <PropertiesComboBox DataSourceID="SqlDataSource2" TextField="ENTIDADE" 
                    ValueField="ID_ENTIDADE" ValueType="System.String">
                </PropertiesComboBox>
            </dxwgv:GridViewDataComboBoxColumn>
            <dxwgv:GridViewDataComboBoxColumn FieldName="ORIGEM" VisibleIndex="23" Caption="STATUS ATLETA">
                <PropertiesComboBox ValueType="System.String">
                        <Items>
                            <dxe:ListEditItem Text="Não Validado" Value="0" />
                            <dxe:ListEditItem Text="Validado" Value="1" />
                        </Items>
                    </PropertiesComboBox>
            </dxwgv:GridViewDataComboBoxColumn>
            <dxwgv:GridViewDataDateColumn FieldName="DATA" VisibleIndex="24">
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SENHA" VisibleIndex="25">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="FOTO" VisibleIndex="26">
                <DataItemTemplate>
                        <img src="http://ligapaulista.com/ligapaulista/downloads/usuarios/thumbs/<%#Eval("FOTO") %>"/>
                    </DataItemTemplate>
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Settings ShowFilterRow="True" ShowFilterBar="Visible" />
        <SettingsPager PageSize="50" />
        <SettingsBehavior ConfirmDelete="True" />
    </dxwgv:ASPxGridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>" 
    DeleteCommand="DELETE FROM [CADASTRO] WHERE [ID_CADASTRO] = @ID_CADASTRO" 
    InsertCommand="INSERT INTO [CADASTRO] ([NOME], [SOBRENOME], [EMAIL], [TELEFONE], [CELULAR], [NASC], [IDADE], [SEXO], [CIVIL], [ENDERECO], [NUMERO], [COMPLEMENTO], [BAIRRO], [CEP], [CIDADE], [ESTADO], [PAIS], [CPF], [RG], [TITULO], [FACULDADE], [ORIGEM], [DATA], [SENHA], [FOTO]) VALUES (@NOME, @SOBRENOME, @EMAIL, @TELEFONE, @CELULAR, @NASC, @IDADE, @SEXO, @CIVIL, @ENDERECO, @NUMERO, @COMPLEMENTO, @BAIRRO, @CEP, @CIDADE, @ESTADO, @PAIS, @CPF, @RG, @TITULO, @FACULDADE, @ORIGEM, @DATA, @SENHA, @FOTO)" 
    SelectCommand="SELECT * FROM [CADASTRO] ORDER BY [NOME]" 
    UpdateCommand="UPDATE [CADASTRO] SET [NOME] = @NOME, [SOBRENOME] = @SOBRENOME, [EMAIL] = @EMAIL, [TELEFONE] = @TELEFONE, [CELULAR] = @CELULAR, [NASC] = @NASC, [IDADE] = @IDADE, [SEXO] = @SEXO, [CIVIL] = @CIVIL, [ENDERECO] = @ENDERECO, [NUMERO] = @NUMERO, [COMPLEMENTO] = @COMPLEMENTO, [BAIRRO] = @BAIRRO, [CEP] = @CEP, [CIDADE] = @CIDADE, [ESTADO] = @ESTADO, [PAIS] = @PAIS, [CPF] = @CPF, [RG] = @RG, [TITULO] = @TITULO, [FACULDADE] = @FACULDADE, [ORIGEM] = @ORIGEM, [DATA] = @DATA, [SENHA] = @SENHA, [FOTO] = @FOTO WHERE [ID_CADASTRO] = @ID_CADASTRO">
    <DeleteParameters>
        <asp:Parameter Name="ID_CADASTRO" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="NOME" Type="String" />
        <asp:Parameter Name="SOBRENOME" Type="String" />
        <asp:Parameter Name="EMAIL" Type="String" />
        <asp:Parameter Name="TELEFONE" Type="String" />
        <asp:Parameter Name="CELULAR" Type="String" />
        <asp:Parameter Name="NASC" Type="String" />
        <asp:Parameter Name="IDADE" Type="String" />
        <asp:Parameter Name="SEXO" Type="String" />
        <asp:Parameter Name="CIVIL" Type="String" />
        <asp:Parameter Name="ENDERECO" Type="String" />
        <asp:Parameter Name="NUMERO" Type="String" />
        <asp:Parameter Name="COMPLEMENTO" Type="String" />
        <asp:Parameter Name="BAIRRO" Type="String" />
        <asp:Parameter Name="CEP" Type="String" />
        <asp:Parameter Name="CIDADE" Type="String" />
        <asp:Parameter Name="ESTADO" Type="String" />
        <asp:Parameter Name="PAIS" Type="String" />
        <asp:Parameter Name="CPF" Type="String" />
        <asp:Parameter Name="RG" Type="String" />
        <asp:Parameter Name="TITULO" Type="String" />
        <asp:Parameter Name="FACULDADE" Type="String" />
        <asp:Parameter Name="ORIGEM" Type="String" />
        <asp:Parameter Name="DATA" Type="DateTime" />
        <asp:Parameter Name="SENHA" Type="String" />
        <asp:Parameter Name="FOTO" Type="String" />
        <asp:Parameter Name="ID_CADASTRO" Type="Int32" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="NOME" Type="String" />
        <asp:Parameter Name="SOBRENOME" Type="String" />
        <asp:Parameter Name="EMAIL" Type="String" />
        <asp:Parameter Name="TELEFONE" Type="String" />
        <asp:Parameter Name="CELULAR" Type="String" />
        <asp:Parameter Name="NASC" Type="String" />
        <asp:Parameter Name="IDADE" Type="String" />
        <asp:Parameter Name="SEXO" Type="String" />
        <asp:Parameter Name="CIVIL" Type="String" />
        <asp:Parameter Name="ENDERECO" Type="String" />
        <asp:Parameter Name="NUMERO" Type="String" />
        <asp:Parameter Name="COMPLEMENTO" Type="String" />
        <asp:Parameter Name="BAIRRO" Type="String" />
        <asp:Parameter Name="CEP" Type="String" />
        <asp:Parameter Name="CIDADE" Type="String" />
        <asp:Parameter Name="ESTADO" Type="String" />
        <asp:Parameter Name="PAIS" Type="String" />
        <asp:Parameter Name="CPF" Type="String" />
        <asp:Parameter Name="RG" Type="String" />
        <asp:Parameter Name="TITULO" Type="String" />
        <asp:Parameter Name="FACULDADE" Type="String" />
        <asp:Parameter Name="ORIGEM" Type="String" />
        <asp:Parameter Name="DATA" Type="DateTime" />
        <asp:Parameter Name="SENHA" Type="String" />
        <asp:Parameter Name="FOTO" Type="String" />
    </InsertParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>" 
    SelectCommand="SELECT id_ENTIDADE, [ENTIDADE] FROM [ENTIDADES] ORDER BY [ENTIDADE]">
</asp:SqlDataSource>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" FileName="Cadastros">
    </dx:ASPxGridViewExporter>
</asp:Content>
