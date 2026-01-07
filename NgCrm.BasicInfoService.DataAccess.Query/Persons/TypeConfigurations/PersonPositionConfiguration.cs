using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Persons.TypeConfigurations
{
    public class PersonPositionConfiguration : QueryTypeConfiguration<PersonPositionReadModel>
    {
        public override void Configure(EntityTypeBuilder<PersonPositionReadModel> builder)
        {
            // add more configs here
            builder.ToTable("PersonPositions", "BSI");



            builder.HasMany(x => x.PersonPositionPermissions)
                .WithOne()
                .HasForeignKey(x => x.PersonPositionId);

            base.Configure(builder);
        }
    }
}
