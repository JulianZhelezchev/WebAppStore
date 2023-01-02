using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppStore.Data.Models;

namespace WebAppStore.Models
{
    public class CategoryDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

         public virtual ICollection<ProductsInfo> Products { get; set; }
    }

}
