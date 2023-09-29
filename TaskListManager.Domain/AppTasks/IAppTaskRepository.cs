namespace TaskListManager.Domain.AppTasks
{
    public interface IAppTaskRepository
    {
        Task<AppTask> Create(AppTask newTask);
        Task<bool> Delete(string id);
        Task<List<AppTask>> Get();
        Task<AppTask> Get(string id);
        Task<AppTask> Update(AppTask updatedTask);
    }
}