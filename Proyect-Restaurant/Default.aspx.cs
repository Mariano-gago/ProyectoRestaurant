using Application.Models;
using Proyect_Restaurant.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyect_Restaurant
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Token"] = "";
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            Empleados empleado = new Empleados();
            empleado.Password = txtPassword.Text;
            empleado.Mail = txtEmail.Text;

            LoginService loginServices = new LoginService();

            string respuesta = loginServices.Login(empleado).ToString();

            //EL metodo Trim reemplaza un caracter por otro, colocando el primer argumento a reemplazar
            Session["Token"] = respuesta.Trim().Replace(@"\", "").Replace(@"""", "");

            if(respuesta != "")
            {
                Response.Redirect("~/Admin");
            }
            else
            {
                lblError.Visible = true;
            }
        }
    }
}