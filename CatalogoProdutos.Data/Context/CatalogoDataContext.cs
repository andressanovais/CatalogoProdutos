using CatalogoProdutos.Data.Maps;
using CatalogoProdutos.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Data.Context
{
    public class CatalogoDataContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RM1JQTI;Database=CatalogoProdutos;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoriaMap());
            builder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
