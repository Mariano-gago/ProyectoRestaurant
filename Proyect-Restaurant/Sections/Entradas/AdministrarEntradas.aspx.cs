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
    public partial class AdministrarEntradas : System.Web.UI.Page
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
            string nombre = NombreEntradaText.Text;
            string imagen = ImagenEntrada.Text;
            decimal precio = Convert.ToDecimal(PrecioNumber.Text);
            bool activo = ActivoEntradaCheck.Checked;

            var Entrada = new Entradas();

            var guardarEntrada = new EntradasService();

            Entrada.NombreEntrada = nombre;            
            Entrada.ImagenEntrada = imagen;            
            Entrada.PrecioEntrada = precio;            
            Entrada.ActivoEntrada = activo;

            guardarEntrada.GuardarEntrada(Entrada, token.Value);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //El id proviene del Hiddenfield

            int id = Convert.ToInt16(idEntrada.Value);
            string nombre = NombreEntradaText.Text;
            string imagen = ImagenEntrada.Text;
            decimal precio = Convert.ToDecimal(PrecioNumber.Text);
            bool activo = ActivoEntradaCheck.Checked;




            var Entrada = new Entradas();

            var editarEntrada = new EntradasService();

            Entrada.IdEntrada = id;
            Entrada.NombreEntrada = nombre;           
            Entrada.ImagenEntrada = imagen;           
            Entrada.PrecioEntrada = precio;           
            Entrada.ActivoEntrada = activo;

           editarEntrada.EditarEntrada(Entrada, token.Value);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminarEntrada = new EntradasService();
            int id = Convert.ToInt16(idEntrada.Value);
            eliminarEntrada.EliminarEntrada(id, token.Value);
        }
    }
}