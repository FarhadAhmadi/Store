using Application.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Queries.GetUsers
{
    public interface IGetUserService
    {
        ResultDto<List<UsersDto>> Execute();
    }
}