using Application.Models;
using Proyect_Restaurant.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyect_Restaurant.Sections.RecuperarCuenta
{
    public partial class RecuperarCuentaFin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty((string)Session["Codigo"]))
                {
                    Response.Redirect("~/Default.aspx");

                }else if(Session["Codigo"].ToString() == "false")
                {
                    Response.Redirect("~/Default.aspx");
                }
               
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Default.aspx");
            }

        }

        protected void CambiarContraseña_Click(object sender, EventArgs e)
        {
            if(Equals(PasswordText.Text, PasswordText2.Text))
            {
                var empleado = new Empleados();
                

                empleado.Password = PasswordText.Text;
                empleado.Mail = (string)Session["Mail"];

                var loginService = new LoginService();
                loginService.RecuperarCuenta(empleado);

                Response.Redirect("~/Default.aspx");
            }
        }
    }
}