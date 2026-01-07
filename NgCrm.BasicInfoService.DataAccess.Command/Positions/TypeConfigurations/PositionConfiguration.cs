using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Positions.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Positions.TypeConfigurations
{
    public class PositionConfiguration : CommandTypeConfiguration<Position>
    {
        public override void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions", "BSI");

            base.Configure(builder);
        }
    }
}
