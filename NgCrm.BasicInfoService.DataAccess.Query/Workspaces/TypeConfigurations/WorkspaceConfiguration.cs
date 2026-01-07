using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Workspaces.TypeConfigurations
{
    public class WorkspaceConfiguration : QueryTypeConfiguration<WorkspaceReadModel>
    {
        public override void Configure(EntityTypeBuilder<WorkspaceReadModel> builder)
        {
            builder.ToTable("Workspaces", "BSI");

            builder.HasMany(x => x.WorkspacePermissions)
                .WithOne()
                .HasForeignKey(x => x.WorkspaceId);

            base.Configure(builder);
        }
    }
}
