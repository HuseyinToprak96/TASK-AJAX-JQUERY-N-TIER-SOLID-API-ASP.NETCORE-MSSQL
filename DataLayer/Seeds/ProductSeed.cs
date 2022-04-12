using CoreLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            new Product
            {
                 ProductId=1, ProductName="Kurşun Kalemler", CategoryId=1
            },
            new Product { 
            ProductId=2, ProductName="Tükenmez Kalem", CategoryId=1
            },
              new Product
              {
                  ProductId = 3,
                  ProductName = "Kokulu Silgi",
                  CategoryId = 2
              },
            new Product
            {
                ProductId = 4,
                ProductName = "Kokusuz Silgi",
                CategoryId = 2
            },
              new Product
              {
                  ProductId = 5,
                  ProductName = "Sırt Çantası",
                  CategoryId = 3
              },
            new Product
            {
                ProductId = 6,
                ProductName = "Beslenme Çantası",
                CategoryId = 3
            }
            );
        }
    }
}
