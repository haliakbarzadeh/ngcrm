using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Customers.TypeConfigurations
{
    public class CustomerContactConfiguration : QueryTypeConfiguration<CustomerContactReadModel>
    {
        public override void Configure(EntityTypeBuilder<CustomerContactReadModel> builder)
        {
            // add more configs here
            builder.ToTable("CustomerContacts", "BSI");

            base.Configure(builder);
        }
    }
}
