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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category { CategoryId=1, CategoryName="Kalemler" },new Category { CategoryId=2, CategoryName="Silgiler"},new Category { CategoryId=3, CategoryName="Çantalar" });

        }
    }
}
