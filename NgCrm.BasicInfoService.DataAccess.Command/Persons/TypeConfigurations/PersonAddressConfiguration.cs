using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Persons.TypeConfigurations
{
    public class PersonAddressConfiguration : CommandTypeConfiguration<PersonAddress>
    {
        public override void Configure(EntityTypeBuilder<PersonAddress> builder)
        {
            builder.ToTable("PersonAddresses", "BSI");

            base.Configure(builder);
        }
    }
}
