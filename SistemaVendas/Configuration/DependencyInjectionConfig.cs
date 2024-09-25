using Microsoft.Extensions.DependencyInjection;
using Vendas.Application.AutoMapper;

namespace SistemaVendasApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //// Registrando configurações de elementos do projeto em geral
            services.AddAutoMapper(typeof(DomainToViewModel), typeof(ViewModelToDomain));

            //Registrando configurações de elementos da API
            //services.AddSingleton<IJwtUtils, JwtUtils>();

            //Registrando configurações de serviços e respositórios
            Vendas.Infrastructure.CrossCutting.Configurations.DependencyInjectionConfig.Register(services);
        }
    }
}
