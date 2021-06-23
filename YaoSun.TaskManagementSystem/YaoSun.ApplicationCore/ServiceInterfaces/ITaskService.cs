using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Models.Request;
using YaoSun.ApplicationCore.Models.Response;

namespace YaoSun.ApplicationCore.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<TaskCardResponseModel> GetTaskById(int id);
        Task<ICollection<TaskCardResponseModel>> GetAllTasks();
        Task<TaskCardResponseModel> RegisterTask(CreateTaskRequestModel createTaskRequestModel);
        Task<TaskCardResponseModel> EditTaskInfo(TaskCardResponseModel taskCardResponseModel);
        Task<string> DeleteTask(int id);
        // Task<ICollection<TasksHistoryCardResponseModel>> GetTasksHistoryByTaskId(int taskId);
    }
}
