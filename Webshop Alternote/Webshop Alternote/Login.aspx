<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Webshop_Alternote.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alternote Login</title>
    <link rel="stylesheet" href ="Opmaak.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ALTERNOTE WEBSHOP - Login</h1>
        </div>
        <table class=".Login-TabelCellen">
            <tr>
                <td class="Login-TabelCellen" >Gebruikersnaam: </td>
                <td>
                    <asp:TextBox ID="txtNaam"  runat="server" class="Login-Textbox" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Wachtwoord:</td>
                <td>
                    <asp:TextBox ID="txtWachtwoord" runat="server" class="Login-Textbox" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFoutmelding" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnAanmelden" runat="server" OnClick="btnAanmelden_Click" CssClass="Login-Button" Text="Aanmelden"/>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
