using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NSE.Carrinho.API.Models;

#nullable disable
namespace NSE.Carrinho.API.Data
{
    public class CarrinhoContext : DbContext
    {
        public CarrinhoContext(DbContextOptions<CarrinhoContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<CarrinhoCliente> CarrinhoClientes { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetDefaultModelColumnsType(modelBuilder);
            SetDefaultBehaviorForeignKeys(modelBuilder);
            SetModelConfiguration(modelBuilder);

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

            void SetModelConfiguration(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<CarrinhoCliente>()
                    .HasIndex(c => c.ClientId)
                    .HasDatabaseName("IDX_Cliente");

                modelBuilder.Entity<CarrinhoCliente>()
                    .HasMany(c => c.Itens)
                    .WithOne(ci => ci.CarrinhoCliente)
                    .HasForeignKey(c => c.CarrinhoClienteId);
            }

            #endregion
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;

            return sucesso;
        }
    }
}
