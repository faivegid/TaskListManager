using System.ComponentModel.DataAnnotations;

namespace TaskListManager.Shared.AppTasks
{
    public class TaskCreateRto
    {
        [Required]
        public string Name { get; set; }
        [Required, MaxLength(100), MinLength(10)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int AllottedTime { get; set; }
    }
}
