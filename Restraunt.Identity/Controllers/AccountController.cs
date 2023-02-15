using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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


        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterDto { ReturnUrl = returnUrl});
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

                        return Redirect(model.ReturnUrl);
                        

                    }
                }
            }
            
            return View(model);
        }


        public IActionResult Login(string returnUrl)
        {
            return View(new LoginDto { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                    if (result.Succeeded)
                    {
                       _userManager.AddClaimAsync(user, new Claim("rc.user", "big.cookie"))
                        .GetAwaiter().GetResult();

                    _userManager.AddClaimAsync(user,
                        new Claim("rc.api", "big.api.cookie"))
                        .GetAwaiter().GetResult();

                    return Redirect(model.ReturnUrl);
                    }

                }
                else
                {
                    return View(model);
                }
            
            return View();
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

