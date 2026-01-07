using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.Departments.Dtos;

namespace NgCrm.BasicInfoService.Domain.Departments.Queries
{
    public class GetDepartmentQuery : BaseQueryRequest, IRequest<Paged<DepartmentBriefDto>>
    {
    }
}