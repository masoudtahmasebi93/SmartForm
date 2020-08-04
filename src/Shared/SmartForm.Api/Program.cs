using SmartForm.Common.Services;

namespace SmartForm.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .Build()
                .Run();

            // var temp = ServiceHost.CreateWebHost<Startup>(args).Build().UseRabbitMq()
            //      .ConfigureAppConfiguration((hostingContext, config) =>
            //      {
            //          config
            //              .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            //              .AddJsonFile("appsettings.json", true, true)
            //              .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
            //              .AddJsonFile("ocelot.json")
            //              .AddEnvironmentVariables();
            //      })
            //    .ConfigureServices(s => {
            //        s.AddOcelot();
            //    })
            //    .ConfigureLogging((hostingContext, logging) =>
            //    {
            //        //add your logging
            //    })
            //    .UseIISIntegration()
            //    .Configure(app =>
            //    {
            //        app.UseOcelot().Wait();
            //    }).Build();
            //temp.Run()
            //     .UseRabbitMq()
            //     .Build()

            //     .Run();
        }
    }
}