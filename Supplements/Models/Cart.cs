using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Cart
    {
        public int id { get; set; }
        public List<Product> product { get; set; }
    }
}