using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.DTOs.Task;
using TaskManagementSystem.Core.Enums;
using TaskManagementSystem.Core.Interfaces;
using TaskManagementSystem.Infrastructure.Data;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(TaskRequestDto dto)
        {
            var task = new Models.Task
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = (Status)Enum.Parse(typeof(Status), dto.TaskStatus),
                Priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), dto.TaskStatus),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TaskResponseDto>> GetAllTaskAsync()
        {
            return await _context.Tasks.Select(e => new TaskResponseDto
            {
                TaskId = e.TaskId,
                Title = e.Title,
                Status = e.Status,
                Priority = e.Priority,
                CreatedAt = e.CreatedAt
            }).ToListAsync();
        }

        public async Task<TaskRequestDto> GetTaskByIdAsync(Guid id)
        {
            return await _context.Tasks
              .Where(e => e.TaskId == id)
              .Select(e => new TaskRequestDto
              {
                  TaskId = e.TaskId,
                  Title = e.Title,
                  Description = e.Description!,
              }).FirstAsync();
        }

        public async Task UpdateTaskAsync(TaskRequestDto dto)
        {
            var task = await _context.Tasks.FindAsync(dto.TaskId);

            dto!.Title = dto.Title;
            dto.Description = dto.Description;
            dto.TaskStatus = dto.TaskStatus;
            dto.TaskPriority = dto.TaskPriority;

            await _context.SaveChangesAsync();
        }
    }
}
