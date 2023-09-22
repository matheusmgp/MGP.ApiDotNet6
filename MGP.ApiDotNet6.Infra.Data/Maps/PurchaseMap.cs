using MGP.ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MGP.ApiDotNet6.Infra.Data.Maps
{
    internal class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();
            builder.Property(x => x.Date)
              .HasColumnName("DATA");
            builder.Property(x => x.PersonId)
              .HasColumnName("PESSOA_ID");
            builder.Property(x => x.ProductId)
             .HasColumnName("PRODUTO_ID");
            builder.HasOne(x => x.Person)
                .WithMany(p => p.Purchases);
            builder.HasOne(x => x.Product)
              .WithMany(p => p.Purchases);
        }
    }
}
