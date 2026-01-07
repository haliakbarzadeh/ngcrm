using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.ADUsers.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.ADUsers.TypeConfigurations
{
    public class ADUserConfiguration : CommandTypeConfiguration<ADUser>
    {
        public override void Configure(EntityTypeBuilder<ADUser> builder)
        {
            // add more configs here
            builder.ToTable("ADUsers", "BSI");

            base.Configure(builder);
        }
    }
}
