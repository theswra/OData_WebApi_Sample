using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using OData_WCF_Services.Model;

namespace OData_WebApi_Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // STANDARD WEB API CONFIG

            config.Routes.MapHttpRoute(
                name: "SandardWebApiRoute",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            
            // ODATA CONFIG

            // no!
            //config.Routes.MapHttpRoute(
            //    name: "ODataRoute",
            //    routeTemplate: "odata/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // Routing rules for OData controllers
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Category>("Categories");

            config.Routes.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport(); // obsolete
            config.AddODataQueryFilter();

            /*
            Install-Package Microsoft.AspNet.WebApi.Tracing
            Update-Package Microsoft.AspNet.WebApi.WebHost
            
            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            */

        }
    }
}
