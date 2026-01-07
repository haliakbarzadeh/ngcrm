using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Departments.Contracts;

namespace NgCrm.BasicInfoService.Application.Departments.Commands
{
    public class UpdateDepartmentCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, bool>
    {
        private readonly IDepartmentCommandRepository _departmentRepository;

        public UpdateDepartmentCommandHandler(IDepartmentCommandRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);

            department.Update(
                request.Title,
                request.Name,
                request.ParentId,
                request.Description,
                request.IsActive);

            _departmentRepository.Update(department);
            var result = await _departmentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}