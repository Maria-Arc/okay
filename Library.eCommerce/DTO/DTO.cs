using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Models;
//using Spring2025_Samples.Models;

namespace Library.eCommerce.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public int Amount { get; set; }

        public string? Display
        {
            get
            {
                return $"{Id}. {Name} ${Price}  #";
            }
        }
        public ProductDTO()
        {
            Name = string.Empty;
        }

        public ProductDTO(Product p)
        {
            Name = p.Name;
            Id = p.Id;
        }
        public ProductDTO(ProductDTO p)
        {
            Name = p.Name;
            Id = p.Id;
            Price = p.Price;
            Amount = p.Amount;
        }
        public override string ToString()
        {
            return Display ?? string.Empty;
        }
    }
}