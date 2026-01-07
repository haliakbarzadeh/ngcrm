using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Customers.TypeConfigurations
{
    public class CustomerAddressConfiguration : QueryTypeConfiguration<CustomerAddressReadModel>
    {
        public override void Configure(EntityTypeBuilder<CustomerAddressReadModel> builder)
        {
            // add more configs here
            builder.ToTable("CustomerAddresses", "BSI");

            base.Configure(builder);
        }
    }
}
