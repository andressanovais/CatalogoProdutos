using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoProdutos.Dominio.ViewModels.ProdutoViewModels
{
    public class AdicionarProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public int CategoriaId { get; set; }
    }
}
