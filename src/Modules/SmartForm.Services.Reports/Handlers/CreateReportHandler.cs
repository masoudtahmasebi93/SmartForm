using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RawRabbit;
using SmartForm.Common.Commands;
using SmartForm.Common.Exceptions;
using SmartForm.Services.Activities.Events;
using SmartForm.Services.Activities.Services;

namespace SmartForm.Services.Activities.Handlers
{
    public class CreateReportHandler : ICommandHandler<CreateReport>
    {
        private readonly IReportService _reportService;
        private readonly IBusClient _busClient;
        private readonly ILogger _logger;

        public CreateReportHandler(IBusClient busClient,
            IReportService reportService,
            ILogger<CreateReportHandler> logger)
        {
            _busClient = busClient;
            _reportService = reportService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateReport command)
        {
            _logger.LogInformation($"Creating activity: '{command.Id}' for user: '{command.UserId}'.");
            try
            {
                await _reportService.AddAsync(command.Id, command.UserId,
                    command.Category, command.Name, command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new ReportCreated(command.Id,
                    command.UserId, command.Category, command.Name, command.Description, command.CreatedAt));
                _logger.LogInformation($"Activity: '{command.Id}' was created for user: '{command.UserId}'.");
            }
            catch (SmartFormException ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new CreateReportRejected(command.Id,
                    ex.Message, ex.Code));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new CreateReportRejected(command.Id,
                    ex.Message, "error"));
            }
        }
    }
}