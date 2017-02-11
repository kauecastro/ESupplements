using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Product : ModelDomain
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string ean { get; set; }
        public int quantityinstock { get; set; }
        public bool active { get; set; }
        public double oldPrice { get; set; }
        public double price { get; set; }
    }
}