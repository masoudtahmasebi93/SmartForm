using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using SmartForm.Services.Form.Commands;
using SmartForm.Services.Form.Domain.Models;
using SmartForm.Services.Form.Services;

namespace SmartTemplate.Services.Template.Controllers
{
    [Route("[controller]")]
    public class TemplatesController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly ITemplateService _templateService;

        public TemplatesController(IBusClient busClient, ITemplateService templateService)
        {
            _busClient = busClient;
            _templateService = templateService;
        }

        [HttpPost]
        public async Task<ActionResult<TemplateModel>> Post([FromBody] TemplateModel command)
        {
            command.Id = new Guid();
            await _templateService.AddAsync(command);

            return Accepted(command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TemplateModel command)
        {
            if (id != command.Id) return BadRequest();
            try
            {
                await _templateService.UpdateAsync(id,command);
            }
            catch (Exception exception)
            {
                if (!TemplatesExists(id))
                    return NotFound();
                throw exception;
            }

            return Accepted(command);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemplateModel>>> Get()
        {
            return Ok(await _templateService.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateModel>> Get([FromRoute] Guid id)
        {
            var template = await _templateService.GetAsync(id);

            if (template == null) return NotFound();
            return Ok(template);
        }


        // DELETE: api/Templates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TemplateModel>> DeleteTemplates(Guid id)
        {
            var templates = await _templateService.GetAsync(id);
            if (templates == null) return NotFound();

            try
            {
                await _templateService.RemoveAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }

        private bool TemplatesExists(Guid id)
        {
            return _templateService.Any(id);
        }

        private async Task<TemplateModel> GetTemplate(Guid id)
        {
            return await _templateService.GetAsync(id);
        }
    }
}