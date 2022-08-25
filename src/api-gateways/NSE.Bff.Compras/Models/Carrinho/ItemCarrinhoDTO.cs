namespace NSE.Bff.Compras.Models.Carrinho
{
    public class ItemCarrinhoDTO
    {
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public int Quantidade { get; set; }
    }
}