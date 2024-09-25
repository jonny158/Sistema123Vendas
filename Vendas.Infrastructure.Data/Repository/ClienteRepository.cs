using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infrastructure.Data.Context;

namespace Vendas.Infrastructure.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Cliente> clientes;

        public ClienteRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            clientes = applicationDbContext.Set<Cliente>();
        }
    }
}
