using bimfabrik.model.Authentication.Models;
using bimfabrik.model.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace bimfabrik.Areas.Auth.Controllers
{
    [Area("Authentication")]
    public class AuthController : Controller
    {
        // _httpClient isn't exposed publicly
        private readonly HttpClient _httpClient;

        public AuthController(IHttpClientFactory client)
        {
            _httpClient = client.CreateClient();
        }

        public IActionResult SignIn() => this.View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = "")
        {
            //var userFromStorage = TestUserStorage.UserList
            //    .FirstOrDefault(m => m.UserName == userFromFore.UserName && m.Password == userFromFore.Password);
            var userDto = new UserDto();
            userDto.Username = model.Username;
            userDto.Password = model.Password;
            var content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44316/api/Users/authenticate", content);

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

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
