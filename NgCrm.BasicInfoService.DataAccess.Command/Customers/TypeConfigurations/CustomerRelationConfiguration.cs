using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Customers.TypeConfigurations
{
    public class CustomerRelationConfiguration : CommandTypeConfiguration<CustomerRelation>
    {
        public override void Configure(EntityTypeBuilder<CustomerRelation> builder)
        {
            builder.ToTable("CustomerRelations", "BSI");
            builder.HasOne<BaseInfo>()
            .WithMany()
            .HasForeignKey(c => c.RelationTitleId);
            base.Configure(builder);
        }
    }
}
