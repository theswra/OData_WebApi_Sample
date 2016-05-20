using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OData_WebApi_Services.Startup))]

namespace OData_WebApi_Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
