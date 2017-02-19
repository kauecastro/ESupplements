using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Industry : ModelDomain
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Department> Department { get; set;  }
    }
}