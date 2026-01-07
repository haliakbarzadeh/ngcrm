using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Organizations.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Organizations.TypeConfigurations
{
    public class OrganizationConfiguration : CommandTypeConfiguration<Organization>
    {
        public override void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations", "BSI");

            base.Configure(builder);
        }
    }
}
