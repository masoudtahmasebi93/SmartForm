using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using SmartForm.Services.Activities.Events;
using SmartForm.Services.Activities.Repositories;

namespace SmartForm.Services.Activities.Controllers
{
    [Route("[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReportsController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IReportRepository _repository;

        public ReportsController(IBusClient busClient,
            IReportRepository repository)
        {
            _busClient = busClient;
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var activities = await _repository
                .GetAsync();

            return Json(activities.Select(x => new {x.Id, x.Name, x.Category, x.CreatedAt}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var activity = await _repository.GetAsync(id);
            if (activity == null) return NotFound();
            if (activity.UserId != Guid.Parse(User.Identity.Name)) return Unauthorized();

            return Json(activity);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] CreateReport command)
        {
            command.Id = Guid.NewGuid();
            command.UserId = Guid.Parse(User.Identity.Name);
            command.CreatedAt = DateTime.UtcNow;
            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }
    }
}