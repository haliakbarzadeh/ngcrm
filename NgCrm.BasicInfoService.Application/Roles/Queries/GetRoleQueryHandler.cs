using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Roles.Contracts;
using NgCrm.BasicInfoService.Domain.Roles.Dtos;
using NgCrm.BasicInfoService.Domain.Roles.Queries;
using NgCrm.BasicInfoService.Domain.Roles.ReadModels;

namespace NgCrm.BasicInfoService.Application.Roles.Queries
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Paged<RoleBriefDto>>
    {
        private readonly IRoleQueryRepository _roleQueryRepository;

        public GetRoleQueryHandler(IRoleQueryRepository roleQueryRepository)
        {
            _roleQueryRepository = roleQueryRepository;
        }

        public async Task<Paged<RoleBriefDto>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleQueryRepository.GetAllPagedAsync(request.FilterInfo, cancellationToken);
            return roles.Adapt<Paged<RoleBriefDto>>();
        }
    }
}
