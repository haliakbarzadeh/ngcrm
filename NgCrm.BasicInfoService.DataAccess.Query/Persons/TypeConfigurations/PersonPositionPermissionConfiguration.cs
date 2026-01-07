using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Persons.TypeConfigurations
{
    public class PersonPositionPermissionConfiguration : QueryTypeConfiguration<PersonPositionPermissionReadModel>
    {
        public override void Configure(EntityTypeBuilder<PersonPositionPermissionReadModel> builder)
        {
            // add more configs here
            builder.ToTable("PersonPositionPermissions", "BSI");

            base.Configure(builder);
        }
    }
}
