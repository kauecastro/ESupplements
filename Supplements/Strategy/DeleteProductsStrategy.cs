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
            ProductsDAO productsDAO = new ProductsDAO();
            return productsDAO.Delete(modelDomain);
        }
    }
}