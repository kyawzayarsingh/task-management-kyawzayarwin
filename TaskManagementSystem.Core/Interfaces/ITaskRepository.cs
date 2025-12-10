using TaskManagementSystem.Core.DTOs.Task;

namespace TaskManagementSystem.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskResponseDto>> GetAllTaskAsync();
        Task<TaskRequestDto> GetTaskByIdAsync(Guid id);
        Task AddTaskAsync(TaskRequestDto employee);
        Task UpdateTaskAsync(TaskRequestDto employee);
        Task DeleteTaskAsync(Guid id);

    }
}
