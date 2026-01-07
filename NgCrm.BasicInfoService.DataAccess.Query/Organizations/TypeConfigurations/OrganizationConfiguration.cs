using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Organizations.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Organizations.TypeConfigurations
{
    public class OrganizationConfiguration : QueryTypeConfiguration<OrganizationReadModel>
    {
        public override void Configure(EntityTypeBuilder<OrganizationReadModel> builder)
        {
            // add more configs here
            builder.ToTable("Organizations", "BSI");

            base.Configure(builder);
        }
    }
}
