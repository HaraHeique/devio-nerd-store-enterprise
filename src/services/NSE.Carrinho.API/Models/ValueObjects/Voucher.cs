using NSE.Carrinho.API.Models.Enums;

namespace NSE.Carrinho.API.Models.ValueObjects
{
    public class Voucher
    {
        public decimal? Percentual { get; set; }
        public decimal? ValorDesconto { get; set; }
        public string Codigo { get; set; }
        public TipoDescontoVoucher TipoDesconto { get; set; }
    }
}