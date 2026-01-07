using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Roles.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Roles.TypeConfigurations
{
    public class RoleConfiguration : CommandTypeConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            // add more configs here
            builder.ToTable("Roles", "BSI");

            base.Configure(builder);
        }
    }
}
