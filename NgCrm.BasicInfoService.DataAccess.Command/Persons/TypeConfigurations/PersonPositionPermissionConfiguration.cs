using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Persons.TypeConfigurations
{
    public class PersonPositionPermissionConfiguration : CommandTypeConfiguration<PersonPositionPermission>
    {
        public override void Configure(EntityTypeBuilder<PersonPositionPermission> builder)
        {
            builder.ToTable("PersonPositionPermissions", "BSI");

            base.Configure(builder);
        }
    }
}
