using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;
using NgCrm.BasicInfoService.Domain.Permissions.ReadModels;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.PersonAccessGroups.TypeConfigurations
{
    public class PersonAccessGroupConfiguration : QueryTypeConfiguration<PersonAccessGroupReadModel>
    {
        public override void Configure(EntityTypeBuilder<PersonAccessGroupReadModel> builder)
        {
            builder.ToTable("PersonAccessGroups", "BSI");

            builder.HasOne(e => e.AccessGroup)
                .WithMany()
                .HasForeignKey(c => c.AccessGroupId);

            builder.HasOne(e => e.Person)
                .WithMany()
                .HasForeignKey(c => c.PersonId);

            base.Configure(builder);
        }
    }
}