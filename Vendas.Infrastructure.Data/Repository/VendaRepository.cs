using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infrastructure.Data.Context;

namespace Vendas.Infrastructure.Data.Repository
{
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Venda> vendas;

        public VendaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            vendas = applicationDbContext.Set<Venda>();
        }
    }
}
