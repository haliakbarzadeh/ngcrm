using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.Roles.Dtos;

namespace NgCrm.BasicInfoService.Domain.Roles.Queries
{
    public class GetRoleQuery : BaseQueryRequest, IRequest<Paged<RoleBriefDto>>
    {
        //public string Firsname { get; set; }
    }
}
