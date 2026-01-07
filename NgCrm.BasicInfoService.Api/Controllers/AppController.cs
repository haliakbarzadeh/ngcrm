using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.AspNetCore;
using Goldiran.Framework.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgCrm.BasicInfoService.Domain.AuditLogs.Enums;
using NgCrm.BasicInfoService.Domain.Common.Enums;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Locations.Enums;
using NgCrm.BasicInfoService.Domain.Organizations.Enums;
using NgCrm.BasicInfoService.Domain.Permissions.Enums;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;
using NgCrm.BasicInfoService.Domain.Positions.Enums;
using NgCrm.BasicInfoService.Domain.Roles.Enums;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/app")]
    public class AppController : GoldiranController<AppController>
    {
        public AppController(ISender sender, ILogger<AppController> logger) : base(sender, logger)
        {

        }

        [HttpGet("get-base-types")]
        public async Task<ActionResult<IEnumerable<EnumDto>>> GetBaseTypes(CancellationToken cancellationToken)
        {
            Logger.LogInformation("BasicInfoService: GetBaseTypes Is Called");
            var result = new List<EnumDto>();
            result.AddRange(EnumHelper.GetKeyValueList<RoleTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<OrganizationTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<PermissionTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<PositionTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<DegreeTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<GenderTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<MarriageTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<LocationTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<BaseInfoTypes>());

            result.AddRange(EnumHelper.GetKeyValueList<ContractTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<DelegateReasonTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<DelegateStatusTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<PersonContactTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<CallTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<CustomerTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<SocialMediaTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<VipReasonTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<CustomerContactTypes>());
            result.AddRange(EnumHelper.GetKeyValueList<AccountTypes>()); 
            result.AddRange(EnumHelper.GetKeyValueList<AuditLogType>());



            return Ok(result);
        }
    }
}
