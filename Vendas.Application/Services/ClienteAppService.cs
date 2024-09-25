using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;

using Vendas.Application.Interfaces;
using Vendas.Application.Models;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteAppService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task CreateCliente(ClienteViewModel cliente)
        {
            _clienteRepository.Add(new Cliente() { Id = cliente.Id, Nome = cliente.Nome });
            _clienteRepository.SaveChanges();

            Log.Information("Cliente criado: {@Cliente}", cliente);
        }

        public async Task<ClienteViewModel> GetById(int id)
        {
            return _mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.GetById(id));
        }


        public async Task UpdateCliente(ClienteViewModel cliente)
        {
            _clienteRepository.Update(_mapper.Map<ClienteViewModel, Cliente>(cliente));
            _clienteRepository.SaveChanges();

            Log.Information("Cliente atualizado: {@Cliente}", cliente);
        }

        public Task<IEnumerable<ClienteViewModel>> ListClientes()
        {
            var listClientes = _clienteRepository.GetAll().ToList();
            return Task.FromResult(_mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(listClientes));
        }

        public async Task RemoveCliente(int id)
        {
            _clienteRepository.Remove(id);
            _clienteRepository.SaveChanges();

            Log.Information("Cliente removido: {@IdCliente}", id);
        }


    }
}
