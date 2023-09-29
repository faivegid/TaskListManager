using Microsoft.AspNetCore.Mvc;
using TaskListManager.AppService.AppTasks;
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
            try
            {
                var data = await _taskService.GetTasks();
                var response = ApiResponse.Success(data);
                return StatusCode(response.StatusCode, response);
            }
            catch (ApiCallException ax)
            {
                var response = ApiResponse.Error(ax.ErrorMessage, ax.ApiResponseMessage);
                return StatusCode(response.StatusCode, response);
            }
            catch(Exception ex)
            {
                var response = ApiResponse.Error("Internal Server Error", ex.Message, System.Net.HttpStatusCode.InternalServerError);
                return StatusCode(response.StatusCode, response);
            }
        }

        [HttpGet, Route("/{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            try
            {
                var data = await _taskService.GetTask(id);
                var response = ApiResponse.Success(data);
                return StatusCode(response.StatusCode, response);
            }
            catch (ApiCallException ax)
            {
                var response = ApiResponse.Error(ax.ErrorMessage, ax.ApiResponseMessage, System.Net.HttpStatusCode.InternalServerError);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                var response = ApiResponse.Error("Internal Server Error", ex.Message);
                return StatusCode(response.StatusCode, response);
            }
        }
    }
}
