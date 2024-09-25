using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Models;

namespace Vendas.Application.Interfaces
{
    public interface IProdutoAppService
    {
        Task<ProdutoViewModel> GetById(int id);
        Task CreateProduto(ProdutoViewModel produto);
        Task UpdateProduto(ProdutoViewModel produto);
        Task RemoveProduto(int id);
        Task<IEnumerable<ProdutoViewModel>> ListProdutos();
    }
}
