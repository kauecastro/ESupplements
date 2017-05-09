using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.DAO;
using Supplements.Models;
namespace Supplements.Strategy
{
    public class ReadUserAccountStrategy : IStrategy
    {
        public Models.ModelResponse Process(Models.ModelDomain modelDomain)
        {
            UserAccountDAO userAccountDAO = new UserAccountDAO();
            return userAccountDAO.Read(modelDomain);
        }
    }
}