using Goldiran.Framework.EFCore.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Persons.TypeConfigurations
{
    public class PersonConfiguration : QueryTypeConfiguration<PersonReadModel>
    {
        public override void Configure(EntityTypeBuilder<PersonReadModel> builder)
        {
            // add more configs here
            builder.ToTable("Persons", "BSI");
            builder.HasIndex(t => t.NationalCode).IsUnique();

            builder.HasMany(o => o.PersonPositions)
            .WithOne() // no navigation back
            .HasForeignKey(oi => oi.PersonId);


            builder.HasMany(x => x.PersonContacts)
                .WithOne()
                .HasForeignKey(x => x.PersonId);

            builder.HasMany(x => x.PersonAddresses)
                .WithOne()
                .HasForeignKey(x => x.PersonId);

            builder.HasMany(x => x.PersonPositions)
                .WithOne()
                .HasForeignKey(x => x.PersonId);


            base.Configure(builder);
        }
    }
}
