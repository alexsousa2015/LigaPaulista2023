<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendario-formulario.aspx.cs"
    Inherits="LigaPaulista.Site.Admin.CalendarioFormulario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            width: 220px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <h2>Cadastro Calendário</h2>
            <div class="requerid">
                <table>
                    <tr>
                        <td class="auto-style1">
                            <label for="txtAno">Ano da Temporada</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAno" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAno"
                                Display="None" ErrorMessage="&lt;b&gt;Por Favor informe o Ano da temporada!&lt;/b&gt;"
                                ValidationGroup="Gravar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <label for="txtTemporada">Descrição da Temporada</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTemporada" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTemporada"
                                Display="None" ErrorMessage="&lt;b&gt;Informe a descrição da temporada!&lt;/b&gt;"
                                ValidationGroup="Gravar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <label for="txtUploadCalendario">Arquivo do Calendário</label>
                            </td>
                        <td>
                            <asp:FileUpload ID="txtUploadCalendario" runat="server" Width="440px" />
                        </td>
                        <td style="text-align: right"></td>
                    </tr>
                    <tr id="LineFileName" runat="server" Visible="False">
                        <td><label>Arquivo</label> Atual</td>
                        <td>
                            <h3>
                            <asp:Label ID="lblFileName" runat="server" Text="" style="font-weight: 700"></asp:Label>
                            </h3>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="text-align: right;">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"
                                ValidationGroup="Salvar" />
                        </td>
                        <td class="auto-style1"></td>
                    </tr>
                </table>

                <ajaxtoolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                </ajaxtoolkit:ValidatorCalloutExtender>
            </div>
            <div class="submit">
            </div>

        </div>
    </form>
</body>
</html>
