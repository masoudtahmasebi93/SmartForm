using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartForm.Common.Auth;
using SmartForm.Common.Commands;
using SmartForm.Common.Mongo;
using SmartForm.Common.RabbitMq;
using SmartForm.Services.Identity.Domain.Repositories;
using SmartForm.Services.Identity.Domain.Services;
using SmartForm.Services.Identity.Handlers;
using SmartForm.Services.Identity.Repositories;
using SmartForm.Services.Identity.Services;

namespace SmartForm.Services.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(mv => mv.EnableEndpointRouting = false);
            services.AddLogging();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddJwt(Configuration);
            services.AddMongoDB(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddSingleton<ICommandHandler<CreateUser>, CreateUserHandler>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IEncrypter, Encrypter>();

            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<ICompanyService, CompanyService>();


            services.AddSwaggerGen
                (c =>
                c.IncludeXmlComments(string.Format(@"{0}\SmartForm.Services.Identity.xml",
                System.AppDomain.CurrentDomain.BaseDirectory)));
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
            app.UseCors("MyPolicy");
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}