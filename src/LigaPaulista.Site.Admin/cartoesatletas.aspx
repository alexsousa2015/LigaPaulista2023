<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="cartoesatletas.aspx.cs" Inherits="LigaPaulista.Site.Admin.cartoesatletas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Cartões dos Atletas</legend>
        <br />
        <asp:UpdateProgress ID="pnlloading" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0" runat="server">
            <ProgressTemplate>Carregando...</ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="background-color: #efefef; border-bottom: 1px solid #ccc; padding: 10px;
                    height: 40px; font-size: 16px;">
                    <!-- Drop Modalidade --->
                    <div style="margin-left: 10px; float: left; width: 45%; text-align: center">
                        <b>Modalidade</b><br />
                        <asp:DropDownList ID="ddlModalidades" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModalidades_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <!-- Drop Campeonato --->
                    <div style="margin-left: 10px; float: left; width: 45%; text-align: center">
                        <b>Campeonato</b><br />
                        <asp:DropDownList ID="ddlCampeonatos" runat="server" Enabled="false" OnSelectedIndexChanged="ddlCampeonatos_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <!-- Drop Grupos --->
                </div>
                <br />
                <!-- Panel -->
                <div style="margin-top: 10px;">
                    <asp:Panel runat="server" ID="pCartoes" Visible="false">
                        <!-- Grid --->
                        <dxwgv:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" KeyFieldName="ID_CARTOESATLETAS"
                            DataSourceID="SqlCartoes" ClientInstanceName="Grid" Width="100%">
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
                            <Settings ShowFooter="true" />
                            <SettingsPager AlwaysShowPager="false" Mode="ShowAllRecords" />
                            <Templates>
                                <FooterRow>
                                    <input type="button" value="Novo" onclick="Grid.AddNewRow();" style="width: 40px;" />
                                </FooterRow>
                            </Templates>
                            <Columns>
                                <dxw:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0">
                                </dxw:GridViewCommandColumn>
                                <dxwgv:GridViewDataTextColumn FieldName="ID_CARTOESATLETAS" VisibleIndex="1" ReadOnly="True" Caption="ID">
                                    <EditFormSettings Visible="False" />
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn FieldName="ID_MODALIDADE" VisibleIndex="2" Visible="False">
                                </dxwgv:GridViewDataTextColumn>
                                
                                <dxwgv:GridViewDataTextColumn FieldName="ID_CAMPEONATO" VisibleIndex="3" Visible="False">
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn FieldName="ENTIDADE" VisibleIndex="4" Caption="Entidade" ReadOnly="True">
                                    <EditFormSettings Visible="False" />
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataDateColumn FieldName="DT_CARTAO_AMARELO_1" VisibleIndex="6" Caption="Dt. 1º Amarelo">
                                </dxwgv:GridViewDataDateColumn>
                                <dxw:GridViewDataDateColumn FieldName="DT_CARTAO_AMARELO_2" VisibleIndex="7" Caption="Dt. 2º Amarelo">
                                </dxw:GridViewDataDateColumn>
                                <dxw:GridViewDataDateColumn FieldName="DT_SUSPENSAO_AMARELO" VisibleIndex="8" Caption="Dt. Suspensão">
                                </dxw:GridViewDataDateColumn>
                                <dxw:GridViewDataDateColumn FieldName="DT_CARTAO_VERMELHO" VisibleIndex="10" Caption="Dt. Vermelho">
                                </dxw:GridViewDataDateColumn>
                                <dxw:GridViewDataDateColumn FieldName="DT_SUSPENSAO_VERMELHO" VisibleIndex="11" Caption="Dt. Suspensão">
                                </dxw:GridViewDataDateColumn>
                                <dxw:GridViewDataComboBoxColumn Caption="Atleta" FieldName="ID_CADASTRO" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="SqlAtletas" TextField="NOME_COMPLETO" ValueField="ID_CADASTRO">
                                    </PropertiesComboBox>
                                </dxw:GridViewDataComboBoxColumn>
                                <dxw:GridViewDataCheckColumn Caption="Cumpriu?" FieldName="CUMPRIU_SUSPENSAO_VERMELHO" VisibleIndex="12">
                                    <PropertiesCheckEdit DisplayTextChecked="Sim" DisplayTextUnchecked="Não">
                                    </PropertiesCheckEdit>
                                </dxw:GridViewDataCheckColumn>
                                <dxw:GridViewDataCheckColumn Caption="Cumpriu?" FieldName="CUMPRIU_SUSPENSAO_AMARELO" VisibleIndex="9">
                                    <PropertiesCheckEdit DisplayTextChecked="Sim" DisplayTextUnchecked="Não">
                                    </PropertiesCheckEdit>
                                </dxw:GridViewDataCheckColumn>
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
                <!-- Source Times --->
                <!-- select ge.ID_GRUPO,e.ID_ENTIDADE,e.ENTIDADE from GRUPOS_ENTIDADES ge join ENTIDADES e on e.ID_ENTIDADE = ge.ID_ENTIDADE where ID_GRUPO = @id_grupo -->
                <!-- Source Tabela --->
                <asp:SqlDataSource ID="SqlCartoes" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>" SelectCommand="SELECT CARTOES.ID_CARTOESATLETAS, 
