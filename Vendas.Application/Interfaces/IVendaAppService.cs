using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Models;

namespace Vendas.Application.Interfaces
{
    public interface IVendaAppService
    {
        Task<VendaViewModel> GetById(int id);
        Task CreateVenda(VendaViewModel venda);
        Task UpdateVenda(VendaViewModel venda);
        Task CancelarVenda(int id);
        Task CancelarItemVenda(int idItemVenda);
        Task<IEnumerable<VendaViewModel>> ListVendas();
    }
}
