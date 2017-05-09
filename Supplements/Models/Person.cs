using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Person : ModelDomain
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Address Address { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}