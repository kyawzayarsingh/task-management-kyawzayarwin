using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Core.Enums;

namespace TaskManagementSystem.Infrastructure.Models
{
    public class Task
    {
        [Key]
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }  
        public TaskPriority Priority { get; set; }
        public DateOnly DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
