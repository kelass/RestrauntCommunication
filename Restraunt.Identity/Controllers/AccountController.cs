using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restraunt.Core;
using Restraunt.Core.Dto;


namespace Restraunt.Identity.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
               var userIdGet = await _userManager.FindByIdAsync(model.Id.ToString());
                if (userIdGet == null)
                {
                    User user = new User { Id = model.Id, UserName = model.UserName, Email = model.Email };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        //Claim admin role at first registration 
                        var AdminClaim = _userManager.Users.Count() == 1 ?
                            await _userManager.AddToRoleAsync(user, "Admin") :
                            await _userManager.AddToRoleAsync(user, "User");



                        await _signInManager.SignInAsync(user, false);

                        return Redirect("https://localhost:45591/Home/Index");
                        

                    }
                }
            }
            
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

