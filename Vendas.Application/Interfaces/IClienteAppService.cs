using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Models;

namespace Vendas.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<ClienteViewModel> GetById(int id);
        Task CreateCliente(ClienteViewModel cliente);
        Task UpdateCliente(ClienteViewModel cliente);
        Task RemoveCliente(int id);
        Task<IEnumerable<ClienteViewModel>> ListClientes();
    }
}
