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
    [RoutePrefix("api/Bebidas")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BebidasController:ApiController
    {
        public AllContext db;

        public BebidasController()
        {
            db = new AllContext();
        }

        [HttpGet]
        [Route("ObtenerBebidas")]
        public IHttpActionResult ObtenerBebidas()
        {
            var rol = db.Bebidas.AsNoTracking().Where(x => x.ActivoBebida == true).ToList();

            return Ok(rol);
        }


        [HttpPost]
        [Route("GuardarBebida")]
        public IHttpActionResult GuardarBebidas([Bind(Include ="IdBebida, NombreBebida, PrecioBebida, Imagen, Stock, ActivoBebida")] Bebidas Bebida)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = db.Bebidas.AsNoTracking().ToList();
                    foreach(var x in emp)
                    {
                        if(x.NombreBebida == Bebida.NombreBebida)
                        {
                            return Ok("La bebida ya existe");
                        }
                    }
                    db.Bebidas.Add(Bebida);
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
        [Route("EditarBebida")]
        public IHttpActionResult EditarBebida([Bind(Include = "IdBebida, NombreBebida, PrecioBebida, Imagen, Stock, ActivoBebida")] Bebidas Bebida)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Bebida).State = EntityState.Modified;
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
        [Route("EliminarBebida")]
        public IHttpActionResult EliminarBebida(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Bebidas Bebida = db.Bebidas.Find(id);
                    Bebida.ActivoBebida = false;
                    db.Entry(Bebida).State = EntityState.Modified;
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
