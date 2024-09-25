using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Application.Models
{
    public class VendaViewModel
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }


        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }

        public decimal ValorTotal { get; set; }
        public string Filial { get; set; }
        public List<ItemVendaViewModel> Itens { get; set; }
        public bool Cancelada { get; set; }
    }
}
