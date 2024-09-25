using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Exceptions;
using Vendas.Application.Interfaces;
using Vendas.Application.Models;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
    public class VendaAppService : IVendaAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaRepository _vendaRepository;
        private readonly IItemVendaRepository _itemVendaRepository;
        private readonly IMapper _mapper;

        public VendaAppService(IClienteRepository clienteRepository, 
            IProdutoRepository produtoRepository, 
            IVendaRepository vendaRepository, 
            IItemVendaRepository itemVendaRepository, 
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _vendaRepository = vendaRepository;
            _itemVendaRepository = itemVendaRepository;
            _mapper = mapper;
        }

        public async Task CreateVenda(VendaViewModel venda)
        {
            // Desnormalizando o nome do cliente
            var cliente = _clienteRepository.GetById(venda.ClienteId);
            if (cliente == null) throw new NotFoundException($"Cliente com ID {venda.ClienteId} não foi encontrada.");

            venda.ClienteId = cliente.Id;
            venda.ClienteNome = cliente.Nome;

            var vendaDB = _mapper.Map<VendaViewModel, Venda>(venda);
            _vendaRepository.Add(vendaDB);
            _vendaRepository.SaveChanges();

            // Desnormalizando o nome dos produtos
            foreach (var item in venda.Itens)
            {
                var produto = _produtoRepository.GetById(item.ProdutoId);
                item.ProdutoId = produto.Id;
                item.ProdutoNome = produto.Nome;
                item.VendaId = vendaDB.Id;

                _itemVendaRepository.Add(_mapper.Map<ItemVendaViewModel, ItemVenda>(item));
                _itemVendaRepository.SaveChanges();
            }

            Log.Information("Venda criada: {@Venda}", venda);

        }

        public async Task<VendaViewModel> GetById(int id)
        {
            return _mapper.Map<Venda, VendaViewModel>(_vendaRepository.GetById(id));
        }

        public Task<IEnumerable<VendaViewModel>> ListVendas()
        {
            var listVendas = _vendaRepository.GetAll().ToList();
            return Task.FromResult(_mapper.Map<IEnumerable<Venda>, IEnumerable<VendaViewModel>>(listVendas));
        }

        public async Task UpdateVenda(VendaViewModel venda)
        {
            _vendaRepository.Update(_mapper.Map<VendaViewModel, Venda>(venda));
            _vendaRepository.SaveChanges();

            Log.Information("Venda atualizada: {@Venda}", venda);
        }

        public async Task CancelarVenda(int id)
        {
            var venda = _vendaRepository.GetById(id);
            if (venda == null) throw new NotFoundException($"Venda com ID {id} não foi encontrada.");
            venda.Cancelada = true;

            _vendaRepository.Update(venda);
            _vendaRepository.SaveChanges();

            Log.Information("Venda cancelada: {@Venda}", venda);
        }

        public async Task CancelarItemVenda(int idItemVenda)
        {
            var itemVenda = _itemVendaRepository.GetById(idItemVenda);
            if (itemVenda == null) throw new NotFoundException($"Item Venda com ID {idItemVenda} não foi encontrada.");
            itemVenda.Cancelado = true;

            _itemVendaRepository.Update(itemVenda);
            _vendaRepository.SaveChanges();

            Log.Information("Item cancelado: {@itemVenda}", itemVenda);
        }

    }
}
