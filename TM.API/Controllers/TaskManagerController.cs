using Microsoft.AspNetCore.Mvc;
using TM.API.Repositories;
using TM.API.Services;

namespace TM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private readonly ITaskManagerService _taskManagerService;
        private readonly ILogger<TaskManagerController> _logger;

        public TaskManagerController(ITaskManagerService taskManagerService, ILogger<TaskManagerController> logger)
        {
            _taskManagerService = taskManagerService;
            _logger = logger;
        }

        [HttpGet("{startDateStr}/{numOfDaysNeeded}")]
        public async Task<ActionResult> Get(string startDateStr, int numOfDaysNeeded)
        {
            var completionDate = await _taskManagerService.GetTaskCompletionDate(startDateStr, numOfDaysNeeded);
            return Ok(completionDate);
        }
    }
}
