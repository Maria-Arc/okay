using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.DTO;

namespace Library.eCommerce.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        public string LegacyProperty1 { get; set; }
        public string LegacyProperty2 { get; set; }
        public string LegacyProperty3 { get; set; }
        public string LegacyProperty4 { get; set; }
        public string LegacyProperty5 { get; set; }
        public string LegacyProperty6 { get; set; }
        public string? Display
        {
            get
            {
                return $"{Id}. {Name} ${Price}  #{Amount} ";
            }
        }
        public Product()
        {
            Name = string.Empty;
        }

        public Product(Product p)
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

        public Product(ProductDTO p)
        {
            Name = p.Name;
            Id = p.Id;
            LegacyProperty1 = string.Empty;
        }
    }
}

/*public int Id { get; set; }

public string Name { get; set; } //called a property, this is the exact same as what is commented out above
public int Amount { get; set; }
public string? Display
{
    get
    {
        return $"{Id}. {Name} {Amount}";
    }
}
public Product()
{
    Name = string.Empty;
}

public Product(Product p)
{
   Name = p.Name;
   Id = p.Id;
   Amount = p.Amount;
}

public override string ToString()
{
    return Display ?? string.Empty;//if Display is null, it forces string.Empty
}*/
