using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.AccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.AccessGroups.Queries;
using NgCrm.BasicInfoService.Domain.AccessGroups.ReadModels;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos;

namespace NgCrm.BasicInfoService.Application.AccessGroups.Queries
{
    public class GetAccessGroupByIdQueryHandler : IRequestHandler<GetAccessGroupByIdQuery, AccessGroupDetailDto>
    {
        private readonly IAccessGroupQueryRepository _accessGroupQueryRepository;
        private readonly IPersonAccessGroupQueryRepository _personAccessGroupQueryRepository;

        public GetAccessGroupByIdQueryHandler(IAccessGroupQueryRepository accessGroupQueryRepository, 
            IPersonAccessGroupQueryRepository personAccessGroupQueryRepository)
        {
            _accessGroupQueryRepository = accessGroupQueryRepository;
            _personAccessGroupQueryRepository = personAccessGroupQueryRepository;
        }

        public async Task<AccessGroupDetailDto> Handle(GetAccessGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var accessGroup = await _accessGroupQueryRepository.GetByIdAsync(request.Id, cancellationToken);
            var personAccessGroups = await _personAccessGroupQueryRepository.GetByAccessGroupIdAsync(request.Id, cancellationToken);

            var result = accessGroup.Adapt<AccessGroupDetailDto>();
            //result.Persons = personAccessGroups.Adapt<IEnumerable<PersonAccessGroupDto>>();
            result.Persons = personAccessGroups.Select(e=>new SelectItemDto
            {
                Id = e.PersonId,
                Title = e.Person.FirstName + " " + e.Person.LastName
            });

            return result;
        }
    }
}
