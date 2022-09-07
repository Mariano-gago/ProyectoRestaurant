using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyect_Restaurant
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            //Cuando se clikea en cerrar Sesion, se destruye la cookie y redirige al Login
            Response.Cookies["Token"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/");

        }
    }
}