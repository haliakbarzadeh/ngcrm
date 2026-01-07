using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Users.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Users.TypeConfigurations
{
    public class UserConfiguration : CommandTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            // add more configs here
            builder.ToTable("Users", "BSI");

            base.Configure(builder);
        }
    }
}
