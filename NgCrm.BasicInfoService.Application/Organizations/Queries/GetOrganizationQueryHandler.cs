using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;
using NgCrm.BasicInfoService.Domain.Organizations.Queries;

namespace NgCrm.BasicInfoService.Application.Organizations.Queries
{
    public class GetOrganizationQueryHandler : IRequestHandler<GetOrganizationQuery, IEnumerable<OrganizationBriefDto>>
    {
        private readonly IOrganizationQueryRepository _organizationQueryRepository;

        public GetOrganizationQueryHandler(IOrganizationQueryRepository organizationQueryRepository)
        {
            _organizationQueryRepository = organizationQueryRepository;
        }

        public async Task<IEnumerable<OrganizationBriefDto>> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationQueryRepository.GetAllAsync(cancellationToken, e => e.Positions);

            return organizations.Adapt<IEnumerable<OrganizationBriefDto>>().ToList();
        }
    }
}
