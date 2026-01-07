using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.OrganizationHistories.TypeConfigurations
{
    public class OrganizationHistoryConfiguration : CommandTypeConfiguration<OrganizationHistory>
    {
        public override void Configure(EntityTypeBuilder<OrganizationHistory> builder)
        {
            builder.ToTable("OrganizationHistories", "BSI");

            base.Configure(builder);
        }
    }
}
