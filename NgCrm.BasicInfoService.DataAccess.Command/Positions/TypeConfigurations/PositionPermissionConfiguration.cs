using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Positions.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Positions.TypeConfigurations
{
    public class PositionPermissionConfiguration : CommandTypeConfiguration<PositionPermission>
    {
        public override void Configure(EntityTypeBuilder<PositionPermission> builder)
        {
            builder.ToTable("PositionPermissions", "BSI");

            base.Configure(builder);
        }
    }
}
