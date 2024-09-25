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
    public class ItemVendaRepository : RepositoryBase<ItemVenda>, IItemVendaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<ItemVenda> itens;

        public ItemVendaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            itens = applicationDbContext.Set<ItemVenda>();
        }
    }
}
