using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public sealed class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Map(m => m.Name).Index(0);
            Map(m => m.Alias).Index(1);
            Map(m => m.ProductsConcat).Name("Products");
            Map(m => m.PriceTotal).Name("Price Total");
        }
    }
}
