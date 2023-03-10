 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using Restraunt.Core;
using Restraunt.Core.Dto;


namespace Restraunt.Identity.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly IWebHostEnvironment _environment;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IIdentityServerInteractionService interactionService, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interactionService = interactionService;
            _environment = environment;
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



        public IActionResult Login(string? returnUrl)
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
                    _userManager.AddClaimAsync(user, new Claim("roles", "big.roles.cookie"))
                        .GetAwaiter().GetResult();
                    _userManager.AddClaimAsync(user,
                        new Claim("rc.api", "big.api.cookie"))
                        .GetAwaiter().GetResult();
                    return Redirect(model.ReturnUrl);  
                }
                
                else
                {
                    ModelState.AddModelError("", "Invalid login or password");
                }

                
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut(string logoutId)
        {
            await _signInManager.SignOutAsync();

            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);

            if (string.IsNullOrEmpty(logoutRequest.PostLogoutRedirectUri))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(logoutRequest.PostLogoutRedirectUri);
            
        }

       


        public IActionResult SignInGoogle()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        public async Task<IActionResult> GoogleResponse(string returnUrl)
        {
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));


            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (!result.Succeeded)
            {
                User user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value,
                };
                IdentityResult identResult = await _userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await _userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        var roles = new List<string>() { "User" };
                        if (!_environment.IsProduction())
                        {
                            roles.Add("Admin");
                        }
                        await _userManager.AddToRolesAsync(user, roles);
                        await _signInManager.SignInAsync(user, false);
                    }
                }
            }
            
            return Redirect("https://localhost:45591");
        }
    }
}

