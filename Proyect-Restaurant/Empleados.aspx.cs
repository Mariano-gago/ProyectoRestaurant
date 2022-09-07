using Application.Helpers;
using Application.Models;
using Newtonsoft.Json;
using Proyect_Restaurant.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyect_Restaurant
{
    public partial class Emplados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
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

                    //Obtengo los roles de la base de datos a traves de la Api
                    var rolService = new RolService();
                    var roles = rolService.ObtenerRoles(token.Value);

                    //Transformo un Json a un Objeto, dentro de la deserealizacion se convierte en una lista del tipo roles de un string
                    var listaRoles = JsonConvert.DeserializeObject< List < Roles >> (roles.ToString());

                    foreach(var x in listaRoles)
                    {
                        RolDrop.Items.Add(new ListItem(x.NombreRol, x.IdRol.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/Default.aspx");
                }

            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = NombreText.Text;
            string apellido = ApellidoText.Text;           
            string mail = MailText.Text;
            string password = PasswordText.Text;
            int  rol = Convert.ToInt16(RolDrop.SelectedValue);
            bool activo = ActivoCheck.Checked;

            var empleado = new Empleados();

            var guardarEmpleado = new EmpleadosService();

            empleado.NombreEmpleado = nombre;
            empleado.ApellidoEmpleado = apellido;
           
            empleado.Mail = mail;
            empleado.Password = password;
            empleado.Rol_Id = rol;
            empleado.Activo = activo;

            guardarEmpleado.GuardarEmpleado(empleado, token.Value);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //El id proviene del Hiddenfield

            int id = Convert.ToInt16(idEmpleado.Value);
            string nombre = NombreText.Text;
            string apellido = ApellidoText.Text;
            string mail = MailText.Text;
            string password = PasswordText.Text;
            int rol = Convert.ToInt16(RolDrop.SelectedValue);
            bool activo = ActivoCheck.Checked;




            var empleado = new Empleados();

            var editarEmpleado = new EmpleadosService();

            empleado.IdEmpleado = id;
            empleado.NombreEmpleado = nombre;
            empleado.ApellidoEmpleado = apellido;

            empleado.Mail = mail;
            empleado.Password = password;
            empleado.Rol_Id = rol;
            empleado.Activo = activo;

           editarEmpleado.EditarEmpleado(empleado, token.Value);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminarEmpleado = new EmpleadosService();
            int id = Convert.ToInt16(idEmpleado.Value);
            eliminarEmpleado.EliminarEmpleado(id, token.Value);
        }

        protected void btnGuardarBebida_Click(object sender, EventArgs e)
        {
            string nombreBebida = NombreBebidaText.Text;
            int precioBebida = Convert.ToInt16(PrecioBebidaText.Text);
            int stockBebida = Convert.ToInt16(StockBebidaText.Text);
            string imagen = ImagenBebidaText.Text;

            var bebida = new Bebidas();
            bebida.NombreBebida = nombreBebida;
            bebida.PrecioBebida = precioBebida;
            bebida.Stock = stockBebida;
            bebida.Imagen = imagen;

            var guardarBebida = new BebidasService();

            guardarBebida.GuardarBebida(bebida, token.Value);

        }

        protected void btnEditarBebida_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(idBebida.Value);
            string nombreBebida = NombreBebidaText.Text;
            int precioBebida = Convert.ToInt16(PrecioBebidaText.Text);
            int stockBebida = Convert.ToInt16(StockBebidaText.Text);
            string imagen = ImagenBebidaText.Text;

            var bebida = new Bebidas();
            bebida.IdBebida = id;
            bebida.NombreBebida = nombreBebida;
            bebida.PrecioBebida = precioBebida;
            bebida.Stock = stockBebida;
            bebida.Imagen = imagen;

            var editarBebida = new BebidasService();

            editarBebida.EditarBebida(bebida, token.Value);
        }

        protected void btnEliminarBebida_Click(object sender, EventArgs e)
        {
            var eliminarBebida = new BebidasService();
            int id = Convert.ToInt16(idBebida.Value);
            eliminarBebida.EliminarBebida(id, token.Value);
        }
    }
}