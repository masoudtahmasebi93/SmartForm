using Microsoft.AspNetCore.Mvc;
using SmartForm.Common.Domain.Models;
using SmartForm.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartForm.Common.Controllers
{
    [Route("[controller]")]
    public class GenericController<T> : Controller where T : BaseModel
    {
        private IEntityService<T> _baseService;

        public GenericController(IEntityService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody] T command)
        {
            await _baseService.AddAsync(command);

            return Accepted(command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] T command)
        {
            if (id != command.Id) return BadRequest();
            try
            {
                await _baseService.UpdateAsync(id,command);
            }
            catch (Exception exception)
            {
                if (!Exists(id))
                    return NotFound();
                throw exception;
            }

            return Accepted(command);
        }

        [HttpPut("SingleField/{id}")]
        public async Task<IActionResult> PutSingleField(Guid id, [FromBody] dynamic command)
        {
            if (id == Guid.Empty) return BadRequest();
            try
            {
                await _baseService.UpdateSingleFieldAsync(id, command);
            }
            catch (Exception exception)
            {
                if (!Exists(id))
                    return NotFound();
                throw exception;
            }

            return Accepted(command);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return Ok(await _baseService.GetAsync());
        }
        [HttpGet("User/{userId}")]
        public ActionResult<List<T>> UserEntities(Guid userId)
        {
            return Ok(_baseService.Get(a => a.UserId == userId));
        }


        [HttpGet("Search/{search}")]
        public ActionResult<List<T>> Search(string search)
        {
            return Ok(_baseService.Get(a => a.Name.Contains(search)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get([FromRoute] Guid id)
        {
            var form = await _baseService.GetAsync(id);

            if (form == null) return NotFound();
            return Ok(form);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(Guid id)
        {
            var forms = await _baseService.GetAsync(id);
            if (forms == null) return NotFound();

            try
            {
                await _baseService.RemoveAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public bool Exists(Guid id)
        {
            return _baseService.Any(id);
        }
    }
}
