using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Persons.TypeConfigurations
{
    public class PersonAddressConfiguration : QueryTypeConfiguration<PersonAddressReadModel>
    {
        public override void Configure(EntityTypeBuilder<PersonAddressReadModel> builder)
        {
            // add more configs here
            builder.ToTable("PersonAddresses", "BSI");

            base.Configure(builder);
        }
    }
}
