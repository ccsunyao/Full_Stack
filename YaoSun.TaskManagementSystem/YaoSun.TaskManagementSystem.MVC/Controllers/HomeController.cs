using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.ServiceInterfaces;
using YaoSun.TaskManagementSystem.MVC.Models;

namespace YaoSun.TaskManagementSystem.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly ITaskService _taskService;
        private readonly ITasksHistoryService _tasksHistoryService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, ITaskService taskService, ITasksHistoryService tasksHistoryService)
        {
            _logger = logger;
            _userService = userService;
            _taskService = taskService;
            _tasksHistoryService = tasksHistoryService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsers();
            var task = await _taskService.GetAllTasks();
            var tasksHisotry = await _tasksHistoryService.GetAllTasksHistory();

            dynamic intergratedModel = new ExpandoObject();
            intergratedModel.Users = users;
            intergratedModel.Tasks = task;
            intergratedModel.TasksHistory = tasksHisotry;
            return View(intergratedModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
