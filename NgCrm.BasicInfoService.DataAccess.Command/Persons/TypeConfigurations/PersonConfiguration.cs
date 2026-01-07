using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Persons.TypeConfigurations
{
    public class PersonConfiguration : CommandTypeConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons", "BSI");

            base.Configure(builder);
        }
    }
}
