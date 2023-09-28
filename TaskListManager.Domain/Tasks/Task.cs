namespace TaskListManager.Domain.Tasks
{
    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartDate { get; set; }
        public int AllotedTime { get; set; }
        public int ElaspedTime { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}