﻿using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class CatalogoController : MainController
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string? q = null)
        {
            var produtos = await _catalogoService.ObterTodos(ps, page, q);

            ViewBag.Pesquisa = q;
            produtos.ReferenceAction = nameof(Index);

            return View(produtos);
        }

        [HttpGet("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id) 
            => View(await _catalogoService.ObterPorId(id));
    }
}
