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
    public class TasksHistoryService : ITasksHistoryService
    {
        private readonly ITasksHistoryRepository _tasksHistoryRepository;

        public TasksHistoryService(ITasksHistoryRepository tasksHistoryRepository)
        {
            _tasksHistoryRepository = tasksHistoryRepository;
        }

        public async Task<string> DeleteTasksHistory(int id)
        {
            var tasksHistory = await _tasksHistoryRepository.GetByIdAsync(id);
            return await _tasksHistoryRepository.DeleteAsync(tasksHistory);
        }

        public async Task<ICollection<TasksHistoryCardResponseModel>> GetAllTasksHistory()
        {
            var tasksHistories = await _tasksHistoryRepository.ListAllAsync();
            var tasksHistoryCollection = new List<TasksHistoryCardResponseModel>();

            foreach (var tasksHistory in tasksHistories)
            {
                var tasksHistoryCard = new TasksHistoryCardResponseModel()
                {
                    TaskId = tasksHistory.TaskId,
                    UserId = tasksHistory.UserId,
                    Title = tasksHistory.Title,
                    Description = tasksHistory.Description,
                    DueDate = tasksHistory.DueDate,
                    Completed = tasksHistory.Completed,
                    Remarks = tasksHistory.Remarks
                };

                tasksHistoryCollection.Add(tasksHistoryCard);
            }

            return tasksHistoryCollection;
        }

        public async Task<TasksHistoryCardResponseModel> EditTasksHistory(TasksHistoryCardResponseModel tasksHistoryCardResponseModel)
        {
            var tasksHistory = await _tasksHistoryRepository.GetByIdAsync(tasksHistoryCardResponseModel.TaskId);

            if (tasksHistory == null)
            {
                return null;
            }

            tasksHistory.TaskId = tasksHistoryCardResponseModel.TaskId;
            tasksHistory.UserId = tasksHistoryCardResponseModel.UserId;
            tasksHistory.Title = tasksHistoryCardResponseModel.Title;
            tasksHistory.Description = tasksHistoryCardResponseModel.Description;
            tasksHistory.DueDate = tasksHistoryCardResponseModel.DueDate;
            tasksHistory.Completed = tasksHistoryCardResponseModel.Completed;
            tasksHistory.Remarks = tasksHistoryCardResponseModel.Remarks;

            await _tasksHistoryRepository.UpdateAsync(tasksHistory);

            return tasksHistoryCardResponseModel;
        }

       // Task<TasksHistoryCardResponseModel> GetTasksHistoryByTaskId(int taskId);
        public async Task<TasksHistoryCardResponseModel> GetTasksHistoryByTaskId(int TaskId)
        {
            var tasksHistory = await _tasksHistoryRepository.GetByIdAsync(TaskId);

            if (tasksHistory == null)
            {
                return null;
            }

            var response = new TasksHistoryCardResponseModel()
            {
                TaskId = tasksHistory.TaskId,
                UserId = tasksHistory.UserId,
                Title = tasksHistory.Title,
                Description = tasksHistory.Description,
                DueDate = tasksHistory.DueDate,
                Completed = tasksHistory.Completed,
                Remarks = tasksHistory.Remarks
            };
            return response;
        }

        public async Task<TasksHistoryCardResponseModel> AddTasksHistory(CreateTasksHistoryRequestModel createInteractionRequestModel)
        {
            var tasksHistory = new Tasks_History
            {
                TaskId = createInteractionRequestModel.TaskId,
                UserId = createInteractionRequestModel.UserId,
                Title = createInteractionRequestModel.Title,
                Description = createInteractionRequestModel.Description,
                DueDate = createInteractionRequestModel.DueDate,
                Completed = createInteractionRequestModel.Completed,
                Remarks = createInteractionRequestModel.Remarks
            };

            var createdInteraction = await _tasksHistoryRepository.AddAsync(tasksHistory);

            var response = new TasksHistoryCardResponseModel
            {
                TaskId = createInteractionRequestModel.TaskId,
                UserId = createInteractionRequestModel.UserId,
                Title = createInteractionRequestModel.Title,
                Description = createInteractionRequestModel.Description,
                DueDate = createInteractionRequestModel.DueDate,
                Completed = createInteractionRequestModel.Completed,
                Remarks = createInteractionRequestModel.Remarks
            };

            return response;
        }

    }
}
