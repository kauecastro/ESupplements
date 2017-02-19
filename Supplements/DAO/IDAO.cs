using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supplements.Models;

namespace Supplements.DAO
{
    public interface IDAO 
    {
        ModelResponse Create(ModelDomain ModelDomain);
        ModelResponse Read(ModelDomain ModelDomain);
        ModelResponse Update(ModelDomain ModelDomain);
        ModelResponse Delete(ModelDomain ModelDomain);
    }
}
