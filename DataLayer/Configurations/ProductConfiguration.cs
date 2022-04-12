using CoreLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductId).UseIdentityColumn();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ProductPrice).IsRequired().HasColumnType("decimal(18,2)");//toplam 18 karakter virgülden sonra 2 karakter..
            builder.HasOne(x => x.category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.ToTable("Products");
        }
    }
}
