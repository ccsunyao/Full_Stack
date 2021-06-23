using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Entities;
using YaoSun.ApplicationCore.Models.Request;
using YaoSun.ApplicationCore.Models.Response;
using YaoSun.ApplicationCore.RepositoryInterfaces;
using YaoSun.ApplicationCore.ServiceInterfaces;

namespace YaoSun.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<string> DeleteTask(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return await _taskRepository.DeleteAsync(task);
        }

        public async Task<ICollection<TaskCardResponseModel>> GetAllTasks()
        {
            var tasks = await _taskRepository.ListAllAsync();
            var taskCollection = new List<TaskCardResponseModel>();

            foreach (var task in tasks)
            {
                var taskCard = new TaskCardResponseModel()
                {
                    Id = task.Id,
                    userid = task.userid,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Priority = task.Priority,
                    Remarks = task.Remarks
                };

                taskCollection.Add(taskCard);
            }

            return taskCollection;
        }

        public async Task<TaskCardResponseModel> EditTaskInfo(TaskCardResponseModel taskCardResponseModel)
        {
            var task = await _taskRepository.GetByIdAsync(taskCardResponseModel.Id);

            if (task == null)
            {
                return null;
            }

            task.userid = taskCardResponseModel.userid;
            task.Title = taskCardResponseModel.Title;
            task.Description = taskCardResponseModel.Description;
            task.DueDate = taskCardResponseModel.DueDate;
            task.Priority = taskCardResponseModel.Priority;
            task.Remarks = taskCardResponseModel.Remarks;

            await _taskRepository.UpdateAsync(task);

            return taskCardResponseModel;
        }

        public async Task<TaskCardResponseModel> GetTaskById(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
            {
                return null;
            }

            var response = new TaskCardResponseModel()
            {
                Id = task.Id,
                userid = task.userid,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Remarks = task.Remarks
            };

            return response;
        }

        public async Task<TaskCardResponseModel> RegisterTask(CreateTaskRequestModel createTaskRequestModel)
        {
            var task = new Tasks
            {
                userid = createTaskRequestModel.UserId,
                Title = createTaskRequestModel.Title,
                Description = createTaskRequestModel.Description,
                DueDate = createTaskRequestModel.DueDate,
                Priority = createTaskRequestModel.Priority,
                Remarks = createTaskRequestModel.Remarks
            };

            var createdTask = await _taskRepository.AddAsync(task);

            var response = new TaskCardResponseModel
            {
                Id = createdTask.Id,
                userid = createdTask.userid,
                Title = createdTask.Title,
                Description = createdTask.Description,
                DueDate = createdTask.DueDate,
                Priority = createdTask.Priority,
                Remarks = createdTask.Remarks
            };
            return response;
        }
    }
}
