using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Restraunt.Core;
using Restraunt.Core.Dto;

namespace Restraunt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
       

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
            
        }

        [HttpPost]

        public async Task<ActionResult<User>> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest(ModelState);

            }

            var user = new User { Id = model.Id, UserName = model.UserName, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var adminClaim = _userManager.Users.Count() == 1 ?
                   await _userManager.AddToRoleAsync(user, "Admin") :
                   await _userManager.AddToRoleAsync(user, "User");

            return Created("",user);

        }
    }
}

