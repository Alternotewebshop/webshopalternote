<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Toevoegen.aspx.cs" Inherits="Webshop_Alternote.Toevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alternote Toevoegen</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 615px;
        }
        .auto-style3 {
            width: 109px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ALTERNOTE WEBSHOP - Toevoegen </h1>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Image ID="imgFoto" runat="server" Height="350px" ImageAlign="Middle" Width="400px" />
                </td>
                <td aria-multiline="False" aria-selected="undefined" aria-sort="none" class="auto-style3">
                    <asp:Label ID="Label1" runat="server" Text="ArtikelID:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Naam:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lablel3" runat="server" Text="Omschrijving:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Prijs:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Voorraad:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblArtikelID" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblNaam" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblOmschrijving" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblPrijs" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblVoorrraad" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <p>
            Aantal te bestellen artikelen van dit item:
            <asp:TextBox ID="txtAantal" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Voeg toe aan het winkelmandje..." />
        </p>
        <p>
            <asp:Label ID="lblFouteInvoer" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnTerugkeren" runat="server" OnClick="btnTerugkeren_Click" Text="Terug naar de catalogus" Visible="False" />
        </p>
    </form>
</body>
</html>
