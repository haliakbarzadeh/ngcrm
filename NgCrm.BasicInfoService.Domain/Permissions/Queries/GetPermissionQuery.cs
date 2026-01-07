using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;

namespace NgCrm.BasicInfoService.Domain.Permissions.Queries
{
    public class GetPermissionQuery : BaseQueryRequest, IRequest<IEnumerable<PermissionBriefDto>>
    {
        //public string Firsname { get; set; }
    }
}
