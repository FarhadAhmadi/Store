using Application.Common.DTO;
using Application.Common.Interfaces;

namespace Application.Services.Roles.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IStoreDbContext _context;
        public GetRolesService(IStoreDbContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetRolesDto>> Execute()
        {
            var result = _context.Roles.Select(e => new GetRolesDto
            {
                Id = e.Id,
                RoleName = e.RoleName,
            }).ToList();

            return new ResultDto<List<GetRolesDto>>
            {
                Result = result,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
