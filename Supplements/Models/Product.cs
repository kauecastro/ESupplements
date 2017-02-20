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
        public int quantityStock { get; set; }
        public float active { get; set; }
        public decimal oldPrice { get; set; }
        public decimal price { get; set; }
        //public List<Category> category { get; set; }
    }
}