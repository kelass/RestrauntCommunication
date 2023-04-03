using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restraunt.Core;
using Restraunt.Data;
using Restraunt.Data.Interfaces;

namespace Restraunt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public UserController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _unitOfWork.Users.Select());
        }


    }
}