CARTOES.ID_MODALIDADE, 
CARTOES.ID_CAMPEONATO, 
FACULDADE.ENTIDADE ,
CARTOES.ID_CADASTRO, 
CARTOES.DT_CARTAO_AMARELO_1, 
CARTOES.DT_CARTAO_AMARELO_2, 
CARTOES.DT_SUSPENSAO_AMARELO, 
CARTOES.CUMPRIU_SUSPENSAO_AMARELO, 
CARTOES.DT_CARTAO_VERMELHO, 
CARTOES.DT_SUSPENSAO_VERMELHO, 
CARTOES.CUMPRIU_SUSPENSAO_VERMELHO
FROM JOGOS_CARTOES_ATLETAS AS CARTOES 
INNER JOIN CADASTRO AS ATLETA ON CARTOES.ID_CADASTRO = ATLETA.ID_CADASTRO 
INNER JOIN ENTIDADES AS FACULDADE ON ATLETA.FACULDADE = FACULDADE.ID_ENTIDADE 
WHERE (CARTOES.ID_MODALIDADE = @IDMODALIDADE) AND (CARTOES.ID_CAMPEONATO = @IDCAMPEONATO)" DeleteCommand="DELETE FROM JOGOS_CARTOES_ATLETAS WHERE (ID_CARTOESATLETAS = @ID_CARTOESATLETAS)" InsertCommand="INSERT INTO JOGOS_CARTOES_ATLETAS(ID_MODALIDADE, ID_CAMPEONATO, ID_CADASTRO, DT_CARTAO_AMARELO_1, DT_CARTAO_AMARELO_2, DT_SUSPENSAO_AMARELO, CUMPRIU_SUSPENSAO_AMARELO, DT_CARTAO_VERMELHO, DT_SUSPENSAO_VERMELHO, CUMPRIU_SUSPENSAO_VERMELHO) VALUES (@ID_MODALIDADE, @ID_CAMPEONATO, @ID_CADASTRO, @DT_CARTAO_AMARELO_1, @DT_CARTAO_AMARELO_2, @DT_SUSPENSAO_AMARELO, @CUMPRIU_SUSPENSAO_AMARELO, @DT_CARTAO_VERMELHO, @DT_SUSPENSAO_VERMELHO, @CUMPRIU_SUSPENSAO_VERMELHO)" UpdateCommand="UPDATE JOGOS_CARTOES_ATLETAS SET ID_CADASTRO = @ID_CADASTRO, DT_CARTAO_AMARELO_1 = @DT_CARTAO_AMARELO_1, DT_CARTAO_AMARELO_2 = @DT_CARTAO_AMARELO_2, DT_SUSPENSAO_AMARELO = @DT_SUSPENSAO_AMARELO, CUMPRIU_SUSPENSAO_AMARELO = @CUMPRIU_SUSPENSAO_AMARELO, DT_CARTAO_VERMELHO = @DT_CARTAO_VERMELHO, DT_SUSPENSAO_VERMELHO = @DT_SUSPENSAO_VERMELHO, CUMPRIU_SUSPENSAO_VERMELHO = @CUMPRIU_SUSPENSAO_VERMELHO WHERE (ID_CARTOESATLETAS = @ID_CARTOESATLETAS)">
                    <DeleteParameters>
                        <asp:Parameter Name="ID_CARTOESATLETAS" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ID_MODALIDADE" />
                        <asp:Parameter Name="ID_CAMPEONATO" />
                        <asp:Parameter Name="ID_CADASTRO" />
                        <asp:Parameter Name="DT_CARTAO_AMARELO_1" />
                        <asp:Parameter Name="DT_CARTAO_AMARELO_2" />
                        <asp:Parameter Name="DT_SUSPENSAO_AMARELO" />
                        <asp:Parameter Name="CUMPRIU_SUSPENSAO_AMARELO" />
                        <asp:Parameter Name="DT_CARTAO_VERMELHO" />
                        <asp:Parameter Name="DT_SUSPENSAO_VERMELHO" />
                        <asp:Parameter Name="CUMPRIU_SUSPENSAO_VERMELHO" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlModalidades" Name="IDMODALIDADE" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="ddlCampeonatos" Name="IDCAMPEONATO" PropertyName="SelectedValue" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ID_CADASTRO" />
                        <asp:Parameter Name="DT_CARTAO_AMARELO_1" />
                        <asp:Parameter Name="DT_CARTAO_AMARELO_2" />
                        <asp:Parameter Name="DT_SUSPENSAO_AMARELO" />
                        <asp:Parameter Name="CUMPRIU_SUSPENSAO_AMARELO" />
                        <asp:Parameter Name="DT_CARTAO_VERMELHO" />
                        <asp:Parameter Name="DT_SUSPENSAO_VERMELHO" />
                        <asp:Parameter Name="CUMPRIU_SUSPENSAO_VERMELHO" />
                        <asp:Parameter Name="ID_CARTOESATLETAS" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlAtletas" runat="server" ConnectionString="<%$ ConnectionStrings:LigaabcConnectionString %>" SelectCommand="SELECT [ID_CADASTRO], RTRIM(NOME)+' '+RTRIM(SOBRENOME) AS NOME_COMPLETO FROM [CADASTRO]"></asp:SqlDataSource>
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
