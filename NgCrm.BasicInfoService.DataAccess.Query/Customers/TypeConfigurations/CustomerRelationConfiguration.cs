using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Customers.TypeConfigurations
{
    public class CustomerRelationConfiguration : QueryTypeConfiguration<CustomerRelationReadModel>
    {
        public override void Configure(EntityTypeBuilder<CustomerRelationReadModel> builder)
        {
            // add more configs here
            builder.ToTable("CustomerRelations", "BSI");

            base.Configure(builder);
        }
    }
}
