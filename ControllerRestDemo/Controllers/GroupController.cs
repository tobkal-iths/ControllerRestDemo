using ControllerRestDemo.DAL;
using ControllerRestDemo.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerRestDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public GroupController([FromServices] UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            return Ok(_unitOfWork.GroupRepository.GetAllGroups());
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupUsers(int id)
        {
            return Ok(_unitOfWork.GroupRepository.GetGroupUsers(id));
        }

        [HttpPost]
        public IActionResult SaveGroup([FromBody] Group group)
        {
            _unitOfWork.GroupRepository.Create(group);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AddUserToGroup(int id, int userId)
        {
            _unitOfWork.GroupRepository.AddUserToGroup(id, userId);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
