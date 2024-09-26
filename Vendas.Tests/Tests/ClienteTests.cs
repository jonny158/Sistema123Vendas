using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SistemaVendasApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Interfaces;
using Vendas.Application.Services;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infrastructure.Data.Repository;

namespace Vendas.Tests.Tests
{
    public class ClienteRepositoryTests
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteAppService _clienteAppService;
        private readonly ClienteController _clienteController;
        private readonly IMapper _mapper;

        public ClienteRepositoryTests()
        {
            _clienteAppService = Substitute.For<IClienteAppService>();
            _clienteRepository = Substitute.For<IClienteRepository>();
            _mapper = Substitute.For<IMapper>();

            _clienteAppService = new ClienteAppService(_clienteRepository, _mapper);
            _clienteController = new ClienteController(_clienteAppService);
        }

        [Fact]
        public async void GetClienteExists()
        {

            var clienteId = 1;
            var clienteMock = new Cliente { Id = clienteId, Nome = "Eduardo Silva" };

            _clienteRepository.GetById(clienteId).Returns(clienteMock);
 
            var result = _clienteController.ObterClientePorId(clienteId).Result as OkObjectResult;


            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);  

            var clienteResult = result.Value as Cliente;
            clienteResult.Should().NotBeNull();
            clienteResult.Id.Should().Be(clienteId);
            clienteResult.Nome.Should().Be("Eduardo Silva");
        }

      
    }
}

