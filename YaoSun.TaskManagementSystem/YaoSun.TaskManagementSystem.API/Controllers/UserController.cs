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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("AllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users.Any())
            {
                return Ok(users);
            }

            return NotFound("No users found.");
        }

        [HttpGet]
        [Route("TasksHistory")]
        public async Task<IActionResult> GetTasks(int id)
        {
            var tasks = await _userService.GetTasks(id);

            return Ok(tasks);
        }
    }
}
