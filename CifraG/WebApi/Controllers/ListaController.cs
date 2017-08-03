using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using Dominio.ViewModels;
using Dominio.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ListaController : Controller
    {
        private readonly IListaServico _listaServico;

        public ListaController(IListaServico listaServico)
        {
            _listaServico = listaServico;
        }

        // GET api/lista
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_listaServico.ObterTodos().Select(lista => lista.TransformarEmViewModel()));
        }

        // GET api/lista/5
        [HttpGet("{id:int}", Name = "ObterListaPorId")]
        public IActionResult ObterPorId(int id)
        {
            Lista lista = _listaServico.ObterPorId(id);

            if (lista == null)
            {
                return NotFound();
            }

            return Ok(lista.TransformarEmViewModel());
        }

        // POST api/lista
        [HttpPost]
        public IActionResult Salvar([FromBody]ListaViewModel viewModel)
        {
            return Ok(_listaServico.Salvar(viewModel));
        }

        // DELETE api/lista/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_listaServico.Excluir(id));
        }
    }
}
