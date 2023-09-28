namespace TaskListManager.Domain.Tasks
{
    public class AppTask
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int AllottedTime { get; set; }
        public int ElapsedTime { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}