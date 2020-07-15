using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using SmartForm.Services.Form.Commands;
using SmartForm.Services.Form.Domain.Models;
using SmartForm.Services.Form.Services;

namespace SmartForm.Services.Form.Controllers
{
    [Route("[controller]")]
    public class FormsController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IFormService _formService;

        public FormsController(IBusClient busClient, IFormService formService)
        {
            _busClient = busClient;
            _formService = formService;
        }

        [HttpPost]
        public async Task<ActionResult<FormModel>> Post([FromBody] CreateForm command)
        {
            await _busClient.PublishAsync(command);

            return Accepted(command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateForm command)
        {
            if (id != command.Id) return BadRequest();
            try
            {
                await _busClient.PublishAsync(command);
            }
            catch (Exception exception)
            {
                if (!FormsExists(id))
                    return NotFound();
                throw exception;
            }

            return Accepted(command);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormModel>>> Get()
        {
            return Ok(await _formService.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormModel>> Get([FromRoute] Guid id)
        {
            var form = await _formService.GetAsync(id);

            if (form == null) return NotFound();
            return Ok(form);
        }


        // DELETE: api/Forms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FormModel>> DeleteForms(Guid id)
        {
            var forms = await _formService.GetAsync(id);
            if (forms == null) return NotFound();

            try
            {
                await _formService.RemoveAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }

        private bool FormsExists(Guid id)
        {
            return _formService.Any(id);
        }

        private async Task<FormModel> GetForm(Guid id)
        {
            return await _formService.GetAsync(id);
        }
    }
}