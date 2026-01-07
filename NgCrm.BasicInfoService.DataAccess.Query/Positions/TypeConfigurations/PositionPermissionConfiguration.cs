using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Positions.TypeConfigurations
{
    public class PositionPermissionConfiguration : QueryTypeConfiguration<PositionPermissionReadModel>
    {
        public override void Configure(EntityTypeBuilder<PositionPermissionReadModel> builder)
        {
            // add more configs here
            builder.ToTable("PositionPermissions", "BSI");

            base.Configure(builder);
        }
    }
}
