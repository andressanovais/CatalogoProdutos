using CatalogoProdutos.DAL;
using CatalogoProdutos.Dominio.Models;
using CatalogoProdutos.Dominio.ViewModels.CategoriaViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CatalogoProdutos.Controllers
{
    public class CategoriaController : ControllerBase
    {
        private readonly UnitOfWork _repositorio;

        public CategoriaController(UnitOfWork repositorio)
        {
            _repositorio = repositorio;
        }

        [Route("categorias")]
        [HttpGet]
        public IActionResult ObterCategorias()
        {
            try
            {
                 return Ok(_repositorio.CategoriaRepositorio.GetViewModel());
            }
            catch (Exception)
            {
                return Problem("Não foi possível se conectar ao banco de dados.");
            }

        }

        [Route("categorias")]
        [HttpPost]
        public IActionResult AdicionarCategorias([FromBody]EditarCategoriaViewModel novaCategoria)
        {
            novaCategoria.Validate();
            if (novaCategoria.Invalid)
            {
                return BadRequest(novaCategoria.Notifications);
            }

            try
            {
                var categoria = new Categoria();
                categoria.Nome = novaCategoria.Nome;

                _repositorio.CategoriaRepositorio.Insert(categoria);
                _repositorio.Save();

                return Ok("Categoria salva com sucesso.");
            }
            catch (Exception)
            {
                return Problem("Não foi possível se conectar ao banco de dados.");
            }
        }

        [Route("categorias/{id}")]
        [HttpDelete]
        public IActionResult RemoverCategoria (int id)
        {
            try
            {
                _repositorio.CategoriaRepositorio.Delete(id);
                return Ok("Categoria removida com sucesso.");
            }
            catch (Exception)
            {
                return Problem("Não foi possível se conectar ao banco de dados.");
            }
        }
    }
}
