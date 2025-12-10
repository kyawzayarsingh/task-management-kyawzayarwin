using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Core.DTOs.Task;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAPIController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskAPIController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> Tasks()
        {
            var tasks = await _taskRepository.GetAllTaskAsync();
            return Ok(tasks);
        }

        [HttpPost("tasks")]
        public async Task<IActionResult> Create([FromBody] TaskRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _taskRepository.AddTaskAsync(dto);
            return new JsonResult(true);
        }

        
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _taskRepository.GetTaskByIdAsync(id);
            return new JsonResult(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] TaskRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _taskRepository.UpdateTaskAsync(dto);
            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var emp = await _taskRepository.GetTaskByIdAsync(id);
            return Ok(emp);
        }

        [HttpDelete("tasks/id")]
        public async Task<IActionResult> DeleteConfirmed([FromBody] Guid id)
        {
            await _taskRepository.DeleteTaskAsync(id);
            return new JsonResult(new { success = true });
        }
    }
}
