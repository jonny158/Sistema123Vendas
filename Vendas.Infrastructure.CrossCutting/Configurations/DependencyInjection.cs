
using Microsoft.Extensions.DependencyInjection;
using Vendas.Application.Interfaces;
using Vendas.Application.Services;
using Vendas.Domain.Interfaces;
using Vendas.Infrastructure.Data.Repository;

namespace Vendas.Infrastructure.CrossCutting.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void Register(IServiceCollection services)
        {
            //Configurando injeção de dependências para serviços
            services.AddTransient<IClienteAppService, ClienteAppService>();
            services.AddTransient<IProdutoAppService, ProdutoAppService>();
            services.AddTransient<IClienteAppService, ClienteAppService>();

            //Configurando injeção de dependências para respositórios
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IItemVendaRepository, ItemVendaRepository>();
            services.AddTransient<IVendaRepository, VendaRepository>();
        }
    }
}
