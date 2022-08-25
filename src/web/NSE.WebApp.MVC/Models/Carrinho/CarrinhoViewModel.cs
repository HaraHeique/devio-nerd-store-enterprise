using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models.Carrinho
{
    public class CarrinhoViewModel
    {
        public decimal ValorTotal { get; set; }
        public List<ItemCarrinhoViewModel> Itens { get; set; } = new List<ItemCarrinhoViewModel>();
    }
}