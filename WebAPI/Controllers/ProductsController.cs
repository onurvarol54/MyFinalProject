using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled = Gevşek bağlılık(tr)
        //Naming convention = İsmlendirme stantartı(tr)
        //IoS Container -- Inversion of Control Bellek kontrol(tr) ** Bellekte new product tutar
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcategorybyid")]
        public IActionResult GetAllByCategoryId(int id)
        {
            var result = _productService.GetAllByCategoryId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("transaction")]
        public IActionResult TransactionOperration(Product product)
        {
            var result = _productService.TransactionalOperation(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
