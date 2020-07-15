using SmartForm.Common.Services;
using SmartForm.Services.Activities.Events;

namespace SmartForm.Services.Activities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<ReportCreated>()
                .SubscribeToCommand<CreateReport>()
                .Build()
                .Run();
        }
    }
}