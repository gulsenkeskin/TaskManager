using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Abstract;
using TaskManager.Entities;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService; 

        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

        


       /// <summary>
       /// Get All Users
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);//200+data
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")] //api/users/getuserbyid/2
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user); //200+data
            }

            return NotFound();//404
        }

        /// <summary>
        /// Get user by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")] 
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await _userService.GetUserByName(name);
            
            if (user != null)
            {
                return Ok(user); //200+data
            }

            return NotFound(); //404
        }


   /// <summary>
   /// Create an user
   /// </summary>
   /// <param name="user"></param>
   /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var createdUser = await _userService.CreateUser(user);
            return CreatedAtAction("Get", new { userId = createdUser.UserId }, createdUser); //201+ data
        }


      /// <summary>
      /// Update the user
      /// </summary>
      /// <param name="user"></param>
      /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (await _userService.GetUserById(user.UserId) != null) 
            {
                return Ok(await _userService.UpdateUser(user)); //200+data

            }

            return NotFound();
        }

     /// <summary>
     /// Delete the hotel
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _userService.GetUserById(id) != null) //gelen user'ın id'si veritabanında varsa
            {
                await _userService.DeleteUser(id);
                return Ok(); //200

            }

            return NotFound();
        }




    }
}
