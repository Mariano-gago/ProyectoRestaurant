using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect_Restaurant.Service
{
    public class RolesService: BaseApiService
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
    }
}