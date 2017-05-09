using Supplements.DAO;
using Supplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Supplements.Strategy
{
    public class TryGetUserStrategy : IStrategy
    {
        public Models.ModelResponse Process(Models.ModelDomain modelDomain)
        {
            ModelResponse ModelResponse = new ModelResponse()
            {
                logical = false,
                text = "There empty fields !"
            };

            ClientDAO client = new ClientDAO();
            UserAccount userAccount = (UserAccount)modelDomain;
            Person person = new Client() { UserAccount = userAccount};
            ModelResponse = client.Read(person);
            if (ModelResponse.Domain.Count > 0)
                return ModelResponse;
            //Try get employee

            return ModelResponse; 
        }
    }
}