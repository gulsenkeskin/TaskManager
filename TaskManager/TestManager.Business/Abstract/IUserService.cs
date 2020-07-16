using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager.Business.Abstract
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        System.Threading.Tasks.Task DeleteUser(int id);
    }
}
