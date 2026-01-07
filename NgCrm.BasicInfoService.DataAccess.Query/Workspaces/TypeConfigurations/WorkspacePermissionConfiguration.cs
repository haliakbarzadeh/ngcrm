using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Workspaces.TypeConfigurations
{
    public class WorkspacePermissionConfiguration : QueryTypeConfiguration<WorkspacePermissionReadModel>
    {
        public override void Configure(EntityTypeBuilder<WorkspacePermissionReadModel> builder)
        {
            builder.ToTable("WorkspacePermissions", "BSI");
            //builder.ToTable("WorkspacePermissions", "BSI");

            base.Configure(builder);
        }
    }
}
