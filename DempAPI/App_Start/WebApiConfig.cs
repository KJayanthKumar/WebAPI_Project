using DempAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace DempAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //This enables the attribute routing
            config.MapHttpAttributeRoutes();


            //Below is the route table 

            config.Routes.MapHttpRoute(
                name: "ByDefaultApi",
                routeTemplate: "api/People/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "People" }
            );

            config.Routes.MapHttpRoute(
                name: "Version1",
                routeTemplate: "api/v1/person/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "Person1" }
            );

            config.Routes.MapHttpRoute(
                name: "Version2",
                routeTemplate: "api/v2/person/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "Person2" }
            );

            #region Action Filters - Global scope

            config.Filters.Add(new MyActionFilter2("filter at global level"));

            #endregion
            // configure json formatter
            JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }
    }
}
