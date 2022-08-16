namespace NSE.Carrinho.API.Models
{
    public class CarrinhoItem
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Quantidadade { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public Guid CarrinhoClienteId { get; set; }

        // EF Relation
        public CarrinhoCliente CarrinhoCliente { get; set; }

        public CarrinhoItem()
        {
            Id = Guid.NewGuid();
        }
    }
}
