using CoreLayer.Dtos;
using CoreLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
   public interface IProductService:IService<Product>
    {
        Task<List<ProductCategoryDto>> getProductAsync();
        ProductDto Remove(int id);
    }
}
