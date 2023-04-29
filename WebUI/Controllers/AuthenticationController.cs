using Application.Common.Interfaces.Facad;
using Application.Services.Users.Commands.AddUser;
using Azure.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.Services.Users.Commands.UserLogin;

namespace WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserFacad _userFacad;
        public AuthenticationController(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUp(string fullname, string email, string phonenumber, string password, string repassword)
        {

            var signeupResult = _userFacad.AddUserService.Execute(new RequestAddUserDto
            {
                BirthdayDate = DateTime.Now,
                FullName = fullname,
                Email = email,
                PhoneNumber = phonenumber,
                Role = new List<RoleInAddUser> { new RoleInAddUser { RoleId = 3 } },
                Password = password,
                RePassword = repassword

            });



            if (signeupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                new Claim(ClaimTypes.NameIdentifier,signeupResult.Result.UserId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, fullname),
                new Claim(ClaimTypes.Role, "Customer"),
            };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signeupResult);
        }
        [HttpGet]
        public IActionResult SignIn(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(string email, string password, string url = "/")
        {
            var signupResult = _userFacad.userLoginService.Execute(new RequestUserloginDto
            {
                email = email,
                password = password
            });

            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signupResult.Result.UserId.ToString()),
                    new Claim(ClaimTypes.Email,email),
                    new Claim(ClaimTypes.Name, signupResult.Result.Name),

                };
                foreach (var item in signupResult.Result.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);

                return Json(signupResult);
            }
            else
            {
                return Json(signupResult);
            }
        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

    }
}
