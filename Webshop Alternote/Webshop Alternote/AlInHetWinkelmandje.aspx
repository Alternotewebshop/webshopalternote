<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlInHetWinkelmandje.aspx.cs" Inherits="Webshop_Alternote.AlInHetWinkelmandje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alternote Webshop Al gekozen artikel</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ALTERNOTE WEBSHOP - Al gekozen artikel</h1>
        </div>
        <p>
            Dit artikel zit al in het winkelmandje</p>
        <asp:Button ID="btnTNC" runat="server" OnClick="btnTNC_Click" Text="Terug naar catalogus..." />
    </form>
</body>
</html>
