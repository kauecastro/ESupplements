using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.Models;
using Supplements.DAO;

namespace Supplements.Strategy
{
    public class SaveProducts : IStrategy
    {
        public ModelResponse Process(ModelDomain modelDomain)
        {
            ProductsDAO productsDAO = new ProductsDAO();
            return productsDAO.Create(modelDomain);
        }
    }
}