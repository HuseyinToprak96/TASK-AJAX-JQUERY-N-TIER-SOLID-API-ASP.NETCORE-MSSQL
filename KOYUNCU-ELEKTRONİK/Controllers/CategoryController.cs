using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using CoreLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOYUNCU_ELEKTRONİK.Controllers
{
    public class CategoryController : Controller
    {
    private readonly IMapper _mapper;
    private readonly IService<Category> _CategoryService;
    public CategoryController(IMapper mapper, IService<Category> categoryService)
    {
        _mapper = mapper;
        _CategoryService = categoryService;
    }
    public async Task<IActionResult> Categories()
        {
            var categories =await _CategoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            return View(categoriesDto);
        }
    }
}
