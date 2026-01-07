using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Persons.TypeConfigurations
{
    public class PersonPositionConfiguration : CommandTypeConfiguration<PersonPosition>
    {
        public override void Configure(EntityTypeBuilder<PersonPosition> builder)
        {
            builder.ToTable("PersonPositions", "BSI");

            base.Configure(builder);
        }
    }
}
