using Application.Common.DTO;
using Application.Common.Interfaces.Facad;
using Application.Services.Roles.Queries.GetRoles;
using Application.Services.Users.Commands.AddUser;
using Application.Services.Users.Commands.DeleteUser;
using Application.Services.Users.Commands.EditUser;
using Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class UserController : Controller
    {
        private readonly IGetRolesService _getRolesService;
        private readonly IUserFacad _userFacad;

        public UserController(IGetRolesService getRolesService,
            IUserFacad userFacad)
        {
            _getRolesService = getRolesService;
            _userFacad = userFacad;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_userFacad.GetUserService.Execute());
        }
        [HttpGet]
        public IActionResult AddUser()
        {

            ViewBag.Items = new SelectList(_getRolesService.Execute().Result, "Id", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(string UserName, string Email, int RoleId, string Phone, string Password, string RePassword)
        {
            var result = _userFacad.AddUserService.Execute(new RequestAddUserDto
            {
                FullName = UserName,
                Email = Email,
                Role = new List<RoleInAddUser>
                {
                    new RoleInAddUser
                    {
                        RoleId  = RoleId,
                    }
                },
                BirthdayDate = DateTime.Now,
                Password = Password,
                PhoneNumber = Phone,
                RePassword = RePassword

            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult delete(int userId)
        {
            return Json(_userFacad.DeleteUserService.Execute(userId));
        }

        [HttpPost]
        public IActionResult ChangeStatus(int userId)
        {
            return Json(_userFacad.changeUserStatusService.Execute(userId));
        }

        public IActionResult Edit(EditUserDto editUserDto)
        {
            var result = _userFacad.editUserService.Execute(new EditUserDto
            {
                Id = editUserDto.Id,
                Password = editUserDto.Password,
                PhoneNumber = editUserDto.PhoneNumber,
                UserName = editUserDto.UserName,
            });

            return Json(result);
        }
    }
}