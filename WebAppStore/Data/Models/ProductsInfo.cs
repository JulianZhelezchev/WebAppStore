using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Data.Models
{
    public class ProductsInfo
    {

        [Key]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product name is required!")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageContent { get; set; }
        public string ImageMimeType { get; set; }

        public IFormFile ImageFile { get; set; }

        [DisplayName("Buy Price")]
        [Required(ErrorMessage = "Buy price is required!")]
        [RegularExpression(@"^(?!.*[.])([0-9]{0,2}((,)[0-9]{0,2}))$",
           ErrorMessage = "The purchase price must look like this  5,00")]
        public decimal BuyPrice { get; set; }
        [DisplayName("Sell Price")]
        [Required(ErrorMessage = "Sell price is required!")]
        [RegularExpression(@"^(?!.*[.])([0-9]{0,2}((,)[0-9]{0,2}))$",
            ErrorMessage = "The sell price must look like this 5,00")]
        public decimal SellPrice { get; set; }
        [Required(ErrorMessage = "Quantity is required!")]
        [RegularExpression(@"^(0|[0-9]*)$",
          ErrorMessage = "Only positive numbers or 0")]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string ProductCode { get; set; }

        public int ProductID { get; set; }

        public virtual Categories Category { get; set; }
    }
}

