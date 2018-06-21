<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Webshop_Alternote._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alternote Catalogus</title>
      <link rel="stylesheet" href ="Opmaak.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ALTERNOTE WEBSHOP - Catalogus</h1>
        </div>
        <asp:GridView ID="gvCatalogus" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCatalogus_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
            <Columns>
                <asp:BoundField DataField="artikelid" HeaderText="ArtikelID">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="naam" HeaderText="Naam">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="omschrijving" HeaderText="Omschrijving">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="330px" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="foto" DataImageUrlFormatString="~\Foto's\{0}" HeaderText="Foto">
                    <ControlStyle Height="150px" Width="180px" />
                    <ItemStyle Height="150px" HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                </asp:ImageField>
                <asp:BoundField DataField="prijs" HeaderText="Prijs" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="voorraad" HeaderText="Voorraad">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                </asp:BoundField>
                <asp:CommandField SelectText="Voeg toe aan winkelmandje" ShowSelectButton="True">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
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
        <p>
            <asp:Button ID="Winkelmandje" runat="server" OnClick="Winkelmandje_Click" Text="Bekijk de inhoud van het mandje..." Width="1236px" />
        </p>
    </form>
</body>
</html>
