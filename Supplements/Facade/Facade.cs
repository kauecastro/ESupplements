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
            Strategies.Add(new CreateProducts());
            StrategyDictionary.Add(new Product().GetType().Name.ToString() + "Create", Strategies);
            Strategies = new List<IStrategy>();
            Strategies.Add(new ReadProducts());
            StrategyDictionary.Add(new Product().GetType().Name.ToString() + "Read", Strategies);
            Strategies = new List<IStrategy>();
            Strategies.Add(new UpdateProductsStrategy());
            StrategyDictionary.Add(new Product().GetType().Name.ToString() + "Update", Strategies);
        }

        public ModelResponse Create(ModelDomain domain)
        {
            ModelResponse ModelResponse = new ModelResponse();
            foreach (var strategy in StrategyDictionary[domain.GetType().Name.ToString() + "Create"]) 
            {
                ModelResponse = strategy.Process(domain);
                if(ModelResponse.logical == false)
                    return ModelResponse;
            }
            return ModelResponse;
        }

        public ModelResponse Read(ModelDomain domain)
        {
            ModelResponse ModelResponse = new ModelResponse();
            foreach (var strategy in StrategyDictionary[domain.GetType().Name.ToString() + "Read"])
            {
                ModelResponse = strategy.Process(domain);
                if (ModelResponse.logical == false)
                    return ModelResponse;
            }
            return ModelResponse;
        }

        public ModelResponse Update(ModelDomain domain)
        {
            ModelResponse ModelResponse = new ModelResponse();
            foreach (var strategy in StrategyDictionary[domain.GetType().Name.ToString() + "Update"])
            {
                ModelResponse = strategy.Process(domain);
                if (ModelResponse.logical == false)
                    return ModelResponse;
            }
            return ModelResponse;

        }

        public ModelResponse delete(ModelDomain domain)
        {
            return new ModelResponse();
        }
    }
}