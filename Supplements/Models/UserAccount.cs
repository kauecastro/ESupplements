﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Models
{
    public class UserAccount : ModelDomain
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

    }
}