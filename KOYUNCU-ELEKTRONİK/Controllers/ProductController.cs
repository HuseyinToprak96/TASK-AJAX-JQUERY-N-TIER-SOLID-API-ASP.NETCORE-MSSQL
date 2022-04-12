using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOYUNCU_ELEKTRONİK.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly IService<Category> _CategoryService;
        public ProductController(IProductService service, IMapper mapper, IService<Category> categoryService)
        {
            _service = service;
            _mapper = mapper;
            _CategoryService = categoryService;
        }
        public async Task<IActionResult> ProductList()
        {
            var Categories =await _CategoryService.GetAllAsync();
            TempData["Categories"] = Categories.ToList();
          var products=  await _service.getProductAsync();
            return View(products);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result = _service.Remove(id);
            return Json(result.ProductName);
        }
        [HttpPost]
        public JsonResult Add(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            _service.AddAsync(product);
            return Json(productAddDto.ProductName);
        }
    }
}
