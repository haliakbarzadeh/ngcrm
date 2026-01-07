using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Locations.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Locations.TypeConfigurations
{
    public class LocationConfiguration : CommandTypeConfiguration<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            // add more configs here
            builder.ToTable("Locations", "BSI");

            base.Configure(builder);
        }
    }
}
