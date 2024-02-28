using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public override string ToString()
        {
            return $"{Id}.{Name}-{Brand}-{Price}$";
        }
    }
}
