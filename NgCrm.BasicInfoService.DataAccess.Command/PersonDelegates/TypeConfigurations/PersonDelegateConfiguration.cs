using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.PersonDelegates.TypeConfigurations
{
    public class PersonDelegateConfiguration : CommandTypeConfiguration<PersonDelegate>
    {
        public override void Configure(EntityTypeBuilder<PersonDelegate> builder)
        {
            builder.ToTable("PersonDelegates", "BSI");

            base.Configure(builder);
        }
    }
}