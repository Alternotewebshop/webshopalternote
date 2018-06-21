using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop_Alternote.Business;

namespace Webshop_Alternote
{
    public partial class Toevoegen : System.Web.UI.Page
    {
        Controller _controller = new Controller();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(_controller.SetControleArtikelInHetmandje(Convert.ToInt32(Session["klantid"]),Convert.ToInt32(Session["id"])) ==true)
            {
                Response.Redirect("AlInHetWinkelmandje.aspx");
            }
            else
            {
                imgFoto.ImageUrl = @"~\Foto's\" + _controller.SetEénArtilel(Convert.ToInt32(Session["id"])).Foto;
                lblArtikelID.Text = Convert.ToString(_controller.SetEénArtilel(Convert.ToInt32(Session["id"])).artikelID);
                lblNaam.Text = Convert.ToString(_controller.SetEénArtilel(Convert.ToInt32(Session["id"])).Naam);
                lblOmschrijving.Text = Convert.ToString(_controller.SetEénArtilel(Convert.ToInt32(Session["id"])).Omschrijving);
                lblPrijs.Text = Convert.ToString(_controller.SetEénArtilel(Convert.ToInt32(Session["id"])).Prijs);
                lblVoorrraad.Text = Convert.ToString(_controller.SetEénArtilel(Convert.ToInt32(Session["id"])).Voorraad);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblFouteInvoer.Text = _controller.Checkgetal(Convert.ToInt32(Session["id"]), txtAantal.Text);
            if(lblFouteInvoer.Text=="ok")
            {
                _controller.ArtikelToevoegenAanWinkelmand(Convert.ToInt32(Session["klantid"]), Convert.ToInt32(Session["id"]), Convert.ToInt32(txtAantal.Text));
                _controller.UpdatenVoorraadNaWeiziging(Convert.ToInt32(Session["id"]), Convert.ToInt32(txtAantal.Text));
                Response.Redirect("winkelmand.aspx");
            }
        }

        protected void btnTerugkeren_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}