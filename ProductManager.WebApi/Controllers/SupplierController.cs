using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application;
using ProductManager.Entitites;
using ProductManager.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        IApplication<Supplier> _supplier;

        private readonly IMapper _mapper;

        public SupplierController(IApplication<Supplier> supplier, IMapper mapper)
        {
            _supplier = supplier;
            _mapper = mapper;

        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_supplier.GetAll());
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetbById(int id)
        {
            var tmp = _supplier.GetById(id);
            return Ok(tmp);
        }

        [HttpPost]
        public IActionResult Save(SupplierDTO dto)
        {
            Supplier supplier = _mapper.Map<Supplier>(dto);
            return Ok(_supplier.Save(supplier));
        }

        [HttpPut]
        public IActionResult Update(int id, SupplierDTO dto)
        {
            if (id == 0 || dto == null)
                return NotFound();

            var tmp = _supplier.GetById(id);
            Supplier supplier = _mapper.Map<SupplierDTO, Supplier>(dto, tmp);
            _supplier.Save(supplier);

            return Ok(supplier);
        }

        


    }
}
