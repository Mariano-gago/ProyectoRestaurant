using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyect_Restaurant.Service
{
    public class BebidasService: BaseApiService
    {

        public object GuardarBebida(Bebidas bebida, string token)
        {
            string ContollerMethodName = "Bebidas/GuardarBebida";
            return base.PostToApi(ContollerMethodName, bebida, token);
        }

        public object EditarBebida(Bebidas bebida, string token)
        {
            string ContollerMethodName = "Bebidas/EditarBebida";
            return base.PostToApi(ContollerMethodName, bebida, token);
        }

        public object EliminarBebida(int id, string token)
        {
            string ContollerMethodName = "Bebidas/EliminarBebida";
            return base.DeleteToApi(ContollerMethodName, id, token);
        }
    }
}