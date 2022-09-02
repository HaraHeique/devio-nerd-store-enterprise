using FluentValidation.Results;
using MediatR;
using NSE.Cliente.API.Application.Events;
using NSE.Cliente.API.Models;
using NSE.Core.Messages;

namespace NSE.Cliente.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, 
        IRequestHandler<RegistrarClienteCommand, ValidationResult>,
        IRequestHandler<AdicionarEnderecoCommand, ValidationResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand mensagem, CancellationToken cancellationToken)
        {
            if (!mensagem.EhValido()) return mensagem.ValidationResult;

            var cliente = new Models.Cliente(mensagem.Id, mensagem.Nome, mensagem.Email, mensagem.Cpf);

            var clienteExistente = await _clienteRepository.ObterPorCpf(cliente.Cpf.Numero);

            if (clienteExistente is not null)
            {
                AdicionarErro("Este CPF já está em uso");
                return ValidationResult;
            }

            _clienteRepository.Adicionar(cliente);

            cliente.AdicionarEvento(new ClienteRegistradoEvent(mensagem.Id, mensagem.Nome, mensagem.Email, mensagem.Cpf));
            
            return await PersistirDados(_clienteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AdicionarEnderecoCommand mensagem, CancellationToken cancellationToken)
        {
            if (!mensagem.EhValido()) return mensagem.ValidationResult;

            var endereco = new Endereco(mensagem.Logradouro, mensagem.Numero, mensagem.Complemento, mensagem.Bairro, mensagem.Cep, mensagem.Cidade, mensagem.Estado, mensagem.ClienteId);
            _clienteRepository.AdicionarEndereco(endereco);

            return await PersistirDados(_clienteRepository.UnitOfWork);
        }
    }
}
