using CatalogoProdutos.DAL;
using CatalogoProdutos.Dominio.Models;
using CatalogoProdutos.Dominio.ViewModels.ProdutoViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CatalogoProdutos.Controllers
{
    public class ProdutoController: ControllerBase
    {
        private readonly UnitOfWork _repositorio;

        public ProdutoController(UnitOfWork repositorio)
        {
            _repositorio = repositorio;
        }

        [Route("produtos")]
        [HttpGet]
        public IActionResult ObterProdutos()
        {
            try
            {
                return Ok(_repositorio.ProdutoRepositorio.GetViewModel());
            }
            catch (Exception)
            {
                return Problem("Não foi possível se conectar ao banco de dados.");
            }
        }

        [Route("produtos")]
        [HttpPost]
        public IActionResult InserirProduto([FromBody] EditarProdutoViewModel novoProduto)
        {
            novoProduto.Validate();
            if (novoProduto.Invalid)
            {
                return BadRequest(novoProduto.Notifications);
            }

            try
            {
                var produto = new Produto()
                {
                    Nome = novoProduto.Nome,
                    Marca = novoProduto.Marca,
                    Preco = novoProduto.Preco,
                    CategoriaId = novoProduto.CategoriaId,
                    Categoria = _repositorio.CategoriaRepositorio.GetByID(novoProduto.CategoriaId)
                };

                _repositorio.ProdutoRepositorio.Insert(produto);
                _repositorio.Save();

                return Ok("Produto adicionado com sucesso.");
            }
            catch (Exception)
            {
                return Problem("Não foi possível se conectar ao banco de dados.");
            }
        }

        [Route("produtos/{id}")]
        [HttpDelete]
        public IActionResult RemoverProduto(int id)
        {
            try
            {
                
                _repositorio.ProdutoRepositorio.Delete(id);
                _repositorio.Save();
                return Ok("Produto removido com sucesso.");
            }
            catch (Exception)
            {
                return Problem("Não foi possível se conectar ao banco de dados.");
            }
        }

        [Route("produtos")]
        [HttpPut]
        public IActionResult EditarProduto([FromBody] EditarProdutoViewModel produtoModel)
        {
            try
            {
                var produto = _repositorio.ProdutoRepositorio.GetByID(produtoModel.Id);
                 if (produto != null)
                 {
                     produto.Nome = produtoModel.Nome;
                     produto.Marca = produtoModel.Marca;
                     produto.Preco = produtoModel.Preco;
                     produto.CategoriaId = produtoModel.CategoriaId;

                     _repositorio.Save();

                     return Ok("Produto alterado com sucesso.");
                 }

                 return BadRequest("Produto não encontrado."); 
            }
            catch (Exception)
            {
                return Problem("Não foi possível se conectar ao banco de dados.");
            }
        }

    }
}
