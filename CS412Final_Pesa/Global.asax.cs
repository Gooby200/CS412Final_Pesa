using Newtonsoft.Json.Serialization;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace CS412Final_Pesa {
    public class Global : HttpApplication {
        void Application_Start(object sender, EventArgs e) {
            var serializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            var contractResolver = (DefaultContractResolver)serializerSettings.ContractResolver;
            contractResolver.IgnoreSerializableAttribute = true;

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}