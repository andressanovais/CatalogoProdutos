using CatalogoProdutos.Data.Context;
using System;

namespace CatalogoProdutos.DAL
{
    public class UnitOfWork : IDisposable
    {
        private CatalogoDataContext context;
        private RepositorioCategoria categoriaRepositorio;
        private RepositorioProduto produtoRepositorio;

        public UnitOfWork(CatalogoDataContext context)
        {
            this.context = context;
        }

        public RepositorioCategoria CategoriaRepositorio
        {
            get
            {
                if (this.categoriaRepositorio == null)
                {
                    this.categoriaRepositorio = new RepositorioCategoria(context);
                }
                return categoriaRepositorio;
            }
        }

        public RepositorioProduto ProdutoRepositorio
        {
            get
            {
                if (this.produtoRepositorio == null)
                {
                    this.produtoRepositorio = new RepositorioProduto(context);
                }
                return produtoRepositorio;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}