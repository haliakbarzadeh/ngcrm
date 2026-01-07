using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Locations.Contracts;
using NgCrm.BasicInfoService.Domain.Locations.Entities;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.DataAccess.Command.Locations
{
    public class LocationCommandRepository : CommandRepository<Location, BasicInfoCommandContext>, ILocationCommandRepository
    {
        public LocationCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
            
        }
    }
}
