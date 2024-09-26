
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Application.Models;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace SistemaVendasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost("CriarCliente")]
        public async Task<IActionResult> CriarCliente([FromBody] ClienteViewModel cliente)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _clienteAppService.CreateCliente(cliente);
            
            return CreatedAtAction(nameof(CriarCliente), new { id = cliente.Id }, cliente);
        }

        [HttpGet("ObterClientePorId/{id}")]
        public async Task<IActionResult> ObterClientePorId(int id)
        {
            var cliente = await _clienteAppService.GetById(id);
            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpGet("ListarClientes")]
        public async Task<IActionResult> ListarClientes()
        {
            var Lista = await _clienteAppService.ListClientes();
            if (Lista == null) return NotFound();

            return Ok(Lista);
        }

        [HttpPut("AtualizarCliente")]
        public async Task<IActionResult> AtualizarCliente([FromBody] ClienteViewModel cliente)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _clienteAppService.UpdateCliente(cliente);
           
            return Ok(cliente);
        }

        [HttpDelete("RemoveCliente/{id}")]
        public async Task<IActionResult> RemoveCliente(int id)
        {
            await _clienteAppService.RemoveCliente(id);
          
            return Ok();
        }
    }
}
