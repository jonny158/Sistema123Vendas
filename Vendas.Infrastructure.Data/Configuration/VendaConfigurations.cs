using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;

namespace Vendas.Infrastructure.Data.Configuration
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {

            builder.ToTable("Venda");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.NumeroVenda).IsRequired();
            builder.Property(u => u.DataVenda).IsRequired();
            builder.Property(u => u.ClienteId).IsRequired();
            builder.Property(u => u.ClienteNome).HasMaxLength(200).IsRequired();
            builder.Property(u => u.ValorTotal).IsRequired();
            builder.Property(u => u.Filial);
            builder.Property(u => u.Cancelada);

        }
    }
}


