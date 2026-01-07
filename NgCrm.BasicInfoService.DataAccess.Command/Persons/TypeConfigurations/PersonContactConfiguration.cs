using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Persons.TypeConfigurations
{
    public class PersonContactConfiguration : CommandTypeConfiguration<PersonContact>
    {
        public override void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.ToTable("PersonContacts", "BSI");

            base.Configure(builder);
        }
    }
}
