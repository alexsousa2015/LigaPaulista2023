<%@ Page Language="C#" AutoEventWireup="true" Inherits="LigaPaulista.Site.Admin.login" Codebehind="login.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Administração - Sistemas Formula Web</title>
    <link type="text/css" rel="stylesheet" href="css/principal.css" />
</head>
<body style="background-color:#efefef">
    <form id="form1" runat="server">
    <div id="login"><!-- login -->
        
        <img src="../App_Themes/Admin/Images/topLogin.jpg" alt="Acesso Restrito" />
        
        <div style="margin-left:70px; margin-top:20px; margin-bottom:28px; _margin-bottom:25px; *margin-bottom:20px;">
        
         <div style="margin-bottom:3px;">
            <label>Usuário:</label>
            <asp:TextBox Id="txtUser" width="150" runat="server"/>
         </div>
         
         <div>           
            <label>Senha:</label>
            <asp:TextBox Id="txtPassword" width="150" TextMode="Password" runat="server" style="margin-left:8px;"/>
         </div>
       
            <asp:Button Id="cmdLogin" OnClick="ProcessLogin" Text="Acessar" runat="server" style="margin-left:140px;" /><br />
            <div id="ErrorMessage" runat="server" style="color:Red;" />
            </div>
        
        <div id="rodape">
        </div>
        
    </div><!-- login -->
    </form>
</body>
</html>
