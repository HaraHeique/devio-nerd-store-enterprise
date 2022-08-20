using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models.Carrinho;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.ViewComponents
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoViewComponent(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carrinhoService.ObterCarrinho() ?? new CarrinhoViewModel());
        }
    }
}