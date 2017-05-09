using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.Models;
using Supplements.DAO;

namespace Supplements.Strategy
{
    public class ReadProducts : IStrategy
    {
        public ModelResponse Process(ModelDomain modelDomain)
        {
            ProductDAO productsDAO = new ProductDAO();
            return productsDAO.Read(modelDomain);
        }
    }
}