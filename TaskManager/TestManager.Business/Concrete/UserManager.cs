using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities;
using TaskManager.Business.Abstract;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.Business.Concrete
{
    public class UserManager:IUserService
    {

        private IUserRepository _userRepository; 

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            if (id > 0)
            {
                return await _userRepository.GetUserById(id);
            }

            throw new Exception("id can not be less than 1");
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _userRepository.GetUserByName(name);
        }

        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}
