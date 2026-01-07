using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Permissions.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Permissions.TypeConfigurations
{
    public class PermissionConfiguration : QueryTypeConfiguration<PermissionReadModel>
    {
        public override void Configure(EntityTypeBuilder<PermissionReadModel> builder)
        {
            // add more configs here
            builder.ToTable("Permissions", "BSI");

            base.Configure(builder);
        }
    }
}
