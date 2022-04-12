using AutoMapper;
using CoreLayer.Entitys;
using CoreLayer.Interfaces;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> getProductAsync()
        {
            var urunler =await _context.Products.Include(x => x.category).ToListAsync();
            return urunler;
        }

        public Product Remove(int id)
        {
            var product= _context.Products.Find(id);
            _context.Products.Remove(product);
            return product;
        }
    }
}
