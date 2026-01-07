using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Locations.TypeConfigurations
{
    public class LocationConfiguration : QueryTypeConfiguration<LocationReadModel>
    {
        public override void Configure(EntityTypeBuilder<LocationReadModel> builder)
        {
            // add more configs here
            builder.ToTable("Locations", "BSI");

            base.Configure(builder);
        }
    }
}
