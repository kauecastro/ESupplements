using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Supplements.Models;

namespace Supplements.DAO
{
    public class UserAccountDAO : AbstractDAO, IDAO
    {
        public ModelResponse Create(Models.ModelDomain ModelDomain)
        {
            ModelResponse response = new ModelResponse() 
            {
                logical = false,
                text = "Error !"
            };

            try 
            {
                conn.Open();
            } 
            catch(MySqlException mysqlex)
            {
                
            }
            throw new NotImplementedException();
        }

        public Models.ModelResponse Read(Models.ModelDomain ModelDomain)
        {
            throw new NotImplementedException();
        }

        public Models.ModelResponse Update(Models.ModelDomain ModelDomain)
        {
            throw new NotImplementedException();
        }

        public Models.ModelResponse Delete(Models.ModelDomain ModelDomain)
        {
            throw new NotImplementedException();
        }
    }
}