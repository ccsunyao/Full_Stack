using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Models.Request;
using YaoSun.ApplicationCore.Models.Response;
using YaoSun.ApplicationCore.ServiceInterfaces;

namespace YaoSun.TaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpDelete]
        public async Task<string> DeleteTask(int id)
        {
            return await _taskService.DeleteTask(id);
        }

        [HttpGet]
        [Route("AllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();

            if (tasks.Any())
            {
                return Ok(tasks);
            }

            return NotFound("No tasks found.");
        }

        [HttpGet]
        [Route("EditProfile")]
        public async Task<IActionResult> EditTaskInfo(int id)
        {
            var taskInfo = await _taskService.GetTaskById(id);

            if (taskInfo == null)
            {
                return BadRequest("No task found.");
            }

            return Ok(taskInfo);
        }

        [HttpPost]
        [Route("EditTask")]
        public async Task<IActionResult> EditTaskInfo([FromBody] TaskCardResponseModel taskCardResponseModel)
        {
            if (ModelState.IsValid)
            {
                var taskInfo = await _taskService.EditTaskInfo(taskCardResponseModel);
                return Ok(taskInfo);
            }

            return BadRequest("Please check input.");
        }

        [HttpGet]
        [Route("ViewTask")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskById(id);

            if (task != null)
            {
                return Ok(task);
            }

            return BadRequest("No task found.");
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] CreateTaskRequestModel createTaskRequestModel)
        {
            if (ModelState.IsValid)
            {
                var createTask = await _taskService.RegisterTask(createTaskRequestModel);
                return Ok(createTask);
            }

            return BadRequest("Please check the data you entered.");
        }

        /*
        [HttpGet]
        [Route("TaskHistory")]
        public async Task<IActionResult> GetTasksHistoryByTaskId(int id)
        {
            var taskHistory = await _taskService.GetTasksHistoryByTaskId(id);

            return Ok(taskHistory);
        }*/

    }
}
