using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.ExceptionHandling;
using MadUnderGrads.API.Filters;
using System.Web.ModelBinding;
using FluentValidation.WebApi;
using System.Configuration;
using System.Web.Http.Cors;

namespace MadUnderGrads.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// CORS settings
            //string allowedOrigins = ConfigurationManager.AppSettings["AllowedOrigins"].ToString();
            //var cors = new EnableCorsAttribute(allowedOrigins, "*", "*");
            //config.EnableCors(cors);

            // Web API configuration and services
            config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Tell Web API to use Fluentvalidation
            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
