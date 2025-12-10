namespace TaskManagementSystem.Core.DTOs.Task
{
    public class TaskRequestDto
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; } 
        public string TaskStatus { get; set; }
        public string TaskPriority { get; set; }
        public string CreationDate { get; set; }
    }
}
