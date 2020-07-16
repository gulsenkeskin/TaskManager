using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities;

namespace TaskManager.DataAccess.Concrete
{
    public class TaskRepository:ITaskRepository
    {
        public async System.Threading.Tasks.Task<List<Task>> GetAllTasks()
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Tasks.ToListAsync();
            }
        }

        public async System.Threading.Tasks.Task<Task> GetTaskById(int id)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Tasks.FindAsync(id);
            }
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByType(TaskType type)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Tasks.FindAsync(type);
            }
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByTitle(string title)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Tasks.FirstOrDefaultAsync(x => x.Title.ToLower() == title.ToLower());
            }
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByStartDate(DateTime startDate)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Tasks.FirstOrDefaultAsync(x => x.StartDate == startDate);
            }
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByEndDate(DateTime endDate)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Tasks.FirstOrDefaultAsync(x => x.EndDate == endDate);
            }
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByUserId(int userId)
        {
            //using (var taskManagerDbContext = new TaskManagerDbContext())
            //{
            //    return await taskManagerDbContext.Tasks.FindAsync(userId);
            //}

            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                return await taskManagerDbContext.Tasks.FirstOrDefaultAsync(x => x.UserId== userId);
            }


        }

        public async System.Threading.Tasks.Task<Task> CreateTask(Task task)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                taskManagerDbContext.Tasks.Add(task);
                await taskManagerDbContext.SaveChangesAsync();
                return task;
            }
        }

        public async System.Threading.Tasks.Task<Task> UpdateTask(Task task)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                taskManagerDbContext.Tasks.Update(task);
                await taskManagerDbContext.SaveChangesAsync();
                return task;
            }
        }

        public async System.Threading.Tasks.Task DeleteTask(int id)
        {
            using (var taskManagerDbContext = new TaskManagerDbContext())
            {
                var deletedTask = await GetTaskById(id);
                taskManagerDbContext.Tasks.Remove(deletedTask);
                await taskManagerDbContext.SaveChangesAsync();
            }
        }



    }
}
