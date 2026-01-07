using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Customers.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Customers.TypeConfigurations
{
    public class CustomerAddressConfiguration : CommandTypeConfiguration<CustomerAddress>
    {
        public override void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddresses", "BSI");

            base.Configure(builder);
        }
    }
}
