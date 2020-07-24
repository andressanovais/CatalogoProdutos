using CatalogoProdutos.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoProdutos.Data.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Produtos");
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200).HasColumnType("varchar(200)");
            builder.Property(x => x.Marca).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Preco).IsRequired().HasColumnType("money");
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos);
        }
    }
}
