using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.DAO;
using Supplements.Models;

namespace Supplements.Strategy
{
    public class DeleteProductsStrategy : IStrategy
    {
        public ModelResponse Process(ModelDomain modelDomain)
        {
            ProductDAO productsDAO = new ProductDAO();
            return productsDAO.Delete(modelDomain);
        }
    }
}