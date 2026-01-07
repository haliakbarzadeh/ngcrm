using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Users.Dtos;

namespace NgCrm.BasicInfoService.Domain.Users.Queries
{
    public class GetUserByIdQuery : BaseQueryRequest, IRequest<UserDto>
    {
        public long UserId { get; set; }
    }
}
