using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities;
using TaskManager.Business.Abstract;

namespace TaskManager.Business.Concrete
{
    public class TaskManager:ITaskService
    {
        private ITaskRepository _taskRepository; //EKLEE

        public TaskManager(ITaskRepository taskRepository) //EKLEE
        {
            _taskRepository = taskRepository;

        }
        public async System.Threading.Tasks.Task<List<Task>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();
        }

        public async System.Threading.Tasks.Task<Task> GetTaskById(int id)
        {
            if (id > 0)
            {
                return await _taskRepository.GetTaskById(id);
            }

            throw new Exception("id can not be less than 1");
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByType(TaskType type)
        {
            return await _taskRepository.GetTaskByType(type);
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByTitle(string title)
        {
            return await _taskRepository.GetTaskByTitle(title);
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByStartDate(DateTime startDate)
        {
            return await _taskRepository.GetTaskByStartDate(startDate);
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByEndDate(DateTime endDate)
        {
            return await _taskRepository.GetTaskByEndDate(endDate);
        }

        public async System.Threading.Tasks.Task<Task> GetTaskByUserId(int userId)
        {
            return await _taskRepository.GetTaskByUserId(userId);
        }

        public async System.Threading.Tasks.Task<Task> CreateTask(Task task)
        {
            return await _taskRepository.CreateTask(task);
        }

        public async System.Threading.Tasks.Task<Task> UpdateTask(Task task)
        {
            return await _taskRepository.UpdateTask(task);
        }

        public async System.Threading.Tasks.Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
        }
    }
}
