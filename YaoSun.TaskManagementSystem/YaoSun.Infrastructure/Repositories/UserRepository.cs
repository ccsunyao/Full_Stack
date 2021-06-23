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
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(TaskManagementSystemDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<User> GetByIdAsync(int Id)
        {
            var user = await _dbContext.Users
                .Include(u => u.Tasks_Histories)
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == Id);
            return user;
        }
    }
}