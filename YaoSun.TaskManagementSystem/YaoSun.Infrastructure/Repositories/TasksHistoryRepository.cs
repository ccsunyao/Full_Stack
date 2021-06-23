using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Entities;
using YaoSun.ApplicationCore.RepositoryInterfaces;
using YaoSun.Infrastructure.Data;

namespace YaoSun.Infrastructure.Repositories
{
    public class TasksHistoryRepository : EfRepository<Tasks_History>, ITasksHistoryRepository
    {
        public TasksHistoryRepository(TaskManagementSystemDbContext dbContext) : base(dbContext)
        {

        }
        public override async Task<Tasks_History> GetByIdAsync(int taskid)
        {
            var tasks_history = await _dbContext.TasksHistory
                .Include(t => t.User).ThenInclude(u => u.Tasks)
                .FirstOrDefaultAsync(t => t.TaskId == taskid);
            return tasks_history;
        }
    }
}
