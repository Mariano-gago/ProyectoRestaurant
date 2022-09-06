using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace Proyect_Restaurant.Service
{
    public class BaseApiService
    {
        //Traigo la URL desde el webconfig de la Api
        private string apiUrl { get { return ConfigurationManager.AppSettings["apiUrl"]; } }

        protected HttpResponseMessage PostToApi(string controllerMethodUrl, object BodyParameters, string token)
        {
            HttpClient httpClient = new HttpClient();
            //Variable response de tipo Http...
            HttpResponseMessage response;

            //Formateo a JSON
            JsonMediaTypeFormatter JSONMediaFormatter = new JsonMediaTypeFormatter();

            // Creacion de ruta
            HttpContent theContent = null;
            string url = string.Format("{0}/{1}", apiUrl, controllerMethodUrl);

            if (BodyParameters != null)
            {
                theContent = new ObjectContent(BodyParameters.GetType(), BodyParameters, JSONMediaFormatter, new MediaTypeHeaderValue("application/json"));
            }

            //Consumiendo la api
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            response = httpClient.PostAsync(url, theContent).Result;
            //response.EnsureSuccessStatusCode();
            return response;
        }

        protected HttpResponseMessage DeleteToApi(string controllerMethodUrl, int id, string token)
        {
            HttpClient httpClient = new HttpClient();
            //Variable response de tipo Http...
            HttpResponseMessage response;

            // Creacion de ruta
            string url = string.Format("{0}/{1}?id={2}", apiUrl, controllerMethodUrl, id);

            //Consumiendo la api
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            response = httpClient.DeleteAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return response;
        }



        protected string LoginToApi(string controllerMethodUrl, object BodyParameters)
        {
            HttpClient httpClient = new HttpClient();
            //Variable response de tipo Http...
            HttpResponseMessage response;

            //Formateo a JSON
            JsonMediaTypeFormatter JSONMediaFormatter = new JsonMediaTypeFormatter();

            // Creacion de ruta
            HttpContent theContent = null;
            string url = string.Format("{0}/{1}", apiUrl, controllerMethodUrl);

            if (BodyParameters != null)
            {
                theContent = new ObjectContent(BodyParameters.GetType(), BodyParameters, JSONMediaFormatter, new MediaTypeHeaderValue("application/json"));
            }

            //Consumiendo la api
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = httpClient.PostAsync(url, theContent).Result;
            //response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }

    }
}