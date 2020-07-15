using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartForm.Common.Commands;
using SmartForm.Common.Events;
using SmartForm.Common.Mongo;
using SmartForm.Common.RabbitMq;
using SmartForm.Services.Activities.Events;
using SmartForm.Services.Activities.Handlers;
using SmartForm.Services.Activities.Repositories;
using SmartForm.Services.Activities.Services;

namespace SmartForm.Services.Activities
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
            services.AddMongoDB(Configuration);
            services.AddSingleton<IFolderRepository, FolderRepository>();
            services.AddSingleton<IReportRepository, ReportRepository>();
            services.AddSingleton<IDatabaseSeeder, CustomMongoSeeder>();
            services.AddRabbitMq(Configuration);
            services.AddSingleton<ICommandHandler<CreateReport>, CreateReportHandler>();
            services.AddSingleton<IReportService, ReportService>();
            services.AddSingleton<IEventHandler<ReportCreated>, ReportCreatedHandler>();
            services.AddSingleton<IReportRepository, ReportRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}