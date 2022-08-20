using FluentValidation.Results;
using NSE.Carrinho.API.Models.Validations;

namespace NSE.Carrinho.API.Models
{
    public class CarrinhoCliente
    {
        internal const int MAX_QUANTIDADE_ITEM = 5;

        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }

        public ValidationResult ValidationResult { get; set; }

        // EF Relation
        public List<CarrinhoItem> Itens { get; set; }

        // EF Constructor
        public CarrinhoCliente()
        {
            Itens = new List<CarrinhoItem>();
        }

        public CarrinhoCliente(Guid clienteId) : this()
        {
            Id = Guid.NewGuid();
            this.ClienteId = clienteId;
        }

        internal void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(ci => ci.CalcularValorTotal());
        }

        internal bool CarrinhoItemExistente(CarrinhoItem item)
        {
            return Itens.Any(ci => ci.ProdutoId == item.ProdutoId);
        }

        internal CarrinhoItem? ObterPorProdutoId(Guid produtoId)
        {
            return Itens.FirstOrDefault(ci => ci.ProdutoId == produtoId);
        }

        internal void AdicionarItem(CarrinhoItem item)
        {
            item.AssociarCarrinho(Id);

            if (CarrinhoItemExistente(item))
            {
                var itemExistente = ObterPorProdutoId(item.ProdutoId);
                itemExistente!.AdicionarUnidades(item.Quantidade);

                item = itemExistente;
                Itens.Remove(itemExistente);
            }

            Itens.Add(item);
            CalcularValorTotal();
        }

        internal void AtualizarItem(CarrinhoItem item)
        {
            item.AssociarCarrinho(Id);

            var itemExistente = ObterPorProdutoId(item.ProdutoId);

            Itens.Remove(itemExistente!);
            Itens.Add(item);

            CalcularValorTotal();
        }

        internal void AtualizarUnidades(CarrinhoItem item, int unidades)
        {
            item.AtualizarUnidades(unidades);
            AtualizarItem(item);
        }

        internal void RemoverItem(CarrinhoItem item)
        {
            var itemExistente = ObterPorProdutoId(item.ProdutoId);
            Itens.Remove(itemExistente!);

            CalcularValorTotal();
        }

        internal bool EhValido()
        {
            var erros = Itens.SelectMany(i => new ItemCarrinhoValidation().Validate(i).Errors).ToList();
            erros.AddRange(new CarrinhoClienteValidation().Validate(this).Errors);

            ValidationResult = new ValidationResult(erros);

            return ValidationResult.IsValid;
        }
    }
}
