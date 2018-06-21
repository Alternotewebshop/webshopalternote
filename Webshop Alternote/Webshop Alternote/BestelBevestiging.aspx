<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BestelBevestiging.aspx.cs" Inherits="Webshop_Alternote.BestelBevestiging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alternote Bestelbevestiging</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Alternote webshop - Bestelbevestiging</h1>
        </div>
        <p>
            Uw bestelling met ordernummer <strong>
            <asp:Label ID="lblOrdernummer" runat="server"></asp:Label>
            </strong>&nbsp;werd door ons goed ontvangen.</p>
        <p>
            Uw bestelling met ordernummer <strong>
            <asp:Label ID="lblOrderPrijs" runat="server"></asp:Label>
            </strong>&nbsp;Op rekeningnummer<strong> BE91 5612 1236 7895</strong> zullen wij overgaan tot de verzending van de laptops.</p>
        <p>
            Gelieve het ordernummer als betalingsreferentie mee te geven.</p>
        <p>
            Bedankt voor uw vertrouwen!</p>
        <p>
            <asp:Button ID="btnTNC" runat="server" OnClick="btnTNC_Click" style="height: 26px" Text="Terug naar de catalogus..." Width="200px" />
        </p>
    </form>
</body>
</html>
