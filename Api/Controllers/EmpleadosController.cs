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
    [RoutePrefix("api/Empleados")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpleadosController:ApiController
    {
        public AllContext db;

        public EmpleadosController()
        {
            db = new AllContext();
        }

        [HttpGet]
        [Route("ObtenerEmpleados")]
        public IHttpActionResult ObtenerEmpleados()
        {
            var emp = db.Empleados.AsNoTracking().Where(x => x.Activo == true).ToList();

            return Ok(emp);
        }


        [HttpPost]
        [Route("GuardarEmpleados")]
        public IHttpActionResult GuardarEmpleados([Bind(Include ="IdEmpleado, NombreEmpleado, ApellidoEmpleado, Mail, Password, Rol")] Empleados empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = db.Empleados.AsNoTracking().ToList();
                    foreach(var x in emp)
                    {
                        if(x.Mail == empleado.Mail)
                        {
                            return Ok("El usuario ya existe");
                        }
                    }
                    db.Empleados.Add(empleado);
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
        [Route("EditarEmpleados")]
        public IHttpActionResult EditarEmpleados([Bind(Include = "IdEmpleado, NombreEmpleado, ApellidoEmpleado, TelefonoEmpleado, Mail, Password, Rol")] Empleados empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(empleado).State = EntityState.Modified;
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
        [Route("EliminarEmpleados")]
        public IHttpActionResult EliminarEmpleados(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Empleados empleado = db.Empleados.Find(id);
                    empleado.Activo = false;
                    db.Entry(empleado).State = EntityState.Modified;
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
