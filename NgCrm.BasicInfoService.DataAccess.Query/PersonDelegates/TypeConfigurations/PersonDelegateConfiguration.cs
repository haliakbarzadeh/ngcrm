using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.PersonDelegates.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.PersonDelegates.TypeConfigurations
{
    public class PersonDelegateConfiguration : QueryTypeConfiguration<PersonDelegateReadModel>
    {
        public override void Configure(EntityTypeBuilder<PersonDelegateReadModel> builder)
        {
            builder.ToTable("PersonDelegates", "BSI");

            base.Configure(builder);
        }
    }
}