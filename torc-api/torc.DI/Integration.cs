using Autofac;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;
using torc.business;
using torc.database;
using torc.Iface;

namespace torc.DI
{

    public class Integration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile(string.Format("appsettings.{0}.json", environment), optional: true);

            var configuration = config?.Build();
            builder.RegisterInstance(configuration);

          


            var _appSettings = configuration.GetSection("config");
            builder.RegisterInstance(_appSettings).As<IConfigurationSection>();

            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();

            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();

            builder.RegisterType<OrderBusiness>().As<IOrderBusiness>().SingleInstance();

            builder.RegisterType<ProductBusiness>().As<IProductBusiness>().SingleInstance();
            var container = builder.Build();


        }
    }
}

