using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
   public class ProductAddDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
