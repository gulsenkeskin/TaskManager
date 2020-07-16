using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Abstract;
using TaskManager.Entities;
using Task = TaskManager.Entities.Task;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }


    
        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var task = await _taskService.GetAllTasks();
            return Ok(task);//200+data
        }

        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")] 
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task != null)
            {
                return Ok(task); //200+data
            }

            return NotFound();//404
        }

       /// <summary>
       /// Get task by type : 1=daily, 2= weekly, 3=monthly
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
        [HttpGet]
        [Route("[action]/{type}")]
        public async Task<IActionResult> GetTaskByType(TaskType type)
        {
            var task = await _taskService.GetTaskByType(type);

            if (task != null)
            {
                return Ok(task); //200+data
            }

            return NotFound(); //404
        }



       /// <summary>
       /// Get task by title
       /// </summary>
       /// <param name="title"></param>
       /// <returns></returns>
        [HttpGet]
        [Route("[action]/{title}")]
        public async Task<IActionResult> GetTaskByTitle(string title)
        {
            var task = await _taskService.GetTaskByTitle(title);

            if (task != null)
            {
                return Ok(task); //200+data
            }

            return NotFound(); //404
        }

        /// <summary>
        /// Get task by start date (example: 2020-07-16)
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        [HttpGet]
       [Route("[action]/{startDate}")]
       public async Task<IActionResult> GetTaskByStartDate(DateTime startDate)
        {
           var task = await _taskService.GetTaskByStartDate(startDate);

           if (task != null)
           {
               return Ok(task); //200+data
           }

           return NotFound(); //404
       }


        /// <summary>
        /// Get task by end date (example: 2020-07-16)
        /// </summary>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{endDate}")]
        public async Task<IActionResult> GetTaskByEndDate(DateTime endDate)
        {
            var task = await _taskService.GetTaskByEndDate(endDate);

            if (task != null)
            {
                return Ok(task); //200+data
            }

            return NotFound(); //404
        }

        /// <summary>
        /// Get task by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetTaskByUserId(int userId)
        {
            var task = await _taskService.GetTaskByUserId(userId);

            if (task != null)
            {
                return Ok(task); //200+data
            }

            return NotFound(); //404
        }


        /// <summary>
        /// Create an task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateTask([FromBody] Task task)
        {
            var createdTask = await _taskService.CreateTask(task);
            return CreatedAtAction("Get", new { taskId = createdTask.TaskId }, createdTask); //201+ data
        }


      /// <summary>
      /// Update the task
      /// </summary>
      /// <param name="task"></param>
      /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTask([FromBody] Task task)
        {
            if (await _taskService.GetTaskById(task.TaskId) != null)
            {
                return Ok(await _taskService.UpdateTask(task)); //200+data

            }

            return NotFound();
        }

      /// <summary>
      /// Delete the task
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (await _taskService.GetTaskById(id) != null) 
            {
                await _taskService.DeleteTask(id);
                return Ok(); //200

            }

            return NotFound();
        }




    }
}
