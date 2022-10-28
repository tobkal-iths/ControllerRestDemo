using ControllerRestDemo.DAL;
using ControllerRestDemo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllerRestDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;

    public UserController([FromServices] IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        var users = _unitOfWork.UserRepository.GetAllUsers();
        return users.Any() ? Ok(users) : NotFound();
    }

    // GET api/User/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = _unitOfWork.UserRepository.GetUser(id);

        return user is not null ? Ok(user) : NotFound();
    }

    [HttpGet("{id}/groups")]
    public async Task<IActionResult> GetUserGroups(int id)
    {
        var user = _unitOfWork.UserRepository.GetUserGroups(id);

        return user is not null ? Ok(user) : NotFound();
    }

    // POST api/User
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] User user)
    {
        return _unitOfWork.UserRepository.Create(user) ? Ok(): BadRequest();
    }

    // PUT api/User/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] User user)
    {
        _unitOfWork.UserRepository.UpdateUser(id, user);
        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, string value)
    {
        if (_unitOfWork.UserRepository.UpdateUserName(id, value))
        {
            return Ok(_unitOfWork.UserRepository.GetUser(id));
        }

        return NotFound();
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _unitOfWork.UserRepository.DeleteUser(id);
        return Ok();
    }
}