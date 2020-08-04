using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SmartForm.Common.Auth;
using SmartForm.Common.Mongo;
using SmartForm.Common.RabbitMq;

namespace SmartForm.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
           //.SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
           .AddJsonFile("ocelot.json")
           .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(mv => mv.EnableEndpointRouting = false);
            //services.AddJwt(Configuration);
            services.AddAuth(Configuration);
            //services.AddAuthentication();
            services.AddRabbitMq(Configuration);
            services.AddMongoDB(Configuration);
            
            services.AddSwaggerGen();
            services.AddOcelot(Configuration);
                services.AddSwaggerForOcelot(Configuration); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseAuthentication();
            app.UseMvc();
            app.UseOcelot().Wait();
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });
        }
    }
}