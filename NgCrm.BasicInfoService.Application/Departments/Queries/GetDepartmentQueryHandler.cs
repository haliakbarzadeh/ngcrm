using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Departments.Contracts;
using NgCrm.BasicInfoService.Domain.Departments.Dtos;
using NgCrm.BasicInfoService.Domain.Departments.Queries;

namespace NgCrm.BasicInfoService.Application.Departments.Queries
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, Paged<DepartmentBriefDto>>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;

        public GetDepartmentQueryHandler(IDepartmentQueryRepository departmentQueryRepository)
        {
            _departmentQueryRepository = departmentQueryRepository;
        }

        public async Task<Paged<DepartmentBriefDto>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var list = await _departmentQueryRepository.GetAllPagedAsync(request.FilterInfo, cancellationToken);
            return list.Adapt<Paged<DepartmentBriefDto>>();
        }
    }
}