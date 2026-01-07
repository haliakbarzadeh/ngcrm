using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Departments.Dtos;

namespace NgCrm.BasicInfoService.Domain.Departments.Queries
{
    public class GetDepartmentByIdQuery : BaseQueryRequest, IRequest<DepartmentDto>
    {
        public long Id { get; set; }
    }
}