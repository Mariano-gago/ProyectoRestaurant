using Application;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace Api.Controllers
{

    [Authorize]
    [RoutePrefix("api/Entradas")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntradasController:ApiController
    {
        public AllContext db;

        public EntradasController()
        {
            db = new AllContext();
        }

        [HttpGet]
        [Route("ObtenerEntradas")]
        public IHttpActionResult ObtenerEntradas()
        {
            var rol = db.Entradas.AsNoTracking().Where(x => x.ActivoEntrada == true).ToList();

            return Ok(rol);
        }


        [HttpPost]
        [Route("GuardarEntrada")]
        public IHttpActionResult GuardarEntrada([Bind(Include ="IdEntrada, NombreEntrada,PrecioEntrada, ImagenEntrada, ActivoEntrada")] Entradas Entrada)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = db.Entradas.AsNoTracking().ToList();
                    foreach(var x in emp)
                    {
                        if(x.NombreEntrada == Entrada.NombreEntrada)
                        {
                            return Ok("El usuario ya existe");
                        }
                    }
                    db.Entradas.Add(Entrada);
                    db.SaveChanges();
                    return Ok("Se guardo");
                }
            }
            catch
            {
                return Ok("Algo salio mal");
            }
            return Ok("Algo salio mal");
        }



        [HttpPost]
        [Route("EditarEntrada")]
        public IHttpActionResult EditarEntrada([Bind(Include = "IdEntrada, NombreEntrada, PrecioEntrada, ImagenEntrada, ActivoEntrada")] Entradas Entrada)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Entrada).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se guardo");
                }
            }
            catch
            {
                return Ok("Algo salio mal");
            }
            return Ok("Algo salio mal");
        }



        [HttpDelete]
        [Route("EliminarEntrada")]
        public IHttpActionResult EliminarEntrada(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Entradas Entrada = db.Entradas.Find(id);
                    Entrada.ActivoEntrada = false;
                    db.Entry(Entrada).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se elimino Correctamente");
                }
            }
            catch
            {
                return Ok("Algo salio mal");
            }
            return Ok("Algo salio mal");
        }
    }
}
