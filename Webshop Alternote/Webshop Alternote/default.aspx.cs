using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop_Alternote.Business;

namespace Webshop_Alternote
{
    public partial class _default : System.Web.UI.Page
    {
        Controller _controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvCatalogus.DataSource = _controller.SetAlleArtikels();
            gvCatalogus.DataBind();

            for (int i=0;i<gvCatalogus.Rows.Count;i++)
            {
                if((gvCatalogus.Rows[i].Cells[5].Text)=="0")
                {
                    (gvCatalogus.Rows[i].Cells[6].Text) = "Niet in voorraad";
                }           
            }
            Session["klantid"] = Session["IDVanKlant"];
        }

        protected void gvCatalogus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id"] = Convert.ToInt32(gvCatalogus.SelectedRow.Cells[0].Text);
            Response.Redirect("Toevoegen.aspx");
        }

        protected void Winkelmandje_Click(object sender, EventArgs e)
        {
            Response.Redirect("Winkelmand.aspx");
        }
    }
}