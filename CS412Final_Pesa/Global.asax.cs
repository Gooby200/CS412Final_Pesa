using CS412Final_Pesa.BLL;
using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using Newtonsoft.Json.Serialization;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unity;

namespace CS412Final_Pesa {
    public class Global : HttpApplication {
        void Application_Start(object sender, EventArgs e) {
            var container = this.AddUnity();
            container.RegisterType<IOrderBLL, OrderBLL>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IServiceRepository, ServiceRepository>();
            container.RegisterType<IUserRepository, UserRepository>();

            var serializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            var contractResolver = (DefaultContractResolver)serializerSettings.ContractResolver;
            contractResolver.IgnoreSerializableAttribute = true;

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);


        }
    }
}