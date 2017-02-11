using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Person : ModelDomain
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string CPF { get; set; }
        public Address address { get; set; }
        public UserAccount userAccount { get; set; }
    }
}