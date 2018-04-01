using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class Customer
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Product> Products { get; set; }
        public string ProductsConcat { get; set; }
        public decimal PriceTotal { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
