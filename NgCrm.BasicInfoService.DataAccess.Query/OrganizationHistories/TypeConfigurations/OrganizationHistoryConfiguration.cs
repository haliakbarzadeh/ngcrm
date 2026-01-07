using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.OrganizationHistories.TypeConfigurations
{
    public class OrganizationHistoryConfiguration : QueryTypeConfiguration<OrganizationHistoryReadModel>
    {
        public override void Configure(EntityTypeBuilder<OrganizationHistoryReadModel> builder)
        {
            // add more configs here
            builder.ToTable("OrganizationHistories", "BSI");

            base.Configure(builder);
        }
    }
}
