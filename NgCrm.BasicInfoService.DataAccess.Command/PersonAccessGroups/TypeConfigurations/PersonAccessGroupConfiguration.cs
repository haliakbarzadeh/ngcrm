using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.PersonAccessGroups.TypeConfigurations
{
    public class PersonAccessGroupConfiguration : CommandTypeConfiguration<PersonAccessGroup>
    {
        public override void Configure(EntityTypeBuilder<PersonAccessGroup> builder)
        {
            builder.ToTable("PersonAccessGroups", "BSI");

            base.Configure(builder);
        }
    }
}
