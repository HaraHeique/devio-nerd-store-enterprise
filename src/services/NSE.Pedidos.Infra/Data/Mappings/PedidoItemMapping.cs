using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Pedidos.Domain.Pedidos;

namespace NSE.Pedidos.Infra.Data.Mappings
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItems");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.ProdutoNome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // (NÃO É NECESSÁRIO SE JÁ TIVER NO OUTRO LADO DO RELACIONAMENTO)
            // 1 : N => Pedido : Pagamento
            builder.HasOne(pi => pi.Pedido)
                .WithMany(p => p.PedidoItems);
        }
    }
}