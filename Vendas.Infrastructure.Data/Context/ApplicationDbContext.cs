using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Data.Configuration;

namespace Vendas.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<ItemVenda> ItemVendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar configurações de todas as entidades separadas na pasta de configurations do projeto infrastructure
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new VendaConfiguration());
            modelBuilder.ApplyConfiguration(new ItemVendaConfiguration());

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nome = "Eduardo Silva" },
                new Cliente { Id = 2, Nome = "Carlos Oliveira" }
            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "Arroz" },
                new Produto { Id = 2, Nome = "Feijao" },
                new Produto { Id = 3, Nome = "Marcarrao" },
                new Produto { Id = 4, Nome = "Carne" }
            );
        }
    }
}
