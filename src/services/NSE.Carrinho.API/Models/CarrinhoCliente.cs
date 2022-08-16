namespace NSE.Carrinho.API.Models
{
    public class CarrinhoCliente
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public decimal ValorTotal { get; set; }

        // EF Relation
        public List<CarrinhoItem> Itens { get; set; }

        public CarrinhoCliente(Guid clienteId) : this()
        {
            Id = Guid.NewGuid();
            ClientId = clienteId;
        }

        // EF Constructor
        private CarrinhoCliente() 
        {
            Itens = new List<CarrinhoItem>();
        }
    }
}
