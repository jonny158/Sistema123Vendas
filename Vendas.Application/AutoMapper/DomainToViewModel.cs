using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Models;
using Vendas.Domain.Entities;

namespace Vendas.Application.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<ItemVenda, ItemVendaViewModel>();
            CreateMap<Venda, VendaViewModel>();

        }
    }
}
