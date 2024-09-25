using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Entities;

namespace Vendas.Infrastructure.Data.Configuration
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {

            builder.ToTable("ItemVenda");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.ProdutoId).IsRequired();
            builder.Property(u => u.ProdutoNome).HasMaxLength(200).IsRequired();
            builder.Property(u => u.Quantidade).IsRequired();
            builder.Property(u => u.ValorUnitario).IsRequired();
            builder.Property(u => u.Desconto).IsRequired();
            builder.Property(u => u.ValorTotal).IsRequired();
            builder.Property(u => u.VendaId).IsRequired();
            builder.Property(u => u.Cancelado);
        }
    }
}
