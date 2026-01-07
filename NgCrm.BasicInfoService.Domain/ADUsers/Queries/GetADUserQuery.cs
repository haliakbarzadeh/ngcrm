using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.ADUsers.Dtos;

namespace NgCrm.BasicInfoService.Domain.ADUsers.Queries
{
    public class GetADUserQuery : BaseQueryRequest, IRequest<Paged<ADUserBriefDto>>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
