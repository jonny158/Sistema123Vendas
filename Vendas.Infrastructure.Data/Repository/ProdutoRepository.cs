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
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Produto> produtos;

        public ProdutoRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            produtos = applicationDbContext.Set<Produto>();
        }
    }
}
