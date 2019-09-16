using bimfabrik.model;
using bimfabrik.model.Authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace bimfabrik.Areas.Auth.Controllers
{
    [Area("Authentication")]
    public class AuthController : Controller
    {
        public IActionResult SignIn() => this.View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = "")
        {
            //var userFromStorage = TestUserStorage.UserList
            //    .FirstOrDefault(m => m.UserName == userFromFore.UserName && m.Password == userFromFore.Password);

            if (model != null)
            {
                //you can add all of ClaimTypes in this collection 
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, model.Username) 
                    //,new Claim(ClaimTypes.Email,"emailaccount@microsoft.com")  
                };

                //init the identity instances 
                var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "SuperSecureLogin"));

                //signin 
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            else
            {
                ViewBag.ErrMsg = "User name or password is invalid";

                return View();
            }
        }

        [Route("signout")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
