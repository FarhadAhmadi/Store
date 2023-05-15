using Application.Common.DTO;
using Application.Common.Interfaces.Facad;
using Application.Services.Roles.Queries.GetRoles;
using Application.Services.Users.Commands.AddUser;
using Application.Services.Users.Commands.DeleteUser;
using Application.Services.Users.Commands.EditUser;
using Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Areas.Admin.Models;

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
        public IActionResult Index(string searchKey)
        {
            return View(_userFacad.GetUserService.Execute(searchKey));
        }
        [HttpGet]
        public IActionResult AddUser()
        {

            ViewBag.Items = new SelectList( _getRolesService.Execute().Result, "Id", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(AddUserViewModel addUserViewModel)
        {

            List<ProductFeature> productFeatures = new List<ProductFeature>();
            productFeatures.Add(new ProductFeature { Name = "Size", Value = "2x" });
            productFeatures.Add(new ProductFeature { Name = "Price", Value = "2000" });

            var result = _userFacad.AddUserService.Execute(new RequestAddUserDto
            {
                FullName = addUserViewModel.UserName,
                Email = addUserViewModel.Email,
                Role = new List<RoleInAddUser>
                {
                    new RoleInAddUser
                    {
                        RoleId  = addUserViewModel.RoleId,
                    }
                },
                BirthdayDate = DateTime.Now,
                Password = addUserViewModel.Password,
                PhoneNumber = addUserViewModel.PhoneNumber,
                RePassword = addUserViewModel.RePassword
            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult Delete(int userId)
        {
            return Json(_userFacad.DeleteUserService.Execute(userId));
        }

        [HttpPost]
        public IActionResult ChangeStatus(int userId)
        {
            return Json(_userFacad.changeUserStatusService.Execute(userId));
        }

        public IActionResult Edit(editUserViewModel editUserViewModel)
        {
            var result = _userFacad.editUserService.Execute(new EditUserDto
            {
                Id = editUserViewModel.Id,
                Password = editUserViewModel.Password,
                PhoneNumber = editUserViewModel.PhoneNumber,
                UserName = editUserViewModel.UserName,
            });

            return Json(result);
        }
    }

    public class ProductFeature
    {
        public string Name { get; set;}
        public string Value { get; set;}
    }
}