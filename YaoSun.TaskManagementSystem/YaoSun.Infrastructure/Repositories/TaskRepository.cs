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
    public class TaskRepository : EfRepository<Tasks>, ITaskRepository
    {
        public TaskRepository(TaskManagementSystemDbContext dbContext) : base(dbContext)
        {

        }
        public override async Task<Tasks> GetByIdAsync(int id)
        {
            var tasks = await _dbContext.Taskss
                .Include(t => t.User).ThenInclude(u => u.Tasks_Histories)
                .FirstOrDefaultAsync(t => t.Id == id);
            return tasks;
        }
    }
}
