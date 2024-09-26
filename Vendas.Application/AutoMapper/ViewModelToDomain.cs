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
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<ItemVendaViewModel, ItemVenda>();
            CreateMap<VendaViewModel, Venda>();

        }
    }
}
