using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class ModelResponse : Supplements
    {
        public ModelDomain Domain { get; set; }
        public string text { get; set; }
        public string logical { get; set; }
    }
}