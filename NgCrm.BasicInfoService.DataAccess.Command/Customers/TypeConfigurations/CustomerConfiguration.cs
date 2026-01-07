using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Customers.TypeConfigurations
{
    public class CustomerConfiguration : CommandTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.ToTable("Customers", "BSI");
            builder.HasIndex(t => t.NationalCode).IsUnique();

            builder.HasOne<BaseInfo>()
                .WithMany()
                .HasForeignKey(c => c.CustomerTitleId);
            builder.HasOne<BaseInfo>()
                .WithMany()
                .HasForeignKey(c => c.NationalityId);

            base.Configure(builder);
        }
    }
}
