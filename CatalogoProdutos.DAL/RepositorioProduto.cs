using CatalogoProdutos.Data.Context;
using CatalogoProdutos.Dominio.Models;
using CatalogoProdutos.Dominio.ViewModels.ProdutoViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoProdutos.DAL
{
    public class RepositorioProduto : RepositorioGenerico<Produto>
    {
        public RepositorioProduto(CatalogoDataContext context) : base(context)
        {
        }

        public IEnumerable<ExibirProdutoViewModel> GetViewModel()
        {
            return Get(includeProperties: "Categoria")
                .Select(x => new ExibirProdutoViewModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Marca = x.Marca,
                    Preco = x.Preco,
                    NomeCategoria = x.Categoria.Nome
                }
                );
        }
    }
}
