using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application;
using ProductManager.Entitites;
using ProductManager.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IApplication<Product> _product;

        private readonly IMapper _mapper;

        public ProductController(IApplication<Product> product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_product.GetAll().Where(x => x.State.Equals(true)));
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetbById(int id)
        {
            var tmp = _product.GetById(id);
            return Ok(tmp);
        }


        [HttpGet]
        [Route("{pageNumber}/{numberItems}")]
        public IActionResult GetByPage(int pageNumber, int numberItems)
        {
            var oProduct = _product.GetAll().Where(x => x.State.Equals(true));

            if (oProduct != null)
            {
                oProduct = oProduct.Skip((pageNumber - 1) * numberItems)
                    .Take(numberItems)
                    .ToList();

                return Ok(oProduct);
            }

            return NotFound();
        }


        [HttpGet]
        [Route("filter")]
        public IActionResult GetByFilter(FilterProductDTO filterProductDTO)
        {
            var oProduct = _product.GetAll().Where(x => x.State.Equals(true));

            if (oProduct != null)
            {
                if (!string.IsNullOrEmpty(filterProductDTO.Description))
                    oProduct = oProduct.Where(x => x.Description.Contains(filterProductDTO.Description)).ToList();

                if (filterProductDTO.IdSupplier != 0)
                    oProduct = oProduct.Where(x => x.IdSupplier.Equals(filterProductDTO.IdSupplier)).ToList();

                if (filterProductDTO.MakingDate != null)
                    oProduct = oProduct.Where(x => x.MakingDate >= filterProductDTO.MakingDate).ToList();

                if (filterProductDTO.ValidityDate != null)
                    oProduct = oProduct.Where(x => x.MakingDate >= filterProductDTO.ValidityDate).ToList();


                if (!string.IsNullOrEmpty(filterProductDTO.OrderField))
                {
                    var propertyInfo = typeof(Product).GetProperty(filterProductDTO.OrderField);
                    
                    oProduct = filterProductDTO.OrderAscending ? oProduct.OrderBy(x => propertyInfo.GetValue(x, null)).ToList()
                                        : oProduct.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
                }
            }

            return Ok(oProduct);
        }


        [HttpPost]
        public IActionResult Save(ProductDTO dto)
        {
            Product product = _mapper.Map<Product>(dto);
            return Ok(_product.Save(product));
        }

        [HttpPut]
        public IActionResult Update(int id, ProductDTO dto)
        {
            if (id == 0 || dto == null)
                return NotFound();

            var tmp = _product.GetById(id);
            Product product = _mapper.Map<ProductDTO, Product>(dto, tmp);
            _product.Save(product);

            return Ok(product);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            var tmp = _product.GetById(id);
            if (tmp != null)
            {
                tmp.State = false;
            }
            _product.Save(tmp);

            return Ok();
        }

    }
}
