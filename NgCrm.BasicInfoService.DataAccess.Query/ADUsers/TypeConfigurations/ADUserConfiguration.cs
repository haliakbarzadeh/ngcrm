using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.ADUsers.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.ADUsers.TypeConfigurations
{
    public class ADUserConfiguration : QueryTypeConfiguration<ADUserReadModel>
    {
        public override void Configure(EntityTypeBuilder<ADUserReadModel> builder)
        {
            // add more configs here
            builder.ToTable("ADUsers", "BSI");

            base.Configure(builder);
        }
    }
}
