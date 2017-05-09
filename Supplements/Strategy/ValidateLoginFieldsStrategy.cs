using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.Models;
namespace Supplements.Strategy
{
    public class ValidateLoginFieldsStrategy : IStrategy
    {
        public ModelResponse Process(ModelDomain modelDomain)
        {
            ModelResponse ModelResponse = new ModelResponse()
            {
                logical = false,
                text = "There empty fields !"
            };
            UserAccount userAccount = new UserAccount(); 
            if(modelDomain != null)
                userAccount = (UserAccount)modelDomain;
            if (string.IsNullOrEmpty(userAccount.UserName) ||
                string.IsNullOrEmpty(userAccount.Password))
                return ModelResponse;

            ModelResponse.logical = true;
            ModelResponse.text = "Ok !";

            return ModelResponse; 
        }
    }
}