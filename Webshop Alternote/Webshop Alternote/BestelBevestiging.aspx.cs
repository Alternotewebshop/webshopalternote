using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop_Alternote.Business;

namespace Webshop_Alternote
{
    public partial class BestelBevestiging : System.Web.UI.Page
    {
        Controller _controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblOrderPrijs.Text = Convert.ToString(Session["Totaleprijs"]);
            lblOrdernummer.Text = Convert.ToString(_controller.OphalenLaatsteOrderID());
            int lengte = _controller.OphalenLengteWinkelmand(Convert.ToInt32(Session["klantid"]));
            _controller.MakenVanOrder(Convert.ToInt32(Session["klantid"]));
            for(int i=0;i<lengte;i++)
            {
                _controller.OpslaanTBLOrderinformatie(Convert.ToInt32(Session["klantid"]));
                _controller.VerwijderenArtikelenMandje(Convert.ToInt32(Session["klantid"]));
            }

           

            _controller.VerstuurEmail(Convert.ToInt32(Session["klantid"]), "Bedankt voor de bestelling, deze is door ons goed ontvangen en zal verstuurd worden zodra het bedrag van" +
                " " + Convert.ToString(Session["Totaleprijs"]) + " gestort is op de rekening met rekeningnummer BE91 5612 1236 7895 " + Environment.NewLine + " Gelieve het orderID: " + lblOrdernummer.Text + " als betalingsreferentie mee te geven." + Environment.NewLine + " Alternote bedankt u voor uw bestelling!");

        }

        protected void btnTNC_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}