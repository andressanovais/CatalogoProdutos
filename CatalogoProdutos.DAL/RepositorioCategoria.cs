using CatalogoProdutos.Data.Context;
using CatalogoProdutos.Dominio.Models;
using CatalogoProdutos.Dominio.ViewModels.CategoriaViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoProdutos.DAL
{
    public class RepositorioCategoria : RepositorioGenerico<Categoria>
    {
        public RepositorioCategoria(CatalogoDataContext context) : base(context)
        {
        }

        public IEnumerable<ExibirCategoriaViewModel> GetViewModel()
        {
            return Get()
                .Select(x => new ExibirCategoriaViewModel()
                {
                    Nome = x.Nome,
                    Id = x.Id
                }
                );
        }
    }
}
