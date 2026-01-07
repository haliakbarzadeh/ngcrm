using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Workspaces.TypeConfigurations
{
    public class WorkspacePermissionConfiguration : CommandTypeConfiguration<WorkspacePermission>
    {
        public override void Configure(EntityTypeBuilder<WorkspacePermission> builder)
        {
            builder.ToTable("WorkspacePermissions", "BSI");

            base.Configure(builder);
        }
    }
}
