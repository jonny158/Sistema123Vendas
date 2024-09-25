using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Application.Models;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;


namespace SistemaVendasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaAppService _vendaAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly IProdutoAppService _produtoAppService;

        public VendasController(IVendaAppService vendaAppService, IClienteAppService clienteAppService, IProdutoAppService produtoAppService)
        {
            _vendaAppService = vendaAppService;
            _clienteAppService = clienteAppService;
            _produtoAppService = produtoAppService;
        }

        [HttpPost("CriarVenda")]
        public async Task<IActionResult> CriarVenda([FromBody] VendaViewModel venda)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _vendaAppService.CreateVenda(venda);

            return CreatedAtAction(nameof(CriarVenda), new { id = venda.Id }, venda);
        }

        [HttpGet("ObterVendaPorId/{id}")]
        public async Task<IActionResult> ObterVendaPorId(int id)
        {
            var venda = await _vendaAppService.GetById(id);
            if (venda == null) return NotFound();

            return Ok(venda);
        }

        [HttpPut("AtualizarVenda")]
        public async Task<IActionResult> AtualizarVenda([FromBody] VendaViewModel venda)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _vendaAppService.UpdateVenda(venda);

            return Ok(venda);
        }
         
        [HttpPut("CancelarVenda/{idVenda}")]
        public async Task<IActionResult> CancelarVenda(int idVenda)
        {
            await _vendaAppService.CancelarVenda(idVenda);

            return Ok();
        }

        [HttpPut("CancelarItemVenda/{idItemVenda}")]
        public async Task<IActionResult> CancelarItemVenda(int idItemVenda)
        {
            await _vendaAppService.CancelarItemVenda(idItemVenda);

            return Ok();
        }
    }
}

