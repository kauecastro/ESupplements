using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Order : ModelDomain
    {
        public int Id { get; set; }
        public List<Product> product { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public Client Client { get; set; }
        public double totalPrice { get; set; }

    }
}