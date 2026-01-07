using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.AccessGroups.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.AccessGroups.TypeConfigurations
{
    public class AccessGroupConfiguration : CommandTypeConfiguration<AccessGroup>
    {
        public override void Configure(EntityTypeBuilder<AccessGroup> builder)
        {
            builder.ToTable("AccessGroups", "BSI");

            base.Configure(builder);
        }
    }
}
