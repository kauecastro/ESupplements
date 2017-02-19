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
        public string quantityStock { get; set; }
        public string active { get; set; }
        public string oldPrice { get; set; }
        public string price { get; set; }
        //public List<Category> category { get; set; }
    }
}