using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.Models;
using MySql.Data.MySqlClient;
using System.Text;

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
                query = "INSERT INTO Products(name, sku, ean, quantityStock, active, oldPrice, price)" +
                    " VALUES('" + product.name + "', '" + product.sku + "', '" + product.ean + "', " +
                    product.quantityStock+", 1, "+product.oldPrice+", "+product.price+")";
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
            Product product = new Product();
            if (ModelDomain == null)
                throw new Exception("Paramerer is null !");
            product = (Product)ModelDomain;
            ModelResponse response = new ModelResponse()
            {
                logical = false,
                text = "Error !",
                Domain = new List<ModelDomain>()
            };
            StringBuilder query = new StringBuilder("SELECT * FROM Products ");
            if (product.id > 0)
                query.Append("WHERE id_products = " + product.id);
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query.ToString(), conn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    response.Domain.Add(new Product()
                    {
                        id = Convert.ToInt32(dataReader["id_products"]),
                        name = dataReader["name"].ToString(),
                        sku = dataReader["sku"].ToString(),
                        ean = dataReader["ean"].ToString(),
                        quantityStock = (int)dataReader["quantityStock"],
                        active = (float)dataReader["active"],
                        oldPrice = (decimal)dataReader["oldPrice"],
                        price = (decimal)dataReader["price"]
                    });
                }
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