using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.Models;
using Supplements.Strategy;
namespace Supplements.Facade
{
    public class Facade
    {
        
        public Dictionary<string, List<IStrategy>> StrategyDictionary = new Dictionary<string, List<IStrategy>>();

        public Facade()
        {
            List<IStrategy> Strategies = new List<IStrategy>();
            Strategies.Add(new ValidateProductsFieldsStrategy());
            StrategyDictionary.Add(new Product().GetType().Name.ToString() + "Create", Strategies);
            Strategies = new List<IStrategy>();
        }

        public ModelResponse Create(ModelDomain domain)
        {
            ModelResponse ModelResponse = new ModelResponse();
            foreach (var strategy in StrategyDictionary[domain.GetType().Name.ToString() + "Create"]) 
            {
                ModelResponse = strategy.Process(domain);
                if(ModelResponse.logical == false)
                    return ModelResponse;
                return ModelResponse;
            }
            return ModelResponse;
    
        }

        public ModelResponse Read(ModelDomain domain)
        {
            return new ModelResponse();
        }

        public ModelResponse Update(ModelDomain domain)
        {
            return new ModelResponse();
        }

        public ModelResponse delete(ModelDomain domain)
        {
            return new ModelResponse();
        }
    }
}