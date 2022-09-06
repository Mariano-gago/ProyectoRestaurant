using Application;
using Application.Helpers;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace Api.Controllers
{
    // AllowAnonymous : Ingresan los usuarios sin loguearse
    [AllowAnonymous]
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {

        private AllContext db;


        public LoginController()
        {
             db = new AllContext();
        }


        [HttpPost]
        [Route("Authenticate")]
        public IHttpActionResult Authenticate(Empleados login)
        {
            if(login == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var empleados = db.Empleados.ToList();

            foreach(var empleado in empleados)
            {
                if (empleado.Mail == login.Mail && empleado.Password == login.Password)
                {
                    var token = TokenGenerator.GenerateTokenJWT(login.Mail);
                    return Ok(token);

                }
            }

            return Unauthorized();
        }



        //Recuperacion de contraseña
        [HttpPost]
        [Route("Codigo")]
        public IHttpActionResult Codigo(Empleados codigo)
        {
            
            // Busca los "empleados" en la base de datos en donde el mail es igual al mail ingresado y obtiene el primer valor o default
            var empleado = db.Empleados.Where(x => x.Mail == codigo.Mail).FirstOrDefault();

            try
            {
                if (ModelState.IsValid)
                {
                    empleado.Codigo = codigo.Codigo;
                    db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se guardo el codigo correctamente");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex);
            }

            return Content(HttpStatusCode.NotFound, "Algo salio mal");         
        }

        [HttpPost]
        [Route("VerificarCodigo")]
        public IHttpActionResult VerificarCodigo(Empleados codigo)
        {

            // Busca los "empleados" en la base de datos en donde el mail es igual al mail ingresado y obtiene el primer valor o default
            var empleado = db.Empleados.Where(x => x.Mail == codigo.Mail).FirstOrDefault();

            try
            {
                if (ModelState.IsValid)
                {
                    if(Equals(empleado.Codigo, codigo.Codigo))
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return Ok(false);
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex);
            }

            return Content(HttpStatusCode.NotFound, "Algo salio mal");
        }


        [HttpPost]
        [Route("RecuperarCuenta")]
        public IHttpActionResult RecuperarCuenta(Empleados empleado)
        {

            // Busca los "empleados" en la base de datos en donde el mail es igual al mail ingresado y obtiene el primer valor o default
            var emp = db.Empleados.Where(x => x.Mail == empleado.Mail).FirstOrDefault();

            try
            {
                if (ModelState.IsValid)
                {
                    emp.Password = empleado.Password;
                    db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se Edito el empleado correctamente");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex);
            }

            return Content(HttpStatusCode.NotFound, "Algo salio mal");
        }
    }
}