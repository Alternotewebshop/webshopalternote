<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Winkelmand.aspx.cs" Inherits="Webshop_Alternote.Winkemand" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alternote Winkelmand</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style4 {
            width: 122px;
        }
        .auto-style5 {
            height: 23px;
            width: 122px;
        }
        .auto-style6 {
            width: 995px;
        }
        .auto-style7 {
            text-align: right;
            width: 117px;
        }
        .auto-style8 {
            text-align: right;
            width: 172px;
        }
        .auto-style9 {
            width: 70%;
        }
        .auto-style10 {
            margin-left: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Alternote webshop - Winkelmand</h1>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">Klantnummer:</td>
                <td>
                    <asp:Label ID="lblKlantID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Naam:</td>
                <td class="auto-style2">
                    <asp:Label ID="lblnaam" runat="server"></asp:Label>
                    <asp:Label ID="lblVoornaam" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Adres:</td>
                <td>
                    <asp:Label ID="lblAdres" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Label ID="lblPostcode" runat="server"></asp:Label>
                    <asp:Label ID="lblGemeente" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Besteldatum</td>
                <td>
                    <asp:Label ID="lblDatum" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvWinkelmand" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvWinkelmand_RowDeleting" OnSelectedIndexChanged="gvWinkelmand_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:CommandField DeleteImageUrl="~\Foto's\delete.png" DeleteText="" ShowDeleteButton="True" ButtonType="Image">
                <ControlStyle Height="75px" Width="75px" />
                <ItemStyle Height="75px" HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:CommandField>
                <asp:ImageField DataImageUrlField="foto" DataImageUrlFormatString="~\Foto's\{0}" HeaderText="Foto">
                    <ControlStyle Width="200px" />
                </asp:ImageField>
                <asp:BoundField DataField="artikelid" HeaderText="ArtikelID">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="naam" HeaderText="Naam">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="omschrijving" HeaderText="Omschrijving">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="330px" />
                </asp:BoundField>
                <asp:BoundField DataField="aantal" HeaderText="Aantal">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="prijs" HeaderText="Prijs" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="totaal" HeaderText="Totaal" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <table class="auto-style9">
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblLegeWinkelmand" runat="server"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:Label ID="label100" runat="server" Text="Totaal excl. BTW:"></asp:Label>
                    <br />
                    <asp:Label ID="Label101" runat="server" Text="BTW:"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Totaal incl. BTW:"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="lblZonderBTW" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblBTW" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblTotalePrijs" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    &nbsp;&nbsp;&nbsp;
        <div class="auto-style10">
            <asp:Button ID="btnBestellen" runat="server" OnClick="btnBestellen_Click" Text="Bestellen..." Width="400px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnTNC" runat="server" OnClick="btnTNC_Click" Text="Terug naar catalogus..." Width="400px" />
        </div>
    </form>
</body>
</html>
