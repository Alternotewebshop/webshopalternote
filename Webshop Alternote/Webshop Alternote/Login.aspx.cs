using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop_Alternote.Business;

namespace Webshop_Alternote
{
    public partial class Login : System.Web.UI.Page
    {
        Controller _controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAanmelden_Click(object sender, EventArgs e)
        {
            if( _controller.ControleerBestaanKlant(txtNaam.Text, txtWachtwoord.Text)==true)
            {
                Session["IDVanKlant"]= _controller.OphalenIDvangebruiker(txtNaam.Text);
                Response.Redirect("default.aspx");
            }
            else
            {
                lblFoutmelding.Text = "De aanmeldgegevens zijn verkeerd.";
            }
        }
    }
}