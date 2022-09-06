using Application.Helpers;
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
    public partial class AdministrarRoles : System.Web.UI.Page
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = NombreText.Text;
            bool activo = ActivoRolCheck.Checked;

            var Rol = new Roles();

            var guardarRol = new RolesService();

            Rol.NombreRol = nombre;            
            Rol.Activo = activo;

            guardarRol.GuardarRol(Rol, token.Value);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //El id proviene del Hiddenfield

            int id = Convert.ToInt16(idRol.Value);
            string nombre = NombreText.Text;
            bool activo = ActivoRolCheck.Checked;




            var Rol = new Roles();

            var editarRol = new RolesService();

            Rol.IdRol = id;
            Rol.NombreRol = nombre;           
            Rol.Activo = activo;

           editarRol.EditarRol(Rol, token.Value);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminarRol = new RolesService();
            int id = Convert.ToInt16(idRol.Value);
            eliminarRol.EliminarRol(id, token.Value);
        }
    }
}