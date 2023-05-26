<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" Inherits="LigaPaulista.Site.Admin.EntidadesAdm"
    CodeBehind="~/adm/EntidadesAdm.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <legend>Entidades</legend>
        <dxwgv:ASPxGridView ID="gridEntidades" runat="server" ClientInstanceName="grid"
            AutoGenerateColumns="False" DataSourceID="sql_entidades"
            KeyFieldName="ID_ENTIDADE" ClientIDMode="AutoID" OnInitNewRow="gridEntidades_InitNewRow">
            <SettingsAdaptivity>
                <AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
            </SettingsAdaptivity>

            <Templates>
                <StatusBar>
                    <input id="btnAdd" type="button" value="Novo" onclick="grid.AddNewRow();" />
                </StatusBar>
            </Templates>
            <SettingsEditing EditFormColumnCount="4" Mode="PopupEditForm"
                PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormModal="True"
                PopupEditFormVerticalAlign="WindowCenter" PopupEditFormWidth="900px" />
            <Settings ShowStatusBar="Visible" />
            <SettingsText CommandCancel="Cancelar" CommandEdit="Editar" CommandNew="Novo" CommandUpdate="Gravar"
                EmptyDataRow="Sem entidades cadastradas." />
            <SettingsPager PageSize="15">
            </SettingsPager>

            <EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowDeleteButton="True" />
                <dxwgv:GridViewDataTextColumn FieldName="ID_ENTIDADE" ReadOnly="True"
                    VisibleIndex="0">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ENTIDADE" VisibleIndex="1">
                    <EditFormSettings ColumnSpan="2" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="FILIADA" Visible="False"
                    VisibleIndex="2">
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="CNPJ" Visible="False" VisibleIndex="3">
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ENDERECO" Visible="False"
                    VisibleIndex="4">
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="NUMERO" Visible="False"
                    VisibleIndex="5">
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="COMPLEMENTO" Visible="False"
                    VisibleIndex="6">
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="BAIRRO" Visible="False"
                    VisibleIndex="7">
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="CIDADE" Visible="False"
                    VisibleIndex="8">
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ESTADO" Visible="False"
                    VisibleIndex="9">
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="CEP" Visible="False" VisibleIndex="10">
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="TELEFONE" VisibleIndex="11">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="CELULAR" VisibleIndex="12">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="SITE" VisibleIndex="13">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="EMAIL" VisibleIndex="14">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="REPRESENTANTELEGAL" VisibleIndex="15">
                    <EditFormSettings ColumnSpan="2" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="TELEFONELEGAL" VisibleIndex="16">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="EMAILLEGAL" VisibleIndex="17">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="REPRESENTANTE1" VisibleIndex="18">
                    <EditFormSettings ColumnSpan="2" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="TELEFONE1" VisibleIndex="19">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="EMAIL1" VisibleIndex="20">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="REPRESENTANTE2" VisibleIndex="21">
                    <EditFormSettings ColumnSpan="2" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="TELEFONE2" VisibleIndex="22">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="EMAIL2" VisibleIndex="23">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="REPRESENTANTE3" VisibleIndex="24">
                    <EditFormSettings ColumnSpan="2" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="TELEFONE3" VisibleIndex="25">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="EMAIL3" VisibleIndex="26">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="SENHA" VisibleIndex="27">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataCheckColumn FieldName="ATIVO" VisibleIndex="28">
                    <DataItemTemplate>
                        <dxwgv:ASPxCheckBox ID="chk" runat="server" ValueType="System.Int32"
                            ValueChecked="1" ValueUnchecked="0" Value='<%# Eval("ATIVO") %>'>
                        </dxwgv:ASPxCheckBox>
                    </DataItemTemplate>
                    <EditFormSettings Visible="True" />
                </dxwgv:GridViewDataCheckColumn>
            </Columns>
        </dxwgv:ASPxGridView>
        <asp:SqlDataSource ID="sql_entidades" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            DeleteCommand="DELETE FROM [ENTIDADES] WHERE [ID_ENTIDADE] = @ID_ENTIDADE" InsertCommand="INSERT INTO [ENTIDADES] ([ENTIDADE], [FILIADA], [CNPJ], [ENDERECO], [NUMERO], [COMPLEMENTO], [BAIRRO], [CIDADE], [ESTADO], [CEP], [TELEFONE], [CELULAR], [SITE], [EMAIL], [REPRESENTANTELEGAL], [TELEFONELEGAL], [EMAILLEGAL], [REPRESENTANTE1], [TELEFONE1], [EMAIL1], [REPRESENTANTE2], [TELEFONE2], [EMAIL2], [REPRESENTANTE3], [TELEFONE3], [EMAIL3], [SENHA], [ATIVO]) VALUES (@ENTIDADE, @FILIADA, @CNPJ, @ENDERECO, @NUMERO, @COMPLEMENTO, @BAIRRO, @CIDADE, @ESTADO, @CEP, @TELEFONE, @CELULAR, @SITE, @EMAIL, @REPRESENTANTELEGAL, @TELEFONELEGAL, @EMAILLEGAL, @REPRESENTANTE1, @TELEFONE1, @EMAIL1, @REPRESENTANTE2, @TELEFONE2, @EMAIL2, @REPRESENTANTE3, @TELEFONE3, @EMAIL3, @SENHA, @ATIVO)"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [ENTIDADES] ORDER BY [ENTIDADE]"
            UpdateCommand="UPDATE [ENTIDADES] SET [ENTIDADE] = @ENTIDADE, [FILIADA] = @FILIADA, [CNPJ] = @CNPJ, [ENDERECO] = @ENDERECO, [NUMERO] = @NUMERO, [COMPLEMENTO] = @COMPLEMENTO, [BAIRRO] = @BAIRRO, [CIDADE] = @CIDADE, [ESTADO] = @ESTADO, [CEP] = @CEP, [TELEFONE] = @TELEFONE, [CELULAR] = @CELULAR, [SITE] = @SITE, [EMAIL] = @EMAIL, [REPRESENTANTELEGAL] = @REPRESENTANTELEGAL, [TELEFONELEGAL] = @TELEFONELEGAL, [EMAILLEGAL] = @EMAILLEGAL, [REPRESENTANTE1] = @REPRESENTANTE1, [TELEFONE1] = @TELEFONE1, [EMAIL1] = @EMAIL1, [REPRESENTANTE2] = @REPRESENTANTE2, [TELEFONE2] = @TELEFONE2, [EMAIL2] = @EMAIL2, [REPRESENTANTE3] = @REPRESENTANTE3, [TELEFONE3] = @TELEFONE3, [EMAIL3] = @EMAIL3, [SENHA] = @SENHA, ATIVO = @ATIVO WHERE [ID_ENTIDADE] = @ID_ENTIDADE">
            <DeleteParameters>
                <asp:Parameter Name="ID_ENTIDADE" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ENTIDADE" Type="String" />
                <asp:Parameter Name="FILIADA" Type="String" />
                <asp:Parameter Name="CNPJ" Type="String" />
                <asp:Parameter Name="ENDERECO" Type="String" />
                <asp:Parameter Name="NUMERO" Type="String" />
                <asp:Parameter Name="COMPLEMENTO" Type="String" />
                <asp:Parameter Name="BAIRRO" Type="String" />
                <asp:Parameter Name="CIDADE" Type="String" />
                <asp:Parameter Name="ESTADO" Type="String" />
                <asp:Parameter Name="CEP" Type="String" />
                <asp:Parameter Name="TELEFONE" Type="String" />
                <asp:Parameter Name="CELULAR" Type="String" />
                <asp:Parameter Name="SITE" Type="String" />
                <asp:Parameter Name="EMAIL" Type="String" />
                <asp:Parameter Name="REPRESENTANTELEGAL" Type="String" />
                <asp:Parameter Name="TELEFONELEGAL" Type="String" />
                <asp:Parameter Name="EMAILLEGAL" Type="String" />
                <asp:Parameter Name="REPRESENTANTE1" Type="String" />
                <asp:Parameter Name="TELEFONE1" Type="String" />
                <asp:Parameter Name="EMAIL1" Type="String" />
                <asp:Parameter Name="REPRESENTANTE2" Type="String" />
                <asp:Parameter Name="TELEFONE2" Type="String" />
                <asp:Parameter Name="EMAIL2" Type="String" />
                <asp:Parameter Name="REPRESENTANTE3" Type="String" />
                <asp:Parameter Name="TELEFONE3" Type="String" />
                <asp:Parameter Name="EMAIL3" Type="String" />
                <asp:Parameter Name="SENHA" Type="String" />
                <asp:Parameter Name="ATIVO" Type="Int32" />
                <asp:Parameter Name="ID_ENTIDADE" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ENTIDADE" Type="String" />
                <asp:Parameter Name="FILIADA" Type="String" />
                <asp:Parameter Name="CNPJ" Type="String" />
                <asp:Parameter Name="ENDERECO" Type="String" />
                <asp:Parameter Name="NUMERO" Type="String" />
                <asp:Parameter Name="COMPLEMENTO" Type="String" />
                <asp:Parameter Name="BAIRRO" Type="String" />
                <asp:Parameter Name="CIDADE" Type="String" />
                <asp:Parameter Name="ESTADO" Type="String" />
                <asp:Parameter Name="CEP" Type="String" />
                <asp:Parameter Name="TELEFONE" Type="String" />
                <asp:Parameter Name="CELULAR" Type="String" />
                <asp:Parameter Name="SITE" Type="String" />
                <asp:Parameter Name="EMAIL" Type="String" />
                <asp:Parameter Name="REPRESENTANTELEGAL" Type="String" />
                <asp:Parameter Name="TELEFONELEGAL" Type="String" />
                <asp:Parameter Name="EMAILLEGAL" Type="String" />
                <asp:Parameter Name="REPRESENTANTE1" Type="String" />
                <asp:Parameter Name="TELEFONE1" Type="String" />
                <asp:Parameter Name="EMAIL1" Type="String" />
                <asp:Parameter Name="REPRESENTANTE2" Type="String" />
                <asp:Parameter Name="TELEFONE2" Type="String" />
                <asp:Parameter Name="EMAIL2" Type="String" />
                <asp:Parameter Name="REPRESENTANTE3" Type="String" />
                <asp:Parameter Name="TELEFONE3" Type="String" />
                <asp:Parameter Name="EMAIL3" Type="String" />
                <asp:Parameter Name="SENHA" Type="String" />
                <asp:Parameter Name="ATIVO" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
        &nbsp;
    </fieldset>
</asp:Content>

