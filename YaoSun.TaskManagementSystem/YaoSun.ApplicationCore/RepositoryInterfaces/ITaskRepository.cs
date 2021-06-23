using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Entities;

namespace YaoSun.ApplicationCore.RepositoryInterfaces
{
    public interface ITaskRepository : IAsyncRepository<Tasks>
    {
    }
}
