using TaskListManager.Shared.AppTasks.Dtos;

namespace TaskListManager.AppService.AppTasks
{
    public interface ITaskAppService
    {
        Task<AppTaskDto> GetTask(int id);
        Task<List<AppTaskDto>> GetTasks();
    }
}
