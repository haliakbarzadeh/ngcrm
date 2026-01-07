using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Departments.Contracts;
using NgCrm.BasicInfoService.Domain.Departments.Dtos;
using NgCrm.BasicInfoService.Domain.Departments.Queries;

namespace NgCrm.BasicInfoService.Application.Departments.Queries
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;

        public GetDepartmentByIdQueryHandler(IDepartmentQueryRepository departmentQueryRepository)
        {
            _departmentQueryRepository = departmentQueryRepository;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentQueryRepository.GetByIdAsync(request.Id, cancellationToken);
            return department.Adapt<DepartmentDto>();
        }
    }
}