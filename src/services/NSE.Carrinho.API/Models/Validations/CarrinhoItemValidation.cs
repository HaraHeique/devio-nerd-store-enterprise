using FluentValidation;

namespace NSE.Carrinho.API.Models.Validations
{
    public class ItemCarrinhoValidation : AbstractValidator<CarrinhoItem>
    {
        public ItemCarrinhoValidation()
        {
            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto não foi informado");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage(item => $"A quantidade miníma para o {item.Nome} é 1");

            RuleFor(c => c.Quantidade)
                .LessThanOrEqualTo(CarrinhoCliente.MAX_QUANTIDADE_ITEM)
                .WithMessage(item => $"A quantidade máxima do {item.Nome} é {CarrinhoCliente.MAX_QUANTIDADE_ITEM}");

            RuleFor(c => c.Valor)
                .GreaterThan(0)
                .WithMessage(item => $"O valor do {item.Nome} precisa ser maior que 0");
        }
    }
}
