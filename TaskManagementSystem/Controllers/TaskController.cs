using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
