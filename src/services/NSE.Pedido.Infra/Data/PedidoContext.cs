﻿using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NSE.Core.Data;
using NSE.Core.DomainObjects;
using NSE.Core.Mediator;
using NSE.Core.Messages;
using NSE.Pedido.Domain.Vouchers;

#nullable disable
namespace NSE.Pedido.Infra.Data
{
    public class PedidoContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PedidoContext(DbContextOptions<PedidoContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        //public DbSet<Pedido> Clientes { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetDefaultIgnoreModels(modelBuilder);
            SetDefaultModelColumnsType(modelBuilder);
            SetDefaultBehaviorForeignKeys(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidoContext).Assembly);

            base.OnModelCreating(modelBuilder);

            #region Método locais para setar tipo default e relacionamento das FK

            void SetDefaultModelColumnsType(ModelBuilder modelBuilder)
            {
                // Todas colunas que são do tipo texto (string) terão como default o tamanho de varchar(100)
                IEnumerable<IMutableProperty> stringColumnsType = GetAllPropertiesByType(modelBuilder, typeof(string));

                foreach (var property in stringColumnsType) property.SetColumnType("varchar(100)");

                // Todas colunas que são do tipo decimal (valor numérico) terão como default o tamanho de decimal(18,2)
                IEnumerable<IMutableProperty> decimalColumnsType = GetAllPropertiesByType(modelBuilder, typeof(decimal));

                foreach (var property in decimalColumnsType) property.SetColumnType("decimal(18,2)");
            }

            IEnumerable<IMutableProperty> GetAllPropertiesByType(ModelBuilder modelBuilder, Type type)
            {
                return modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetProperties().Where(p => p.ClrType == type));
            }

            void SetDefaultBehaviorForeignKeys(ModelBuilder modelBuilder)
            {
                var foreignKeys = modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys());

                foreach (var relationship in foreignKeys)
                    relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            void SetDefaultIgnoreModels(ModelBuilder modelBuilder)
            {
                modelBuilder.Ignore<ValidationResult>();
                modelBuilder.Ignore<Event>();
            }

            #endregion
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;

            // Só publica os eventos de domínio se ao salvar na base dar sucesso
            if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublicarEventos<T>(this IMediatorHandler mediator, T contexto) where T : DbContext
        {
            var entities = contexto.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = entities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            entities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublicarEvento(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
