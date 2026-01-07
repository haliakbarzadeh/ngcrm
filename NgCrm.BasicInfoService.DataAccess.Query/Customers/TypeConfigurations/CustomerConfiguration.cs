using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Customers.TypeConfigurations
{
    public class CustomerConfiguration : QueryTypeConfiguration<CustomerReadModel>
    {
        public override void Configure(EntityTypeBuilder<CustomerReadModel> builder)
        {
            // add more configs here
            builder.ToTable("Customers", "BSI");

            base.Configure(builder);
        }
    }
}
