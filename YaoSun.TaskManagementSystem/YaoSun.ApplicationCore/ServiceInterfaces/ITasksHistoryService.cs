using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Models.Request;
using YaoSun.ApplicationCore.Models.Response;

namespace YaoSun.ApplicationCore.ServiceInterfaces
{
    public interface ITasksHistoryService
    {
        Task<ICollection<TasksHistoryCardResponseModel>> GetAllTasksHistory();
        Task<TasksHistoryCardResponseModel> GetTasksHistoryByTaskId(int taskId);
        Task<TasksHistoryCardResponseModel> AddTasksHistory(CreateTasksHistoryRequestModel createTasksHistoryRequestModel);
        Task<TasksHistoryCardResponseModel> EditTasksHistory(TasksHistoryCardResponseModel tasksHistoryCardResponseModel);
        Task<string> DeleteTasksHistory(int taskId);
    }
}
