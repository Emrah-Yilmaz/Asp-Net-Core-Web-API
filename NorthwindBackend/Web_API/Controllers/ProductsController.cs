using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
      

        public ProductsController(IProductService productService)
        {
         _productService = productService;
            
        }


        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);    
            }
        }
        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            
                return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else

                return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Products product)
        {
            var result = _productService.Add(product);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Products product)
        {
            var result = _productService.Update(product);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Products product)
        {
            var result = _productService.Delete(product);
            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            return BadRequest(result.Message);
        }
    }
}
