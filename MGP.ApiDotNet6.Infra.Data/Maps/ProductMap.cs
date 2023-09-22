using MGP.ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MGP.ApiDotNet6.Infra.Data.Maps
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();
            builder.Property(x => x.Name)
              .HasColumnName("NOME");
            builder.Property(x => x.CodErp)
              .HasColumnName("CODIGO_ERP");
            builder.Property(x => x.Price)
             .HasColumnName("PRECO");
            builder.HasMany(x => x.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
