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
    [RoutePrefix("api/Roles")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RolesController:ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public AllContext db;

        public RolesController()
        {
            db = new AllContext();
        }

        [HttpGet]
        [Route("ObtenerRoles")]
        public IHttpActionResult ObtenerRoles()
        {
           

            var rol = db.Roles.AsNoTracking().Where(x => x.Activo == true).ToList();

            return Ok(rol);
        }


        [HttpPost]
        [Route("GuardarRol")]
        public IHttpActionResult GuardarRoles([Bind(Include ="IdRol, NombreRol, Activo")] Roles Rol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = db.Roles.AsNoTracking().ToList();
                    foreach(var x in emp)
                    {
                        if(x.NombreRol == Rol.NombreRol)
                        {
                            return Ok("El usuario ya existe");
                        }
                    }
                    db.Roles.Add(Rol);
                    db.SaveChanges();
                    return Ok("Se guardo");
                }
            }
            catch(Exception ex)
            {
                log.Error(ex);
                return Ok("Algo salio mal");
            }
            return Ok("Algo salio mal");
        }



        [HttpPost]
        [Route("EditarRol")]
        public IHttpActionResult EditarRoles([Bind(Include = "IdRol, NombreRol, Activo")] Roles Rol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Rol).State = EntityState.Modified;
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
        [Route("EliminarRol")]
        public IHttpActionResult EliminarRoles(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Roles Rol = db.Roles.Find(id);
                    Rol.Activo = false;
                    db.Entry(Rol).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se elimino Correctamente");
                }
            }
            catch(Exception ex)
            {
                log.Error(ex);
                return Ok("Algo salio mal");
            }
            return Ok("Algo salio mal");
        }
    }
}
