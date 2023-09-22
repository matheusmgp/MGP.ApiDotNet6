using MGP.ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MGP.ApiDotNet6.Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();
            builder.Property(x => x.Document)
              .HasColumnName("DOCUMENTO");
            builder.Property(x => x.Name)
              .HasColumnName("NOME");
            builder.Property(x => x.Phone)
             .HasColumnName("TELEFONE");
            builder.HasMany(x => x.Purchases)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);
        }
    }
}
