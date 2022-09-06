using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect_Restaurant.Service
{
    public class EntradasService: BaseApiService
    {
        public object GuardarEntrada(Entradas Entrada, string token)
        {
            string ContollerMethodName = "Entradas/GuardarEntrada";
            return base.PostToApi(ContollerMethodName, Entrada, token);
        }

        public object EditarEntrada(Entradas Entrada, string token)
        {
            string ContollerMethodName = "Entradas/EditarEntrada";
            return base.PostToApi(ContollerMethodName, Entrada, token);
        }

        public object EliminarEntrada(int id, string token)
        {
            string ContollerMethodName = "Entradas/EliminarEntrada";
            return base.DeleteToApi(ContollerMethodName, id, token);
        }
    }
}