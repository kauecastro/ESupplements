using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class ModelResponse : Supplements
    {
        public List<ModelDomain> Domain { get; set; }
        public string text { get; set; }
        public Boolean logical { get; set; }
    }
}