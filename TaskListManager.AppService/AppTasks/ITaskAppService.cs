using TaskListManager.Shared.AppTasks;
using TaskListManager.Shared.AppTasks.Dtos;

namespace TaskListManager.AppService.AppTasks
{
    public interface ITaskAppService
    {
        Task<AppTaskDto> CreateTask(TaskCreateRto createRequest);
        Task<bool> DeleteTask(string id);
        Task<AppTaskDto> GetTask(string id);
        Task<List<AppTaskDto>> GetTasks();
        Task<AppTaskDto> UpdateTask(string id, TaskUpdateRto updateRto);
    }
}
