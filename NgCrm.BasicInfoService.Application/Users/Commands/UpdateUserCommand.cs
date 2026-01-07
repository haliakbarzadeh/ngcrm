using Goldiran.Framework.Application.Commands;
using Goldiran.Framework.Domain.Exceptions;
using MediatR;
using NgCrm.BasicInfoService.Domain.ADUsers.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Application.Users.Commands
{
    public class UpdateUserCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public long? ADUserId { get; set; }
        public long PersonId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountTypes AccountTypeId { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public IEnumerable<long> AccessGroupIds { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IPersonQueryRepository _personQueryRepository;
        private readonly IADUserQueryRepository _adUserQueryRepository;
        private readonly IPersonAccessGroupCommandRepository _personAccessGroupCommandRepository;

        public UpdateUserCommandHandler(
            IUserCommandRepository userCommandRepository,
            IUserQueryRepository userQueryRepository,
            IPersonQueryRepository personQueryRepository,
            IADUserQueryRepository adUserQueryRepository,
            IPersonAccessGroupCommandRepository personAccessGroupCommandRepository)
        {
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
            _personQueryRepository = personQueryRepository;
            _adUserQueryRepository = adUserQueryRepository;
            _personAccessGroupCommandRepository = personAccessGroupCommandRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var errors = await CheckBusinessRules(request, cancellationToken);

            if (errors.Any())           
                throw new ValidationException(string.Join(" | ", errors));

            var currentUser = await _userCommandRepository.GetByIdAsync(request.Id);
           
            if (request.ADUserId is not null)
            {
                var adUser = await _adUserQueryRepository.GetByIdAsync((long)request.ADUserId, cancellationToken);
                currentUser.Update(request.PersonId, request.Username, request.Description, request.Password, request.AccountTypeId, adUser.UserName, adUser.Id, adUser.IsActive);
            }
            else
            {
                currentUser.Update(request.PersonId, request.Username, request.Description, request.Password, request.AccountTypeId, null, null, null);
            }

            _userCommandRepository.Update(currentUser);

            var personAccessGroups = await _personAccessGroupCommandRepository.GetByPersonIdAsync(request.PersonId, cancellationToken);

            var toRemove = personAccessGroups
                .Where(p => !request.AccessGroupIds.Contains(p.AccessGroupId))
                .ToList();

            foreach (var item in toRemove)            
                item.Archive();

            _personAccessGroupCommandRepository.UpdateRange(toRemove);

            var toAdd = request.AccessGroupIds
                .Distinct()
                .Where(id => !personAccessGroups.Any(q => q.AccessGroupId == id))
                .Select(id => new PersonAccessGroup(request.PersonId, id)).ToList();

            _personAccessGroupCommandRepository.AddRange(toAdd);

            var result = await _userCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        private async Task<List<string>> CheckBusinessRules(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var errors = new List<string>();

            var currentUser = await _userQueryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (currentUser is null) 
            {
                errors.Add("شناسه وارد شده اشتباه است.");
                return errors;
            }

            var personExists = await _personQueryRepository.AnyAsync(u => u.Id == request.PersonId, cancellationToken);
            if (!personExists)
                errors.Add("شناسه شخص وارد شده معتبر نیست.");

            var user = await _userQueryRepository.GetByExpressionAsync(u =>u.Id != request.Id && u.PersonId == request.PersonId, cancellationToken);
            if (user is not null)
                errors.Add(user.ADUserId == request.ADUserId ? "کاربر قبلا اضافه شده است." : "کاربر قبلا برای شخص دیگری اضافه شده است.");

            if (request.AccountTypeId == AccountTypes.Local)
            {
                var usernameExists = await _userQueryRepository.AnyAsync(u => u.Id != request.Id && u.Username == request.Username, cancellationToken);
                if (usernameExists)
                    errors.Add("نام کاربری تکراری است.");

                if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 8)
                    errors.Add("رمز عبور باید حداقل 8 کاراکتر باشد.");
            }

            if (request.AccountTypeId == AccountTypes.ActiveDirectory)
            {
                var userbyADUserId = await _userQueryRepository.GetByExpressionAsync(u => u.Id != request.Id && u.ADUserId == request.ADUserId, cancellationToken);
                if (userbyADUserId is not null)
                    errors.Add(userbyADUserId.PersonId == request.PersonId ? "شخص قبلا اضافه شده است." : "شخص قبلا برای کاربر دیگری اضافه شده است.");


                var adUserExists = await _adUserQueryRepository.AnyAsync(u => u.Id == request.ADUserId, cancellationToken);
                if (!adUserExists)
                    errors.Add("کاربر وارد شده معتبر نیست.");
            }

            return errors;
        }
    }
}
