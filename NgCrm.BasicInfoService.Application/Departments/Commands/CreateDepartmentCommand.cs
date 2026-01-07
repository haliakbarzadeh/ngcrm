using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Departments.Contracts;
using NgCrm.BasicInfoService.Domain.Departments.Entities;

namespace NgCrm.BasicInfoService.Application.Departments.Commands
{
    public class CreateDepartmentCommand : BaseCommandRequest, IRequest<bool>
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
    {
        private readonly IDepartmentCommandRepository _departmentRepository;

        public CreateDepartmentCommandHandler(IDepartmentCommandRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department(
                request.Title,
                request.Name,
                request.ParentId,
                request.Description,
                request.IsActive);

            _departmentRepository.Add(department);
            var result = await _departmentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}