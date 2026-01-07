using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Workspaces.TypeConfigurations
{
    public class WorkspaceConfiguration : CommandTypeConfiguration<Workspace>
    {
        public override void Configure(EntityTypeBuilder<Workspace> builder)
        {
            builder.ToTable("Workspaces", "BSI");

            base.Configure(builder);
        }
    }
}
