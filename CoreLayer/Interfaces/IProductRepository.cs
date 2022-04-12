using CoreLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces
{
   public interface IProductRepository:IRepository<Product>
    {
        Task<List<Product>> getProductAsync();
        Product Remove(int id);
    }
}
