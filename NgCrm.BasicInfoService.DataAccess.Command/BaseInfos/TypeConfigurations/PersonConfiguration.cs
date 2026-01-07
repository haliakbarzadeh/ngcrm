using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.BaseInfos.TypeConfigurations
{
    public class BaseInfoConfiguration : CommandTypeConfiguration<BaseInfo>
    {
        public override void Configure(EntityTypeBuilder<BaseInfo> builder)
        {
            builder.ToTable("BaseInfos", "BSI");

            base.Configure(builder);
        }
    }
}
