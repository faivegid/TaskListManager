using Microsoft.AspNetCore.Mvc;
using TaskListManager.AppService.Tasks;

namespace TaskListManager.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskAppService _taskService;

        public TaskController(ITaskAppService taskService)
        {
            this._taskService = taskService;
        }
    }
}
