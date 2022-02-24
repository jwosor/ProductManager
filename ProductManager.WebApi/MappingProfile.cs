using AutoMapper;
using ProductManager.Entitites;
using ProductManager.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>();

            CreateMap<SupplierDTO, Supplier>();
        }
    }
}
