using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Permissions.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Permissions.TypeConfigurations
{
    public class PermissionConfiguration : CommandTypeConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions", "BSI");

            base.Configure(builder);
        }
    }
}
