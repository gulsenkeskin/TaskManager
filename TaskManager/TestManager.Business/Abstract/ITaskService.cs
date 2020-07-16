using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;
using Task = TaskManager.Entities.Task;

namespace TaskManager.Business.Abstract
{
    public interface ITaskService
    {
        Task<List<Task>> GetAllTasks();
        Task<Task> GetTaskById(int id);
        Task<Task> GetTaskByType(TaskType type);
        Task<Task> GetTaskByTitle(string title);
        Task<Task> GetTaskByStartDate(DateTime startDate);
        Task<Task> GetTaskByEndDate(DateTime endDate);
        Task<Task> GetTaskByUserId(int userId);
        Task<Task> CreateTask(Task task);
        Task<Task> UpdateTask(Task task);
        System.Threading.Tasks.Task DeleteTask(int id);
    }
}
