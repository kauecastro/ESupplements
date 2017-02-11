using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supplements.Models;

namespace Supplements.Strategy
{
    interface IStrategy
    {
        public ModelResponse Process(ModelDomain modelDomain);
    }
}
