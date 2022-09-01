using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Pedidos.Domain.Pedidos;

namespace NSE.Pedidos.Infra.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(c => c.Id);

            builder.OwnsOne(p => p.Endereco, e =>
            {
                e.Property(pe => pe.Logradouro)
                    .HasColumnName("Logradouro");

                e.Property(pe => pe.Numero)
                    .HasColumnName("Numero");

                e.Property(pe => pe.Complemento)
                    .HasColumnName("Complemento");

                e.Property(pe => pe.Bairro)
                    .HasColumnName("Bairro");

                e.Property(pe => pe.Cep)
                    .HasColumnName("Cep");

                e.Property(pe => pe.Cidade)
                    .HasColumnName("Cidade");

                e.Property(pe => pe.Estado)
                    .HasColumnName("Estado");
            });

            // MinhaSequencia foi configurado no método OnModelCreating do contexto de Pedidos
            builder.Property(c => c.Codigo)
                .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");

            // 1 : N => Pedido : PedidoItems
            builder.HasMany(p => p.PedidoItems)
                .WithOne(pi => pi.Pedido)
                .HasForeignKey(pi => pi.PedidoId);
        }
    }
}