using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Address : ModelDomain
    {
        public int id { get; set; }
        public string street { get; set; }
        public string Neighborhood { get; set; }
        public string number { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
}