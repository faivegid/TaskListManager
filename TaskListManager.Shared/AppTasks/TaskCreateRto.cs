namespace TaskListManager.Shared.AppTasks
{
    public class TaskCreateRto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int AllottedTime { get; set; }
    }
}
