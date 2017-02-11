﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Category> Category { get; set; }
    }
}