using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }

        public int ClienteId { get; set; } // External Identity
        public string ClienteNome { get; set; } 

        public decimal ValorTotal { get; set; }
        public string Filial { get; set; }
        public bool Cancelada { get; set; }
    }
}
