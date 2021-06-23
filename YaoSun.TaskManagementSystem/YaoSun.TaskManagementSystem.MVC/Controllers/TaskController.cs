using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Models.Request;
using YaoSun.ApplicationCore.ServiceInterfaces;

namespace YaoSun.TaskManagementSystem.MVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("Task/Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateTaskRequestModel createTaskRequestModel)
        {
            if (ModelState.IsValid)
            {
                await _taskService.RegisterTask(createTaskRequestModel);
                return LocalRedirect("~/");
            }

            return View();
        }
        public IActionResult Index()
        {
            return LocalRedirect("~/");
        }
    }
}
