using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.ViewComponents
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly IComprasBffService _carrinhoService;

        public CarrinhoViewComponent(IComprasBffService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carrinhoService.ObterQuantidadeCarrinho());
        }
    }
}