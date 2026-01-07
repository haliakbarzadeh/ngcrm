using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.ADUsers.Contracts;
using NgCrm.BasicInfoService.Domain.ADUsers.Entities;

namespace NgCrm.BasicInfoService.Application.ADUsers.Commands
{
    public class CreateOrUpdateADUserCommand : BaseCommandRequest, IRequest<bool>
    {
        public string UserName { get; set; }
        public Guid? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Groups { get; set; }
        public string TelephoneNumber { get; set; }
        public string UserPrincipalName { get; set; }
        public bool IsCsUser { get; set; }

    }

    public class CreateOrUpdateADUserCommandHandler : IRequestHandler<CreateOrUpdateADUserCommand, bool>
    {
        private readonly IADUserCommandRepository _adUserCommandRepository;

        public CreateOrUpdateADUserCommandHandler(IADUserCommandRepository adUserCommandRepository)
        {
            _adUserCommandRepository = adUserCommandRepository;
        }

        public async Task<bool> Handle(CreateOrUpdateADUserCommand request, CancellationToken cancellationToken)
        {
            var existADUser = await _adUserCommandRepository.GetByAsync(x => x.UserId == request.UserId);

            if (existADUser == null)
            {
                var entity = new ADUser(request.UserId, request.UserName, request.FirstName, request.LastName, request.DisplayName, request.Email, request.IsActive, request.Position, request.Groups, request.Department, request.TelephoneNumber, request.UserPrincipalName);

                _adUserCommandRepository.Add(entity);
            }
            else
            {
                existADUser.Update(request.UserName, request.FirstName, request.LastName, request.DisplayName, request.Email, request.IsActive, request.Position, request.Groups, request.Department, request.TelephoneNumber, request.UserPrincipalName);

                _adUserCommandRepository.Update(existADUser);
            }

            var result = await _adUserCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
