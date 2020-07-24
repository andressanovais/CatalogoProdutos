using System.Collections.Generic;

namespace CatalogoProdutos.Dominio.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
