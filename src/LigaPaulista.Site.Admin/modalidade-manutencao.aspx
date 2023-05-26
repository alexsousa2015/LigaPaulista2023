<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modalidade-manutencao.aspx.cs"
    Inherits="LigaPaulista.Site.Admin.modalidade_manutencao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <h2>Cadastro / Alteração de Modalidade</h2>
            <div class="requerid">
                Modalidade:
            <asp:TextBox ID="txtModalidade" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtModalidade"
                    Display="None" ErrorMessage="&lt;b&gt;Campo nulo!&lt;/b&gt;&lt;br&gt;Favor Preencher!"
                    ValidationGroup="Gravar"></asp:RequiredFieldValidator>
                <ajaxtoolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                </ajaxtoolkit:ValidatorCalloutExtender>
            </div>
            <div class="requerid">
                Ativo:
                <asp:CheckBox ID="chkAtivo" runat="server" Width="300px"></asp:CheckBox>
            </div>
            <div>
                <br />
                <fieldset>
                    <legend>Foto</legend>
                    <br />
                    <asp:FileUpload ID="fuplImagem" runat="server" />
                    <asp:Button ID="btnSubir" runat="server" Text="Arquivar" OnClick="btnSubir_Click" />
                    <br />
                    <asp:Image ID="imgFoto" runat="server" />
                </fieldset>
            </div>
            <div class="submit">
                <asp:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click"
                    ValidationGroup="Gravar" />
            </div>
        </div>
    </form>
</body>
</html>
