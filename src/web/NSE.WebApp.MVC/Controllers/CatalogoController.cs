using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class CatalogoController : MainController
    {
        //private readonly ICatalogoService _catalogoService;
        private readonly ICatalogoServiceRefit _catalogoService;

        public CatalogoController(ICatalogoServiceRefit catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index() 
            => View(await _catalogoService.ObterTodos());

        [HttpGet("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id) 
            => View(await _catalogoService.ObterPorId(id));
    }
}
