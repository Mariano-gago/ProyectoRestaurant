using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect_Restaurant.Service
{
    public class EmpleadosService: BaseApiService
    {
        public object GuardarEmpleado(Empleados empleado, string token)
        {
            string ContollerMethodName = "Empleados/GuardarEmpleados";
            return base.PostToApi(ContollerMethodName, empleado, token);
        }

        public object EditarEmpleado(Empleados empleado, string token)
        {
            string ContollerMethodName = "Empleados/EditarEmpleados";
            return base.PostToApi(ContollerMethodName, empleado, token);
        }

        public object EliminarEmpleado(int id, string token)
        {
            string ContollerMethodName = "Empleados/EliminarEmpleados";
            return base.DeleteToApi(ContollerMethodName, id, token);
        }
    }
}