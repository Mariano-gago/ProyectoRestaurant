using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyect_Restaurant.Sections.NuevaOrden
{
    public partial class NuevaOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty((string)Session["Token"]))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    token.Value = Session["Token"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Default.aspx");
            }

        }
    }
}