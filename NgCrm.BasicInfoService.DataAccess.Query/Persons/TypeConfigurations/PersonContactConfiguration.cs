using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Persons.TypeConfigurations
{
    public class PersonContactConfiguration : QueryTypeConfiguration<PersonContactReadModel>
    {
        public override void Configure(EntityTypeBuilder<PersonContactReadModel> builder)
        {
            // add more configs here
            builder.ToTable("PersonContacts", "BSI");

            base.Configure(builder);
        }
    }
}
