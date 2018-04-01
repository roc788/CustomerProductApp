using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; } = false;

        public override string ToString()
        {
            return Name;
        }
    }
}
