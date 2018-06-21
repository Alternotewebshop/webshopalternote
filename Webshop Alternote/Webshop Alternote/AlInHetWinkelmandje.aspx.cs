using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webshop_Alternote
{
    public partial class AlInHetWinkelmandje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTNC_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}