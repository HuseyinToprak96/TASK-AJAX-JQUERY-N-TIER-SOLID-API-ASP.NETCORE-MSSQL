using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products =await _service.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
           await _service.AddAsync(product);
            return Ok(CustomResponseDto<Product>.Success(201, product));
        }
        [HttpDelete] 
        public IActionResult Delete(int id)
        {
           _service.Remove(id);
            return Ok();
        }
    }
}
