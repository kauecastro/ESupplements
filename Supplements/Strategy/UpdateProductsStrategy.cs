﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.Models;
using Supplements.DAO;

namespace Supplements.Strategy
{
    public class UpdateProductsStrategy : IStrategy
    {
        public Models.ModelResponse Process(Models.ModelDomain modelDomain)
        {
            ProductDAO productsDAO = new ProductDAO();
            return productsDAO.Update(modelDomain);
        }
    }
}