using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RawRabbit;
using SmartForm.Common.Commands;
using SmartForm.Common.Exceptions;
using SmartForm.Services.Form.Commands;
using SmartForm.Services.Form.Events;
using SmartForm.Services.Form.Services;

namespace SmartForm.Services.Form.Handlers
{
    public class CreateFormHandler : ICommandHandler<CreateForm>
    {
        private readonly IBusClient _busClient;
        private readonly IFormService _formService;
        private readonly ILogger _logger;

        public CreateFormHandler(IBusClient busClient, IFormService formService,
            ILogger<CreateFormHandler> logger)
        {
            _busClient = busClient;
            _formService = formService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateForm command)
        {
            _logger.LogInformation($"Creating form: '{command.Id}' for user: '{command.UserId}'.");
            try
            {
                await _formService.AddAsync(command);
                await _busClient.PublishAsync(new FormCreated());
                _logger.LogInformation($"form: '{command.Id}' was created for user: '{command.UserId}'.");
            }
            catch (SmartFormException ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new CreateFormRejected(command.Id,
                    ex.Message, ex.Code));
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}