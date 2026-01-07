using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.BaseInfos.TypeConfigurations
{
    public class BaseInfoConfiguration : QueryTypeConfiguration<BaseInfoReadModel>
    {
        public override void Configure(EntityTypeBuilder<BaseInfoReadModel> builder)
        {
            builder.ToTable("BaseInfos", "BSI");

            base.Configure(builder);
        }
    }
}
