using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Order
    {
        public int id { get; set; }
        public List<Product> product { get; set; }
        public string Status { get; set; }
        public double totalPrice { get; set; }
    }
}