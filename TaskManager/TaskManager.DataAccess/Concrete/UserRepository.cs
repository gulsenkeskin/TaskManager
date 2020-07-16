using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities;
using Task = TaskManager.Entities.Task;

namespace TaskManager.DataAccess.Concrete
{ 
    public class UserRepository:IUserRepository
    {
       

        public async Task<List<User>> GetAllUsers()
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Users.ToListAsync();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Users.FindAsync(id);
            }
        }

        public async Task<User> GetUserByName(string name)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Users.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public async Task<User> CreateUser(User user)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                taskManagerDbContext.Users.Add(user);
                await taskManagerDbContext.SaveChangesAsync();
                return user;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                taskManagerDbContext.Users.Update(user);
                await taskManagerDbContext.SaveChangesAsync();
                return user;
            }
        }

        public async System.Threading.Tasks.Task DeleteUser(int id)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                var deletedUser = await GetUserById(id);
                taskManagerDbContext.Users.Remove(deletedUser);
                await taskManagerDbContext.SaveChangesAsync();
            }
        }



      

    }
}
