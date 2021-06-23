using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.ServiceInterfaces;

namespace YaoSun.TaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksHistoryController : ControllerBase
    {
        private readonly ITasksHistoryService _tasksHistoryService;
        public TasksHistoryController(ITasksHistoryService tasksHistoryService)
        {
            _tasksHistoryService = tasksHistoryService;
        }

        [HttpGet]
        [Route("AllTasksHistory")]
        public async Task<IActionResult> GetAllTasksHistory()
        {
            var tasksHistory = await _tasksHistoryService.GetAllTasksHistory();

            if (tasksHistory.Any())
            {
                return Ok(tasksHistory);
            }

            return NotFound("No tasks history found.");
        }
    }
}
