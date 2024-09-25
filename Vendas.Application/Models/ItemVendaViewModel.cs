using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Application.Models
{
    public class ItemVendaViewModel
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }  // External Identity
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal => (Quantidade * ValorUnitario) - Desconto;
        public bool Cancelado { get; set; } = false;

        public int VendaId { get; set; }
    }
}
