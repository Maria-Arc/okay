using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.eCommerce.DTO;
using Library.eCommerce.Services;
using Library.eCommerce.Models;

namespace Library.eCommerce.Models
{
    public class Item
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int? Quantity { get; set; }
        public double Cost { get; set; }



        public override string ToString()
        {
            return $"{Product} Quantity:{Quantity}";
        }

        public string Display
        {
            get
            {
                return $"{Product?.Display ?? string.Empty} {Quantity}";
            }

        }

        public Item()
        {
            Product = new ProductDTO();

        }

        public Item(Item i)
        {
            Product = new ProductDTO(i.Product);
            Quantity = i.Quantity;
            Id = i.Id;
            Cost = i.Cost;


        }
    }
}