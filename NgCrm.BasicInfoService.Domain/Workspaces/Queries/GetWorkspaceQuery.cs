using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Dtos;

namespace NgCrm.BasicInfoService.Domain.Workspaces.Queries
{
    public class GetWorkspaceQuery : BaseQueryRequest, IRequest<IEnumerable<WorkspaceBriefDto>>
    {
        //public string Firsname { get; set; }
    }
}
