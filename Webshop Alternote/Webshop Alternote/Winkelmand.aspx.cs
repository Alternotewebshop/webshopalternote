using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop_Alternote.Business;

namespace Webshop_Alternote
{
    public partial class Winkemand : System.Web.UI.Page
    {
        Controller _controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
        
            
            lblKlantID.Text = _controller.KlantGegevensOphalen(Convert.ToInt32(Session["klantid"])).KlantID.ToString();
            lblnaam.Text = _controller.KlantGegevensOphalen(Convert.ToInt32(Session["klantid"])).Naam.ToString();
            lblVoornaam.Text = _controller.KlantGegevensOphalen(Convert.ToInt32(Session["klantid"])).Voornaam.ToString();
            lblAdres.Text = _controller.KlantGegevensOphalen(Convert.ToInt32(Session["klantid"])).Adres.ToString();
            lblPostcode.Text = _controller.KlantGegevensOphalen(Convert.ToInt32(Session["klantid"])).Postcode.ToString();
            lblGemeente.Text = _controller.KlantGegevensOphalen(Convert.ToInt32(Session["klantid"])).Gemeente.ToString();
            lblAdres.Text = _controller.KlantGegevensOphalen(Convert.ToInt32(Session["klantid"])).Adres.ToString();
            lblDatum.Text = DateTime.Now.ToLongDateString();

            try
            {
                gvWinkelmand.DataSource = _controller.WinkelmandInDeGridviewTonen(Convert.ToInt32(lblKlantID.Text));
                gvWinkelmand.DataBind();

                lblZonderBTW.Text = "€ " + _controller.BedragAllesVanWinkelmand(Convert.ToInt16(lblKlantID.Text)) + ",00";
                lblBTW.Text = "€ " + _controller.BedragAllesVanWinkelmand(Convert.ToInt16(lblKlantID.Text)) * 0.21;
                lblTotalePrijs.Text = "€ " + _controller.BedragAllesVanWinkelmand(Convert.ToInt16(lblKlantID.Text)) * 1.21;
            }
            catch
            {
                lblLegeWinkelmand.Text = "De winkelmand is leeg";
                lblZonderBTW.Text = "0,00";
                lblBTW.Text = "0,00";
                lblTotalePrijs.Text = "0,00";
            }
        }

        protected void gvWinkelmand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvWinkelmand_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _controller.VerwijderenArtikelUitWinkelmand(Convert.ToInt32(Session["klantid"]), Convert.ToInt32(gvWinkelmand.Rows[e.RowIndex].Cells[2].Text));
            _controller.ToevoegenNaVerwijderenUitWinkelmand(Convert.ToInt32(gvWinkelmand.Rows[e.RowIndex].Cells[2].Text),Convert.ToInt32(gvWinkelmand.Rows[e.RowIndex].Cells[5].Text));
            Response.Redirect("winkelmand.aspx");
        }

        protected void btnTNC_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void btnBestellen_Click(object sender, EventArgs e)
        {
            Session["Totaleprijs"] = Convert.ToString(lblTotalePrijs.Text);
            Response.Redirect("BestelBevestiging.aspx");
        }
    }
}