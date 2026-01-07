using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;
using NgCrm.BasicInfoService.Domain.Organizations.Queries;

namespace NgCrm.BasicInfoService.Application.Organizations.Queries
{
    public class GetOrganizationByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, OrganizationDto>
    {
        private readonly IOrganizationQueryRepository _organizationQueryRepository;

        public GetOrganizationByIdQueryHandler(IOrganizationQueryRepository organizationQueryRepository)
        {
            _organizationQueryRepository = organizationQueryRepository;
        }

        public async Task<OrganizationDto> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _organizationQueryRepository.GetByIdAsync(request.Id, cancellationToken, e => e.Positions);
            
            if (organization is null)
                throw new KeyNotFoundException("ساختار سازمانی یافت نشد.");

            return organization.Adapt<OrganizationDto>();
        }
    }
}
