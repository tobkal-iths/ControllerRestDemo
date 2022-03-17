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
        public IResult Get()
        {
            var users = _unitOfWork.UserRepository.GetAllUsers();
            return users.Count > 0 ? Results.Ok(users): Results.NotFound();
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var user = _unitOfWork.UserRepository.GetUser(id);

            return user is not null ? Results.Ok(user) : Results.NotFound();
        }

        // POST api/User
        [HttpPost]
        public IResult Post([FromBody] User user)
        {
            _unitOfWork.UserRepository.Create(user);
            _unitOfWork.Save();
            return Results.Ok("TJOHOO");
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] User user)
        {
            _unitOfWork.UserRepository.UpdateUser(id, user);
            return Results.Ok();
        }

        [HttpPatch("{id}")]
        public IResult Patch(int id, string value)
        {
            if (_unitOfWork.UserRepository.UpdateUserName(id, value))
            {
                return Results.Ok(_unitOfWork.UserRepository.GetUser(id));
            }

            return Results.NotFound();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            _unitOfWork.UserRepository.DeleteUser(id);
            return Results.Ok();
        }
    }
}
