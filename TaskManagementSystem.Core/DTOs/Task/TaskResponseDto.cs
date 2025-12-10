using TaskManagementSystem.Core.Enums;

namespace TaskManagementSystem.Core.DTOs.Task
{
    public class TaskResponseDto
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
