using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.AccessGroups.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.AccessGroups.TypeConfigurations
{
    public class AccessGroupConfiguration : QueryTypeConfiguration<AccessGroupReadModel>
    {
        public override void Configure(EntityTypeBuilder<AccessGroupReadModel> builder)
        {
            // add more configs here
            builder.ToTable("AccessGroups", "BSI");

            base.Configure(builder);
        }
    }
}
