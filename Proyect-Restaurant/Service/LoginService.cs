using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect_Restaurant.Service
{
    public class LoginService : BaseApiService
    {
        public object Login(Empleados empleado)
        {
            string ContollerMethodName = "Login/Authenticate";
            return base.LoginToApi(ContollerMethodName, empleado);
        }


        public object Codigo(Empleados empleado)
        {
            string ContollerMethodName = "Login/Codigo";
            return base.LoginToApi(ContollerMethodName, empleado);
        }

        public object VerificarCodigo(Empleados empleado)
        {
            string ContollerMethodName = "Login/VerificarCodigo";
            return base.LoginToApi(ContollerMethodName, empleado);
        }

        public object RecuperarCuenta(Empleados empleado)
        {
            string ContollerMethodName = "Login/RecuperarCuenta";
            return base.LoginToApi(ContollerMethodName, empleado);
        }
    }
}