<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="grupos.aspx.cs" Inherits="LigaPaulista.Site.Admin.Grupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Grupos
            <asp:Label ID="lblModalidade" runat="server" /></legend>
        <h3>
            <asp:Label ID="lbltitulo" Text="" runat="server"></asp:Label></h3>
        <!-- Grid 1-->
        <dxwgv:ASPxGridView ID="Grid1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID_CAMPEONATO; ID_GRUPO" 
            DataSourceID="SqlGruposporCampeonato" ClientInstanceName="Grid1">
            <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
            <SettingsDetail ShowDetailRow="True" />
            <Templates>
                <DetailRow>
                    <!-- Grid 2 -->
                    <dxwgv:ASPxGridView ID="Grid2" runat="server" OnBeforePerformDataSelect="gridGrupos_DataSelect"
                        DataSourceID="SqlFaculdades" AutoGenerateColumns="False" 
                        KeyFieldName="ID_GRUPOS_ENTIDADES" ClientInstanceName="Grid2">
                        <Settings ShowFooter="true" />
                        <SettingsBehavior ConfirmDelete="True" />
                        <SettingsCommandButton>
                            <NewButton Text="Novo">
                            </NewButton>
                            <CancelButton Text="Cancelar">
                            </CancelButton>
                            <EditButton Text="Editar">
                            </EditButton>
                            <DeleteButton Text="Excluir">
                            </DeleteButton>
                        </SettingsCommandButton>
                        <SettingsText EmptyDataRow="Não há faculdades!" />
                        <SettingsPager Mode="ShowAllRecords" />
                        <Templates>
                            <FooterRow>
                                <input type="button" value="Novo" onclick="Grid2.AddNewRow();" />
                            </FooterRow>
                        </Templates>
                        <Columns>
                            <dxw:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" ShowDeleteButton="True">
                            </dxw:GridViewCommandColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="ID_GRUPOS_ENTIDADES" VisibleIndex="1" EditFormSettings-Visible="False" ReadOnly="True" Visible="False" UnboundType="Integer">
                                <EditFormSettings Visible="False" />
                            </dxwgv:GridViewDataTextColumn>
                            <dxw:GridViewDataTextColumn FieldName="ID_GRUPO" Visible="False" VisibleIndex="2" UnboundType="Integer">
                            </dxw:GridViewDataTextColumn>
                            <dxw:GridViewDataComboBoxColumn Caption="Entidade" FieldName="ID_ENTIDADE" VisibleIndex="4">
                                <PropertiesComboBox DataSourceID="SqlEntidades" TextField="ENTIDADE" ValueField="ID_ENTIDADE">
                                </PropertiesComboBox>
                            </dxw:GridViewDataComboBoxColumn>
                        </Columns>
                    </dxwgv:ASPxGridView>
                    <!-- Fim Grid 2--->
                </DetailRow>
                <FooterRow>
                    <input type="button" value="Novo" onclick="Grid1.AddNewRow();" style="width: 40px" />
                </FooterRow>
            </Templates>
            <SettingsPager Mode="ShowAllRecords" />
            <Settings ShowFooter="true" />
            <SettingsBehavior ConfirmDelete="True"></SettingsBehavior>

            <SettingsCommandButton>
                <NewButton Text="Novo">
                </NewButton>
                <EditButton Text="Editar"></EditButton>
                <DeleteButton Text="Excluir">
                </DeleteButton>
            </SettingsCommandButton>
            <SettingsText EmptyDataRow="Não há grupos!" />
            <Columns>
                <dxw:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0">
                </dxw:GridViewCommandColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ID_CAMPEONATO" VisibleIndex="1" Visible="False">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ID_GRUPO" VisibleIndex="2" Visible="False">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="GRUPO" VisibleIndex="3" MinWidth="150">
                </dxwgv:GridViewDataTextColumn>
                <dxw:GridViewDataCheckColumn FieldName="ESCONDER" VisibleIndex="4">
                </dxw:GridViewDataCheckColumn>
            </Columns>
        </dxwgv:ASPxGridView>
        <!-- Fim Grid 1 -->
        <!-- Data Source do Grid 2 -->
        <asp:SqlDataSource ID="SqlFaculdades" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
            SelectCommand="SELECT GE.ID_GRUPOS_ENTIDADES, GE.ID_GRUPO, GE.ID_ENTIDADE, E.ENTIDADE AS FACULDADE FROM GRUPOS_ENTIDADES AS GE INNER JOIN ENTIDADES AS E ON GE.ID_ENTIDADE = E.ID_ENTIDADE WHERE (GE.ID_GRUPO = @id_Grupo)"
            InsertCommand="INSERT INTO GRUPOS_ENTIDADES(ID_GRUPO, ID_ENTIDADE) VALUES (@id_Grupo, @id_entidade)"
            DeleteCommand="DELETE FROM GRUPOS_ENTIDADES WHERE (ID_GRUPOS_ENTIDADES = @ID_GRUPOS_ENTIDADES)"
            UpdateCommand="UPDATE GRUPOS_ENTIDADES SET ID_ENTIDADE = @ID_ENTIDADE WHERE (ID_GRUPOS_ENTIDADES = @ID_GRUPOS_ENTIDADES)">
            <SelectParameters>
                <asp:SessionParameter Name="id_Grupo" SessionField="id_Grupo" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="ID_GRUPOS_ENTIDADES" />
            </DeleteParameters>
            <InsertParameters>
                <asp:SessionParameter Name="id_Grupo" SessionField="id_Grupo" />
                <asp:Parameter Name="id_entidade" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ID_ENTIDADE" />
                <asp:Parameter Name="ID_GRUPOS_ENTIDADES" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <!-- Data Source Grid 1 -->
        <asp:SqlDataSource ID="SqlGruposporCampeonato" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT gc.ID_CAMPEONATO, gc.ID_GRUPO, g.GRUPO, g.ESCONDER FROM GRUPO_CAMPEONATO AS gc INNER JOIN GRUPOS AS g ON g.ID_GRUPO = gc.ID_GRUPO WHERE (gc.ID_CAMPEONATO = @ID_CAMPEONATO)"
            InsertCommand="stp_IncluiGrupoemCampeonato" InsertCommandType="StoredProcedure"
            DeleteCommand="DELETE FROM GRUPO_CAMPEONATO WHERE (ID_GRUPO = @ID_GRUPO) AND (ID_CAMPEONATO = @ID_CAMPEONATO)"
            UpdateCommand="UPDATE GRUPOS SET GRUPO = @GRUPO, ESCONDER = @ESCONDER WHERE (ID_GRUPO = @ID_GRUPO)">
            <SelectParameters>
                <asp:QueryStringParameter Name="ID_CAMPEONATO" QueryStringField="ID_CAMPEONATO" DefaultValue="60" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="GRUPO" />
                <asp:QueryStringParameter Name="id_campeonato" QueryStringField="id_campeonato" />
                <asp:Parameter Name="esconder" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="GRUPO" Type="String" />
                <asp:Parameter Name="ESCONDER" />
                <asp:SessionParameter Name="ID_GRUPO" SessionField="id_Grupo" />
            </UpdateParameters>
            <DeleteParameters>
                <asp:SessionParameter Name="ID_GRUPO" SessionField="id_Grupo" />
                <asp:Parameter Name="ID_CAMPEONATO" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <!-- Data Source do Combo dentro do Grid 2-->
        <asp:SqlDataSource ID="SqlEntidades" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [ID_ENTIDADE], [ENTIDADE] FROM [ENTIDADES] order by ENTIDADE"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlGrupos" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [ID_GRUPO], [GRUPO], [ESCONDER] FROM [GRUPOS]"></asp:SqlDataSource>
        <br />
        <a href="modalidades.aspx">Voltar</a>
    </fieldset>
</asp:Content>
