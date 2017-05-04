using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.Models;

namespace Supplements.Strategy
{
    public class ValidateProductsFieldsStrategy : IStrategy
    {
        public ModelResponse Process(ModelDomain modelDomain)
        {
            ModelResponse ModelResponse = new ModelResponse()
            {
                logical = false,
                text = "There empty fields !"
            };
            Product product = new Product();
            if (modelDomain != null)
                product = (Product)modelDomain;
            if (string.IsNullOrEmpty(product.Name) ||
                string.IsNullOrEmpty(product.SKU))
                return ModelResponse;

            ModelResponse.logical = true;
            ModelResponse.text = "Ok !";

            return ModelResponse; 
        }
    }
}