using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
   public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductCategoryDto>().ForMember(x => x.CategoryName, src => src.MapFrom(x => x.category.CategoryName));
        }
    }
}
