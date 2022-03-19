using ControllerRestDemo.DAL;
using ControllerRestDemo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllerRestDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UnitOfWork _unitOfWork;

        public UserController([FromServices] UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            var users = _unitOfWork.UserRepository.GetAllUsers();
            return users.Count > 0 ? Ok(users): NotFound();
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _unitOfWork.UserRepository.GetUser(id);

            return user is not null ? Ok(user) : NotFound();
        }
        [HttpGet("{id}/groups")]
        public IActionResult GetUserGroups(int id)
        {
            var user = _unitOfWork.UserRepository.GetUserGroups(id);

            return user is not null ? Ok(user) : NotFound();
        }

        // POST api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _unitOfWork.UserRepository.Create(user);
            _unitOfWork.Save();
            return Ok();
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            _unitOfWork.UserRepository.UpdateUser(id, user);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, string value)
        {
            if (_unitOfWork.UserRepository.UpdateUserName(id, value))
            {
                return Ok(_unitOfWork.UserRepository.GetUser(id));
            }

            return NotFound();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.UserRepository.DeleteUser(id);
            return Ok();
        }
    }
}
