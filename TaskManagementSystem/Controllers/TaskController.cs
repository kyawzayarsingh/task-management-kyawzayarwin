using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using TaskManagementSystem.Core.Enums;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepo;

        public TaskController(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _taskRepo.GetAllTaskAsync();
            return View(tasks);
        }

        public IActionResult Create()
        {
            var statusList = Enum.GetValues(typeof(Status))
                             .Cast<Status>()
                             .Select(e => new SelectListItem
                             {
                                 Value = e.ToString(),
                                 Text = e.ToString()
                             }).ToList();

            var priorityList = Enum.GetValues(typeof(TaskPriority))
                             .Cast<TaskPriority>()
                             .Select(e => new SelectListItem
                             {
                                 Value = e.ToString(),
                                 Text = e.ToString()
                             }).ToList();

            ViewBag.TaskStatus = statusList;
            ViewBag.TaskPriority = priorityList;

            return View();
        }
    }
}
