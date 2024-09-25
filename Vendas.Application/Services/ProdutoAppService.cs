using AutoMapper;
using Serilog;
using Vendas.Application.Interfaces;
using Vendas.Application.Models;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public Task CreateProduto(ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoViewModel>> ListProdutos()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduto(ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProduto(int id)
        {
            throw new NotImplementedException();
        }

    }
}
