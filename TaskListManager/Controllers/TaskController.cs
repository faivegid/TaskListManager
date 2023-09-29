using Microsoft.AspNetCore.Mvc;
using TaskListManager.AppService.AppTasks;
using TaskListManager.Shared.AppTasks;
using TaskListManager.Shared.Exceptions;
using TaskListManager.Shared.Responses;

namespace TaskListManager.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskAppService _taskService;

        public TaskController(ITaskAppService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet, Route("/")]
        public async Task<IActionResult> Get()
        {
            var data = await _taskService.GetTasks();
            var response = ApiResponse.Success(data);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet, Route("/{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var data = await _taskService.GetTask(id);
            var response = ApiResponse.Success(data);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateRto createRequest)
        {
            var data = await _taskService.CreateTask(createRequest);
            var response = ApiResponse.Success(data, System.Net.HttpStatusCode.Created);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch, Route("/{id}")]
        public async Task<IActionResult> UpdateTask([FromRoute] string id, [FromBody] TaskUpdateRto updateRequest)
        {
            var data = await _taskService.UpdateTask(id, updateRequest);
            var response = ApiResponse.Success(data);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete, Route("/{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] string id)
        {
            var data = await _taskService.DeleteTask(id);
            var response = ApiResponse.Success(data);
            return StatusCode(response.StatusCode, response);
        }
    }
}
