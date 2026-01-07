using Mapster;
using MediatR;
using Newtonsoft.Json;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Dtos;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Queries;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;
using System.Collections.Generic;

namespace NgCrm.BasicInfoService.Application.OrganizationHistories.Queries
{
    public class GetOrganizationHistoryByDateQueryHandler : IRequestHandler<GetOrganizationHistoryByDateQuery, OrganizationHistoryDto>
    {
        private readonly IOrganizationHistoryQueryRepository _organizationHistoryQueryRepository;
        private readonly IOrganizationQueryRepository _organizationQueryRepository;

        public GetOrganizationHistoryByDateQueryHandler(IOrganizationHistoryQueryRepository organizationHistoryQueryRepository,
            IOrganizationQueryRepository organizationQueryRepository)
        {
            _organizationHistoryQueryRepository = organizationHistoryQueryRepository;
            _organizationQueryRepository = organizationQueryRepository;
        }

        public async Task<OrganizationHistoryDto?> Handle(GetOrganizationHistoryByDateQuery request, CancellationToken cancellationToken)
        {
            //var hasValue = await _organizationHistoryQueryRepository.AnyAsync(e => e.FromDate > request.FromDate, cancellationToken);
            var organizationHistory = await _organizationHistoryQueryRepository.GetByDateAsync(request.FromDate, cancellationToken);

            if (organizationHistory is null)
            {
                var organizations = await _organizationQueryRepository.GetAllAsync(cancellationToken, e => e.Positions);
                var result = organizations.Adapt<IList<OrganizationBriefDto>>().ToList();
                return new OrganizationHistoryDto { IsCurrent = true, OrganizationDtos = result };
            }
            else
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<OrganizationBriefDto>>(organizationHistory.Snapshot)?.ToList();
                return new OrganizationHistoryDto { IsCurrent = false, OrganizationDtos = result };
            }
        }
    }
}
