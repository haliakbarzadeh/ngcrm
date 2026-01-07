using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Positions.TypeConfigurations
{
    public class PositionConfiguration : QueryTypeConfiguration<PositionReadModel>
    {
        public override void Configure(EntityTypeBuilder<PositionReadModel> builder)
        {
            // add more configs here
            builder.ToTable("Positions", "BSI");

            builder.HasMany(x => x.PositionPermissions)
                .WithOne()
                .HasForeignKey(x => x.PositionId);

            base.Configure(builder);
        }
    }
}
