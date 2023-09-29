namespace TaskListManager.Domain.AppTasks
{
    public interface IAppTaskRepository
    {
        Task<AppTask> Create(AppTask newTask);
        Task<bool> Delete(int id);
        Task<List<AppTask>> Get();
        Task<AppTask> Get(int id);
        Task<AppTask> Update(AppTask updatedTask);
    }
}