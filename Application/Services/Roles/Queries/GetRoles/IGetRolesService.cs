using Application.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Roles.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<GetRolesDto>> Execute();
    }
}