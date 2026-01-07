using Goldiran.Framework.Domain.Dtos;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.ADUsers.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Dtos;
using NgCrm.BasicInfoService.Domain.Users.Queries;

namespace NgCrm.BasicInfoService.Application.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IPersonAccessGroupQueryRepository _personAccessGroupQueryRepository;
        private readonly IADUserQueryRepository _aDUserQueryRepository;

        public GetUserByIdQueryHandler(IUserQueryRepository userQueryRepository,
            IPersonAccessGroupQueryRepository personAccessGroupQueryRepository,
            IADUserQueryRepository aDUserQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
            _personAccessGroupQueryRepository = personAccessGroupQueryRepository;
            _aDUserQueryRepository = aDUserQueryRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if(request.UserId == 0)            
                throw new KeyNotFoundException("شناسه کاربر را وارد کنید.");            

            var user = await _userQueryRepository.GetByIdAsync(request.UserId, cancellationToken, e => e.Person);

            if (user is null)
                throw new KeyNotFoundException("کاربر مورد نظر یافت نشد.");

            var personAccesses = await _personAccessGroupQueryRepository.GetByPersonIdAsync(user.PersonId, cancellationToken);

            var userDto = user.Adapt<UserDto>();
            userDto.personSummaryDto = user.Person.Adapt<PersonSummaryDto>();

            if (user.ADUserId is not null)   
                userDto.ADUser = (await _aDUserQueryRepository.GetByIdAsync((long)user.ADUserId, cancellationToken)).Adapt<SelectItemDto>();

            userDto.AccessGroups = personAccesses
                .Select(e => new SelectItemDto 
                {
                    Id = e.AccessGroupId,
                    Title = e.AccessGroup.Title,
                }).Distinct().ToArray();

            return userDto;
        }
    }
}
