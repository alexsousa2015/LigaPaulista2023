<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="jogos.aspx.cs" Inherits="LigaPaulista.Site.Admin.jogos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Jogos</legend>
        <br />
        <asp:UpdateProgress ID="pnlloading" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0" runat="server">
            <ProgressTemplate>Carregando...</ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="background-color: #efefef; border-bottom: 1px solid #ccc; padding: 10px;
                    height: 40px; font-size: 16px;">
                    <!-- Drop Modalidade --->
                    <div style="margin-left: 10px; float: left; width: 30%; text-align: center">
                        <b>Modalidade</b><br />
                        <asp:DropDownList ID="ddlModalidades" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModalidades_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <!-- Drop Campeonato --->
                    <div style="margin-left: 10px; float: left; width: 30%; text-align: center">
                        <b>Campeonato</b><br />
                        <asp:DropDownList ID="ddlCampeonatos" runat="server" Enabled="false" OnSelectedIndexChanged="ddlCampeonatos_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <!-- Drop Grupos --->
                    <div style="margin-left: 10px; float: left; width: 30%; text-align: center">
                        <b>Grupos</b><br />
                        <asp:DropDownList ID="ddlGrupos" runat="server" Enabled="false" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <!-- Panel -->
                <div style="margin-top: 10px;">
                    <asp:Panel runat="server" ID="pJogos" Visible="false">
                        <!-- Grid --->
                        <dxwgv:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" KeyFieldName="ID_JOGO"
                            DataSourceID="SqlTabela" ClientInstanceName="Grid" Width="100%">
                            <SettingsEditing Mode="Inline" />
                            <SettingsCommandButton>
                                <NewButton Text="Novo">
                                </NewButton>
                                <UpdateButton Text="Gravar">
                                </UpdateButton>
                                <CancelButton Text="Cancelar">
                                </CancelButton>
                                <EditButton Text="Editar">
                                </EditButton>
                                <DeleteButton Text="Excluir">
                                </DeleteButton>
                                <SelectButton Text="Selecionar">
                                </SelectButton>
                            </SettingsCommandButton>
                            <SettingsText EmptyDataRow="Não há jogos!" GroupPanel="Arraste a Coluna para filtrar!" />
                            <Settings ShowGroupPanel="true" ShowFooter="true" />
                            <SettingsPager AlwaysShowPager="false" Mode="ShowAllRecords" />
                            <Templates>
                                <FooterRow>
                                    <input type="button" value="Novo" onclick="Grid.AddNewRow();" style="width: 40px;" />
                                </FooterRow>
                            </Templates>
                            <Columns>
                                <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowCancelButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowUpdateButton="True">
                                    
                                </dxwgv:GridViewCommandColumn>
                                <dxwgv:GridViewDataTextColumn FieldName="ID_JOGO" VisibleIndex="1" ReadOnly="True"
                                    Caption="Código" Visible="False">
                                    <EditFormSettings Visible="False" />
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataComboBoxColumn FieldName="ID_LOCALIDADE" VisibleIndex="2" Caption="Localidade">
                                    <PropertiesComboBox DataSourceID="SqlLocalidades" TextField="Localidade" ValueField="id_localidade">
                                    </PropertiesComboBox>
                                </dxwgv:GridViewDataComboBoxColumn>
                                <dxwgv:GridViewDataDateColumn FieldName="DATA" VisibleIndex="3">
                                </dxwgv:GridViewDataDateColumn>
                                <dxwgv:GridViewDataTextColumn FieldName="HORA" VisibleIndex="4" Caption="Hora">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataComboBoxColumn FieldName="TIME1" Caption="Time 1" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="SqlTimes" TextField="Entidade" ValueField="id_Entidade">
                                    </PropertiesComboBox>
                                </dxwgv:GridViewDataComboBoxColumn>
                                <dxwgv:GridViewDataTextColumn FieldName="PLACAR_TIME1" Caption="Placar 1" VisibleIndex="6">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn FieldName="PLACAR_TIME2" Caption="Placar 2" VisibleIndex="7">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataComboBoxColumn FieldName="TIME2" Caption="Time 2" VisibleIndex="8">
                                    <PropertiesComboBox DataSourceID="SqlTimes" TextField="Entidade" ValueField="id_Entidade">
                                    </PropertiesComboBox>
                                </dxwgv:GridViewDataComboBoxColumn>
                                
                                <dxwgv:GridViewDataTextColumn FieldName="OBSERVACOES" VisibleIndex="10">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn FieldName="" VisibleIndex="11" Caption="Ficha Técnica">
                                    <DataItemTemplate>
                                        <a href="jogos-ficha-tecnica.aspx?idjogo=<%#Eval("ID_JOGO")%>" target="_blank">Editar</a>
                                    </DataItemTemplate>
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataComboBoxColumn FieldName="STATUS" VisibleIndex="12">
                                    <PropertiesComboBox ValueType="System.String">
                                        <Items>
                                            <dxe:ListEditItem Text="Não Realizado" Value="" />
                                            <dxe:ListEditItem Text="Realizado Normal" Value="1" />
                                            <dxe:ListEditItem Text="Realizado W.O." Value="2" />
                                        </Items>
                                    </PropertiesComboBox>
                                </dxwgv:GridViewDataComboBoxColumn>
                                <dxwgv:GridViewDataComboBoxColumn FieldName="WOTIME1" VisibleIndex="13">
                                    <PropertiesComboBox ValueType="System.Boolean">
                                        <Items>
                                            <dxe:ListEditItem Text="O" Value="true" />
                                            <dxe:ListEditItem Text="W" Value="false" />
                                        </Items>
                                    </PropertiesComboBox>
                                </dxwgv:GridViewDataComboBoxColumn>
                                <dxwgv:GridViewDataComboBoxColumn FieldName="WOTIME2" VisibleIndex="14">
                                    <PropertiesComboBox ValueType="System.Boolean">
                                        <Items>
                                            <dxe:ListEditItem Text="O" Value="true" />
                                            <dxe:ListEditItem Text="W" Value="false" />
                                        </Items>
                                    </PropertiesComboBox>
                                </dxwgv:GridViewDataComboBoxColumn>
                            </Columns>
                            <Styles>
                                <Header BackColor="#efefef">
                                </Header>
                                <AlternatingRow BackColor="#FFFAEF">
                                </AlternatingRow>
                            </Styles>
                        </dxwgv:ASPxGridView>
                    </asp:Panel>
                </div>
                <!-- DataSource's --->
                <!-- Source Localidades --->
                <asp:SqlDataSource ID="SqlLocalidades" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>"
                    SelectCommand="SELECT * FROM [LOCALIDADES]"></asp:SqlDataSource>
                <!-- Source Times --->
                <!-- select ge.ID_GRUPO,e.ID_ENTIDADE,e.ENTIDADE from GRUPOS_ENTIDADES ge join ENTIDADES e on e.ID_ENTIDADE = ge.ID_ENTIDADE where ID_GRUPO = @id_grupo -->
                <asp:SqlDataSource ID="SqlTimes" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="select e.ID_ENTIDADE,e.ENTIDADE
                                    from ENTIDADES e
                                    join [dbo].[GRUPOS_ENTIDADES] ge on ge.ID_ENTIDADE = e.ID_ENTIDADE
                                    join [dbo].[GRUPO_CAMPEONATO] gc on gc.ID_GRUPO = ge.ID_GRUPO
                                    join [dbo].[CAMPEONATOS] c on c.ID_CAMPEONATO = gc.ID_CAMPEONATO
                                    where c.ID_MODALIDADE = @ID_MODALIDADE and c.ID_CAMPEONATO = @ID_CAMPEONATO
                                    order by e.ENTIDADE">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlModalidades" Name="ID_MODALIDADE" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="ddlCampeonatos" Name="ID_CAMPEONATO" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <!-- Source Tabela --->
                <asp:SqlDataSource ID="SqlTabela" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    InsertCommand="stp_IncluiConfrontos" InsertCommandType="StoredProcedure" SelectCommand="stp_RetornaConfrontosAdm"
                    SelectCommandType="StoredProcedure" UpdateCommand="stp_AlteraConfrontos" UpdateCommandType="StoredProcedure"
                    DeleteCommand="DELETE FROM JOGOS WHERE ID_JOGO=@ID_JOGO">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlGrupos" Name="ID_GRUPO" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="data" />
                        <asp:Parameter Name="hora" />
                        <asp:ControlParameter ControlID="ddlGrupos" Name="id_grupo" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:Parameter Name="id_localidade" Type="Int32" />
                        <asp:Parameter Name="time1" Type="Int32" />
                        <asp:Parameter Name="time2" Type="Int32" />
                        <asp:Parameter Name="placar_time1" Type="Int32" />
                        <asp:Parameter Name="placar_time2" Type="Int32" />
                        <asp:Parameter Name="observacoes" />
                        <asp:Parameter Name="id_jogo" Type="Int32" />

                        <asp:Parameter Name="status" />
                        <asp:Parameter Name="wotime1" />
                        <asp:Parameter Name="wotime2" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="data" Type="DateTime" />
                        <asp:Parameter Name="hora" />
                        <asp:Parameter Name="time1" Type="Int32" />
                        <asp:Parameter Name="placar_time1" Type="Int32" />
                        <asp:Parameter Name="placar_time2" Type="Int32" />
                        <asp:Parameter Name="time2" Type="Int32" />

                        <asp:Parameter Name="id_localidade" Type="Int32" />
                        <asp:ControlParameter ControlID="ddlGrupos" Name="id_grupo" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="ddlCampeonatos" Name="id_campeonato" PropertyName="SelectedValue"
                            Type="Int32" />
                        <asp:ControlParameter ControlID="ddlModalidades" Name="ID_MODALIDADE" PropertyName="SelectedValue" />
                        <asp:Parameter Name="observacoes" />
                        
                        <asp:Parameter Name="status" />
                        <asp:Parameter Name="wotime1" />
                        <asp:Parameter Name="wotime2" />
                    </InsertParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="ID_JOGO" />
                    </DeleteParameters>
                </asp:SqlDataSource>
                <br />
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <div style="display:none;">
        <dxwgv:ASPxGridView ID="GridFake" runat="server" AutoGenerateColumns="False" ClientInstanceName="GridFake" Width="100%">
        </dxwgv:ASPxGridView>
    </div>
</asp:Content>
