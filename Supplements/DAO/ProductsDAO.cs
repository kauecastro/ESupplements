using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.Models;
using MySql.Data.MySqlClient;

namespace Supplements.DAO
{
    public class ProductsDAO : AbstractDAO, IDAO
    {
        public ModelResponse Create(ModelDomain ModelDomain)
        {
            Product product = new Product();
            if (ModelDomain == null)
                throw new Exception("Paramerer is null !");
            product = (Product)ModelDomain;
            string query = string.Empty;
            ModelResponse response = new ModelResponse()
            {
                logical = false,
                text = "Error !"
            };
            try
            {
                conn.Open();
                query = "INSERT INTO products VALUES('"+product.name+"', '"+product.sku+"', '"+product.ean+"', '"+
                    product.quantityStock+"', '"+product.active+"', "+product.oldPrice+"', "+product.price+")";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
                response.logical = true;
                response.text = "OK !";
            }
            catch (MySqlException mysqlex)
            {
                response.text = mysqlex.ToString();
                return response;
            }
            catch (Exception ex)
            {
                response.text = ex.ToString();
                return response;
            }
            conn.Close();
            return response;
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