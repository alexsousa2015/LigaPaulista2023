<%@ Page Language="C#" AutoEventWireup="true" Inherits="LigaPaulista.Site.Admin.adm_fileManager" Codebehind="fileManager.aspx.cs" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gerenciador de Arquivos</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <iz:FileManager ID="FileManager1" runat="server" Height="400" Width="600" ShowAddressBar="false" FileViewMode="Details" OnFileUploaded="FileManager1_FileUploaded">
            <RootDirectories>
                <iz:RootDirectory DirectoryPath="~/produtos" Text="Fotos Produtos" ShowRootIndex="False" />
            </RootDirectories>
            <FileViewStyle BackColor="White" BorderColor="#ACA899" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Tahoma,Verdana,Geneva,Arial,Helvetica,sans-serif" Font-Size="11px"
                Height="400px" Width="600px" />
            <FolderTreeStyle BackColor="White" BorderColor="#ACA899" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Tahoma,Verdana,Geneva,Arial,Helvetica,sans-serif" Font-Size="11px"
                Height="400px" Width="600px" />
        </iz:FileManager>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
