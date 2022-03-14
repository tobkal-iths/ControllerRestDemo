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

        private readonly UserStorage _userStorage;

        public UserController([FromServices] UserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        // GET: api/User
        [HttpGet]
        public IResult Get()
        {
            var users = _userStorage.GetAllUsers();
            return users.Count > 0 ? Results.Ok(users): Results.NotFound();
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var user = _userStorage.GetUser(id);

            return user is not null ? Results.Ok(user) : Results.NotFound();
        }

        // POST api/User
        [HttpPost]
        public IResult Post([FromBody] User user)
        {
            _userStorage.Create(user);
            return Results.Ok("TJOHOO");
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public IResult Put(int id, [FromBody] User user)
        {
            _userStorage.UpdateUser(id, user);
            return Results.Ok();
        }

        [HttpPatch("{id}")]
        public IResult Patch(int id, string value)
        {
            if (_userStorage.UpdateUserName(id, value))
            {
                return Results.Ok(_userStorage.GetUser(id));
            }

            return Results.NotFound();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            _userStorage.DeleteUser(id);
            return Results.Ok();
        }
    }
}
