using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NSE.Catalogo.API.Models;
using NSE.Core.Data;
using NSE.Core.Messages;

#nullable disable
namespace NSE.Catalogo.API.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetDefaultIgnoreModels(modelBuilder);
            SetDefaultModelColumnsType(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);

            base.OnModelCreating(modelBuilder);

            #region Método locais para setar tipo default

            void SetDefaultModelColumnsType(ModelBuilder modelBuilder)
            {
                // Todas colunas que são do tipo texto (string) terão como default o tamanho de varchar(100)
                IEnumerable<IMutableProperty> stringColumnsType = GetAllPropertiesByType(modelBuilder, typeof(string));

                foreach (var property in stringColumnsType) property.SetColumnType("varchar(100)");

                // Todas colunas que são do tipo decimal (valor numérico) terão como default o tamanho de decimal(18,2)
                IEnumerable<IMutableProperty> decimalColumnsType = GetAllPropertiesByType(modelBuilder, typeof(decimal));

                foreach (var property in decimalColumnsType) property.SetColumnType("decimal(18,2)");
            }

            void SetDefaultIgnoreModels(ModelBuilder modelBuilder)
            {
                modelBuilder.Ignore<ValidationResult>();
                modelBuilder.Ignore<Event>();
            }

            IEnumerable<IMutableProperty> GetAllPropertiesByType(ModelBuilder modelBuilder, Type type)
            {
                return modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetProperties().Where(p => p.ClrType == type));
            }

            #endregion
        }

        public async Task<bool> Commit() => await base.SaveChangesAsync() > 0;
    }
}
