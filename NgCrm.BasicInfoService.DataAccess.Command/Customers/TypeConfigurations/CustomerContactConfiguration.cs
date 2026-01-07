using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Customers.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Customers.TypeConfigurations
{
    public class CustomerContactConfiguration : CommandTypeConfiguration<CustomerContact>
    {
        public override void Configure(EntityTypeBuilder<CustomerContact> builder)
        {
            builder.ToTable("CustomerContacts", "BSI");

            base.Configure(builder);
        }
    }
}
