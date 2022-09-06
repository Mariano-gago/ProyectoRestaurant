using Application.Helpers;
using Application.Models;
using Proyect_Restaurant.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyect_Restaurant
{
    public partial class AdministrarBebidas : System.Web.UI.Page
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
            string nombre = NombreBebidaText.Text;
            decimal precio = Convert.ToDecimal(PrecioBebidaText.Text);
            int stock = Convert.ToInt16(StockBebidaText.Text);
            string imagen = "";
            bool activo = ActivoBebidaCheck.Checked;




            Stream st = ImagenUpload.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(st);
            Byte[] bytes = br.ReadBytes((Int32)st.Length);

            imagen = Convert.ToBase64String(bytes, 0, bytes.Length);


            var Bebida = new Bebidas();

            var guardarBebida = new BebidasService();

            Bebida.NombreBebida = nombre;
            Bebida.PrecioBebida = precio;
            Bebida.Stock = stock;
            Bebida.Imagen = imagen;
            Bebida.ActivoBebida = activo;

            guardarBebida.GuardarBebida(Bebida, token.Value);
        }



        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //El id proviene del Hiddenfield

            int id = Convert.ToInt16(idBebida.Value);
            string nombre = NombreBebidaText.Text;
            decimal precio = Convert.ToDecimal(PrecioBebidaText.Text);
            int stock = Int32.Parse(StockBebidaText.Text);
            
            bool activo = ActivoBebidaCheck.Checked;
            string imagen = imagenEditar.Value;

            if(ImagenUpload.PostedFile.FileName != "")
            {

                Stream st = ImagenUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(st);
                Byte[] bytes = br.ReadBytes((Int32)st.Length);

                imagen = Convert.ToBase64String(bytes, 0, bytes.Length);

            }

            var Bebida = new Bebidas();

            var editarBebida = new BebidasService();

            Bebida.IdBebida = id;
            Bebida.NombreBebida = nombre;
            Bebida.PrecioBebida = precio;
            Bebida.Stock = stock;
            Bebida.Imagen = imagen;
            Bebida.ActivoBebida = activo;

            editarBebida.EditarBebida(Bebida, token.Value);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminarBebida = new BebidasService();
            int id = Convert.ToInt16(idBebida.Value);
            eliminarBebida.EliminarBebida(id, token.Value);
        }
    }
}