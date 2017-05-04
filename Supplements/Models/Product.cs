using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Product : ModelDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string EAN { get; set; }
        public int QuantityStock { get; set; }
        public float Active { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}