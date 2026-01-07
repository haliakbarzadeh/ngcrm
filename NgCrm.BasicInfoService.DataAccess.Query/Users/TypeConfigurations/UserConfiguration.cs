using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Users.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Users.TypeConfigurations
{
    public class UserConfiguration : QueryTypeConfiguration<UserReadModel>
    {
        public override void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            // add more configs here
            builder.ToTable("Users", "BSI");

            builder.HasIndex(t => t.Username).IsUnique();

            base.Configure(builder);
        }
    }
}
