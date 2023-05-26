<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="cadastro-simples.aspx.cs" Inherits="LigaPaulista.Site.Admin.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="width: 48%; float: left;">

        <legend>Cadastro Simplificado</legend>
        <div>
            <table>
                <tr>
                    <td width="100px"><label>Nome</label></td>
                    <td><asp:TextBox runat="server" ID="TxtNome" width="350px"/></td>
                </tr>
                <tr>
                    <td><label>Sobrenome</label></td>
                    <td><asp:TextBox runat="server" ID="TxtSobrenome" width="350px"/></td>
                </tr>
                <tr>
                    <td><label>E-mail</label></td>
                    <td><asp:TextBox runat="server" ID="TxtEmail" width="350px"/></td>
                </tr>
                <tr>
                    <td><label>Entidade</label></td>
                    <td><asp:DropDownList runat="server" ID="ddlEntidade" DataSourceID="SqlTimes" DataTextField="ENTIDADE" DataValueField="ID_ENTIDADE" width="350px"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <div>
                <asp:SqlDataSource ID="SqlTimes" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="select e.ID_ENTIDADE,e.ENTIDADE
                                    from ENTIDADES e
                                    order by e.ENTIDADE"></asp:SqlDataSource>
            </div>
            <div>
                <asp:Button runat="server" ID="BtnSalvar" Text="Gravar" OnClick="BtnSalvar_Click" /><br />
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
        </div>
    </fieldset>
</asp:Content>
