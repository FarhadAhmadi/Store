using Application.Services.Users.Commands.AddUser;
using Application.Services.Users.Commands.ChangeUserStatus;
using Application.Services.Users.Commands.DeleteUser;
using Application.Services.Users.Commands.EditUser;
using Application.Services.Users.Commands.UserLogin;
using Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Facad
{
    public interface IUserFacad
    {
        IGetUserService GetUserService {  get; }
        IAddUserService AddUserService { get; }
        IDeleteUserService DeleteUserService { get; }
        IChangeUserStatusService changeUserStatusService { get; }
        IEditUserService editUserService { get; }
        IUserLoginService userLoginService { get; }
    }
}
