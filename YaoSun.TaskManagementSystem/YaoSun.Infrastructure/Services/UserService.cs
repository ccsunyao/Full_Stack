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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return await _userRepository.DeleteAsync(user);
        }

        public async Task<UserCardResponseModel> EditUserInfo(UserCardResponseModel userCardResponseModel)
        {
            var user = await _userRepository.GetByIdAsync(userCardResponseModel.Id);

            if (user == null)
            {
                return null;
            }

            user.Email = userCardResponseModel.Email;
            user.Password = userCardResponseModel.Password;
            user.Fullname = userCardResponseModel.Fullname;
            user.Mobileno = userCardResponseModel.Mobileno;

            await _userRepository.UpdateAsync(user);

            return userCardResponseModel;
        }

        public async Task<ICollection<UserCardResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.ListAllAsync();
            var userCollection = new List<UserCardResponseModel>();

            foreach (var user in users)
            {
                var userCard = new UserCardResponseModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    Fullname = user.Fullname,
                    Mobileno = user.Mobileno
                };

                userCollection.Add(userCard);
            }

            return userCollection;
        }

        public async Task<UserCardResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            var response = new UserCardResponseModel()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Fullname = user.Fullname,
                Mobileno = user.Mobileno
            };

            return response;
        }

        public async Task<UserCardResponseModel> RegisterUser(CreateUserRequestModel createUserRequestModel)
        {
            var user = new User
            {
                Email = createUserRequestModel.Email,
                Password = createUserRequestModel.Password,
                Fullname = createUserRequestModel.Fullname,
                Mobileno = createUserRequestModel.Mobileno
            };

            var createdUser = await _userRepository.AddAsync(user);

            var response = new UserCardResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                Password = createdUser.Password,
                Fullname = createdUser.Fullname,
                Mobileno = createdUser.Mobileno
            };

            return response;
        }

        public async Task<ICollection<TaskCardResponseModel>> GetTasks(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var tasks = user.Tasks;
            var response = new List<TaskCardResponseModel>();

            foreach (var task in tasks)
            {
                var card = new TaskCardResponseModel()
                {
                    Id = task.Id,
                    userid = task.userid,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Priority = task.Priority,
                    Remarks = task.Remarks
                };

                response.Add(card);
            }

            return response;
        }
    }
}
