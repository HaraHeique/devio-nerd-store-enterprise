using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSE.Carrinho.API.Data;
using NSE.Carrinho.API.Models;
using NSE.WebAPI.Core.Controllers;
using NSE.WebAPI.Core.Usuario;

namespace NSE.Carrinho.API.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly CarrinhoContext _context;

        public CarrinhoController(
            IAspNetUser user, 
            CarrinhoContext carrinhoContext)
        {
            _user = user;
            _context = carrinhoContext;
        }

        [HttpGet("carrinho")]
        public async Task<CarrinhoCliente> ObterCarrinho() 
            => await ObterCarrinhoCliente() ?? new CarrinhoCliente();

        [HttpPost("carrinho")]
        public async Task<IActionResult> AdicionarItemCarrinho(CarrinhoItem item)
        {
            var carrinho = await ObterCarrinhoCliente();

            if (carrinho is null)
                ManipularNovoCarrinho(item);
            else
                ManipularCarrinhoExistente(carrinho, item);

            if (OperacaoInvalida()) return CustomResponse();

            await PersistirDados();
            
            return CustomResponse();
        }
        
        [HttpPut("carrinho/{produtoId:guid}")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, CarrinhoItem item)
        {
            var carrinho = await ObterCarrinhoCliente();
            var itemCarrinho = await ObterItemCarrinhoValidado(produtoId, carrinho, item);

            if (itemCarrinho is null) return CustomResponse();

            carrinho!.AtualizarUnidades(itemCarrinho, item.Quantidade);

            ValidarCarrinho(carrinho);
            if (OperacaoInvalida()) return CustomResponse();

            _context.CarrinhoItens.Update(itemCarrinho);
            _context.CarrinhoClientes.Update(carrinho);

            await PersistirDados();

            return CustomResponse();
        }
        
        [HttpDelete("carrinho/{produtoId:guid}")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var carrinho = await ObterCarrinhoCliente();
            var itemCarrinho = await ObterItemCarrinhoValidado(produtoId, carrinho);

            if (itemCarrinho is null) return CustomResponse();

            ValidarCarrinho(carrinho!);
            if (OperacaoInvalida()) return CustomResponse();

            carrinho!.RemoverItem(itemCarrinho);

            _context.CarrinhoItens.Remove(itemCarrinho);
            _context.CarrinhoClientes.Update(carrinho);

            await PersistirDados();

            return CustomResponse();
        }

        private async Task<CarrinhoCliente?> ObterCarrinhoCliente()
        {
            return await _context.CarrinhoClientes
                .Include(c => c.Itens)
                .FirstOrDefaultAsync(c => c.ClienteId == _user.ObterUserId());
        }

        private void ManipularNovoCarrinho(CarrinhoItem item)
        {
            var carrinho = new CarrinhoCliente(_user.ObterUserId());
            carrinho.AdicionarItem(item);

            ValidarCarrinho(carrinho);

            _context.CarrinhoClientes.Add(carrinho);
        }
        
        private void ManipularCarrinhoExistente(CarrinhoCliente carrinho, CarrinhoItem item)
        {
            var produtoItemExistente = carrinho.CarrinhoItemExistente(item);

            carrinho.AdicionarItem(item);
            ValidarCarrinho(carrinho);

            if (produtoItemExistente)
                _context.CarrinhoItens.Update(carrinho.ObterPorProdutoId(item.ProdutoId)!);
            else
                _context.CarrinhoItens.Add(item);

            _context.CarrinhoClientes.Update(carrinho);
        }

        private async Task<CarrinhoItem?> ObterItemCarrinhoValidado(Guid produtoId, CarrinhoCliente? carrinho, CarrinhoItem? item = null)
        {
            if (item is not null && produtoId != item?.ProdutoId)
            {
                AdicionarErros("O item não corresponde ao informado");
                return null;
            }

            if (carrinho is null)
            {
                AdicionarErros("Carrinho não encontrado");
                return null;
            }

            var itemCarrinho = await _context.CarrinhoItens
                .FirstOrDefaultAsync(ci => ci.CarrinhoClienteId == carrinho.Id && ci.ProdutoId == produtoId);

            if (itemCarrinho is null || !carrinho.CarrinhoItemExistente(itemCarrinho))
            {
                AdicionarErros("O item não está no carrinho");
                return null;
            }

            return itemCarrinho;
        }

        private async Task PersistirDados()
        {
            var resultadoAlteracoes = await _context.SaveChangesAsync();

            if (resultadoAlteracoes <= 0) 
                CustomErrorResponse("Não foi possível persistir os dados no banco");
        }

        private bool ValidarCarrinho(CarrinhoCliente carrinho)
        {
            if (carrinho.EhValido()) return true;

            AdicionarErros(carrinho.ValidationResult.Errors.Select(e => e.ErrorMessage).ToArray());

            return false;
        }
    }
}
