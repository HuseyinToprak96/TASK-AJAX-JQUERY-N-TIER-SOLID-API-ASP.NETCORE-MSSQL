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
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Category> _service;
        public CategoryController(IMapper mapper, IService<Category> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories =await _service.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            return Ok(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDto));
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _service.AddAsync(category);
            return Ok(CustomResponseDto<Category>.Success(201, category));
        }
        //[HttpGet]
        //public async Task<IActionResult> 
        //içinde ürün olmayan categoryler
        //içinde en çok ürün olan categoryler
        //kategori silme
    }
}
