using SmartForm.Common.Services;
using SmartForm.Services.Form.Commands;

namespace SmartForm.Services.Form
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
               .UseRabbitMq()
               .SubscribeToCommand<CreateForm>()
               .Build()
               .Run();
        }
    }
}