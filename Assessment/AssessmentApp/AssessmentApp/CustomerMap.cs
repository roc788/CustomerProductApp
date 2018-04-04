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
            Map(m => m.Aliases).Name("Nicknames");
            Map(m => m.ProductsConcat).Name("Products");
            Map(m => m.PriceTotal).Name("Total Price");
            Map(m => m.AveragePrice).Name("Average Price");
        }
    }
}
