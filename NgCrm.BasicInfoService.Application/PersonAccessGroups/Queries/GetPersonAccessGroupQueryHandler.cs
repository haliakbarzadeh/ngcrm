using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Queries;

namespace NgCrm.BasicInfoService.Application.PersonAccessGroups.Queries
{
    public class GetPersonAccessGroupsQueryHandler : IRequestHandler<GetPersonAccessGroupQuery, IEnumerable<PersonAccessGroupBriefDto>>
    {
        private readonly IPersonAccessGroupQueryRepository _personAccessGroupQueryRepository;

        public GetPersonAccessGroupsQueryHandler(IPersonAccessGroupQueryRepository personAccessGroupQueryRepository)
        {
            _personAccessGroupQueryRepository = personAccessGroupQueryRepository;
        }

        public async Task<IEnumerable<PersonAccessGroupBriefDto>> Handle(GetPersonAccessGroupQuery request, CancellationToken cancellationToken)
        {
            var result = await _personAccessGroupQueryRepository.GetPersonAccessGroupBriefDtosAsync(cancellationToken);

            return result;
        }
    }
}
