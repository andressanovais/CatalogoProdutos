using CatalogoProdutos.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Data.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Categorias");
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
        }
    }
}
