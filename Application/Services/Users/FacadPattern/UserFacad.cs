using Application.Common.Interfaces;
using Application.Common.Interfaces.Facad;
using Application.Services.Users.Commands.AddUser;
using Application.Services.Users.Commands.ChangeUserStatus;
using Application.Services.Users.Commands.DeleteUser;
using Application.Services.Users.Commands.EditUser;
using Application.Services.Users.Commands.UserLogin;
using Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.FacadPattern
{
    public class UserFacad : IUserFacad
    {
        private readonly IStoreDbContext _context;
        private readonly IHostingEnvironment _environment;

        public UserFacad(IStoreDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IDeleteUserService _deleteUserService;
        public IDeleteUserService DeleteUserService
        {
            get { return _deleteUserService = _deleteUserService ?? new DeleteUserService(_context); }
        }

        private IChangeUserStatusService _changeUserStatusService;
        public IChangeUserStatusService changeUserStatusService
        {
            get { return _changeUserStatusService = _changeUserStatusService ?? new ChangeUserStatusService(_context); }
        }

        private IEditUserService _editUserService;
        public IEditUserService editUserService
        {
            get
            {
                return _editUserService = _editUserService ?? new EditUserService(_context);
            }
        }

        private IGetUserService _getUserService;
        public IGetUserService GetUserService
        {
            get
            {
                return _getUserService = _getUserService ?? new GetUserService(_context);
            }
        }
        private IAddUserService _addUserService;
        public IAddUserService AddUserService
        {
            get
            {
                return _addUserService = _addUserService ?? new AddUserService(_context);
            }
        }

        private IUserLoginService _userLoginService;
        public IUserLoginService userLoginService
        {
            get
            {
                return _userLoginService =_userLoginService ?? new UserLoginService(_context);
            }
        }
    }
}