using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartForm.Common.Auth;
using SmartForm.Common.Commands;
using SmartForm.Common.Mongo;
using SmartForm.Common.RabbitMq;
using SmartForm.Services.Form.Commands;
using SmartForm.Services.Form.Handlers;
using SmartForm.Services.Form.Repository;
using SmartForm.Services.Form.Services;

namespace SmartForm.Services.Form
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
            services.AddControllers();
            services.AddMvc().AddMvcOptions(mv => mv.EnableEndpointRouting = false);
            services.AddLogging();
            services.AddJwt(Configuration);
            services.AddMongoDB(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddSingleton<ICommandHandler<CreateForm>, CreateFormHandler>();
            services.AddSingleton<IFormRepository, FormRepository>();
            services.AddSingleton<IFormService, FormService>();
            services.AddSingleton<ITemplateRepository, TemplateRepository>();
            services.AddSingleton<ITemplateService, TemplateService>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "form-service"); });

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}