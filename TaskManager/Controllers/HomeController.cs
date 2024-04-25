using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using System.Threading.Tasks; 

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskRepository _taskRepository;

        public HomeController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            var tasks = _taskRepository.GetAllTasks();
            return View(tasks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskManager.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _taskRepository.AddTask(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _taskRepository.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskManager.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _taskRepository.UpdateTask(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _taskRepository.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}
