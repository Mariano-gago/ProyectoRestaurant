using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect_Restaurant.Service
{
    public class RolService: BaseApiService
    {
        public object GuardarRol(Roles Rol, string token)
        {
            string ContollerMethodName = "Roles/GuardarRol";
            return base.PostToApi(ContollerMethodName, Rol, token);
        }

        public object EditarRol(Roles Rol, string token)
        {
            string ContollerMethodName = "Roles/EditarRol";
            return base.PostToApi(ContollerMethodName, Rol, token);
        }

        public object EliminarRol(int id, string token)
        {
            string ContollerMethodName = "Roles/EliminarRol";
            return base.DeleteToApi(ContollerMethodName, id, token);
        }

        public object ObtenerRoles(string token)
        {
            string ContollerMethodName = "Roles/ObtenerRoles";
            return base.GetToApi(ContollerMethodName, token);
        }
    }
}