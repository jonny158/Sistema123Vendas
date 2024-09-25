using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;

namespace Vendas.Infrastructure.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.ToTable("Cliente");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).HasMaxLength(200).IsRequired();
        }
    }
}
