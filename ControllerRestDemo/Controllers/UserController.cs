using ControllerRestDemo.DAL;
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

        // GET: api/<UserController>
        [HttpGet]
        public IResult Get()
        {
            var users = _userStorage.GetAllUsers();
            return users.Count > 0 ? Results.Ok(users): Results.NotFound();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
