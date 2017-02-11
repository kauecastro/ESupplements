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
            Person person = new Person(); 
            if(modelDomain != null)
                person = (Person)modelDomain;
            if (string.IsNullOrEmpty(person.userAccount.userName) ||
                string.IsNullOrEmpty(person.userAccount.password))
                return ModelResponse;

            ModelResponse.logical = true;
            ModelResponse.text = "Ok !";

            return ModelResponse; 
        }
    }
}