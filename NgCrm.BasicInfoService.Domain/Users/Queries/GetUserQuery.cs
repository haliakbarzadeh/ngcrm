using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.Users.Dtos;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Domain.Users.Queries
{
    public class GetUserQuery : BaseQueryRequest, IRequest<Paged<UserBriefDto>>
    {
        public string SearchTerm { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsADActive { get; set; }
        public AccountTypes? AccountTypeId { get; set; }
    }
}
