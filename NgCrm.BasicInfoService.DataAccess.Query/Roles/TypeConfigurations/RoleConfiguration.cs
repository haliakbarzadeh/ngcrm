using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Roles.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Roles.TypeConfigurations
{
    public class RoleConfiguration : QueryTypeConfiguration<RoleReadModel>
    {
        public override void Configure(EntityTypeBuilder<RoleReadModel> builder)
        {
            // add more configs here
            builder.ToTable("Roles", "BSI");

            base.Configure(builder);
        }
    }
}
