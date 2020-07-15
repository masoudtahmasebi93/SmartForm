using System;
using System.Threading.Tasks;
using SmartForm.Common.Events;
using SmartForm.Services.Activities.Repositories;

namespace SmartForm.Services.Activities
{
    public class ReportCreatedHandler : IEventHandler<ReportCreated>
    {
        private readonly IReportRepository _repository;

        public ReportCreatedHandler(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(ReportCreated @event)
        {
            // await _repository.AddAsync(new Activity(Guid.Empty, Guid.Empty,Guid.Empty, "","",DateTime.Now)
            // {
            //     Id = @event.Id,
            //     UserId = @event.UserId,
            //     Category = @event.Category,
            //     Name = @event.Name,
            //     CreatedAt = @event.CreatedAt,
            //     Description = @event.Description
            // });
            Console.WriteLine($"Activity created: {@event.Name}");
        }
    }
}