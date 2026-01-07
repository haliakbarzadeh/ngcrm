using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Departments.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Departments.TypeConfigurations
{
    public class DepartmentConfiguration : QueryTypeConfiguration<DepartmentReadModel>
    {
        public override void Configure(EntityTypeBuilder<DepartmentReadModel> builder)
        {
            builder.ToTable("Departments", "BSI");

            //builder.HasOne(x => x.Parent)
            //    .WithMany(x => x.Children)
            //    .HasForeignKey(x => x.ParentId)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}