﻿namespace TaskListManager.Shared.AppTasks.Dtos
{
    public class AppTaskDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int AllottedTime { get; set; }
        public int ElapsedTime { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndDate { get; set;}
        public DateTime DueDate { get; set; }
        public int DaysOverdue { get; set; }
        public int DaysLate { get; set; }
    }
}
