using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Models.Request;
using YaoSun.ApplicationCore.Models.Response;

namespace YaoSun.ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserCardResponseModel> GetUserById(int id);
        Task<ICollection<UserCardResponseModel>> GetAllUsers();
        Task<UserCardResponseModel> RegisterUser(CreateUserRequestModel createUserRequestModel);
        Task<UserCardResponseModel> EditUserInfo(UserCardResponseModel userCardResponseModel);
        Task<string> DeleteUser(int id);
        Task<ICollection<TaskCardResponseModel>> GetTasks(int Id);
    }
}
