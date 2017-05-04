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
        #region .: Products CRUD :. 
        public ModelResponse Create(ModelDomain ModelDomain)
        {
            ModelResponse response = new ModelResponse();
            Product product = (Product)ModelDomain;
            try
            {
                using(var context = new EntityContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                response.logical = true;
                response.text = "OK !";
            }
            catch (Exception ex)
            {
                response.text = ex.ToString();
                return response;
            }
            return response;
        }

        public ModelResponse Read(Models.ModelDomain ModelDomain)
        {
            Product product = (Product)ModelDomain;
            ModelResponse response = new ModelResponse() { Domain = new List<ModelDomain>() };    
            try
            {

                var products = from p in context.Products select p;
                    if (product.Id > 0)
                        products = products.Where(q => q.Id == product.Id);
                    foreach(var p in products)
                    {
                        response.Domain.Add(new Product()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            EAN = p.EAN,
                            Active = p.Active,
                            OldPrice = p.OldPrice,
                            Price = p.Price,
                            QuantityStock = p.QuantityStock,
                            SKU = p.SKU,
                        });
                    }
                
                response.text = "OK!";
                response.logical = true;
            }
            catch (Exception ex)
            {
                response.text = ex.ToString();
                return response;
            }
            return response;
        }

        public ModelResponse Update(Models.ModelDomain ModelDomain)
        {
            ModelResponse response = new ModelResponse();
            Product product = (Product)ModelDomain;
            try
            {
                using(var context = new EntityContext())
                {
                    var p = context.Products.FirstOrDefault(q => q.Id == product.Id);
                    p.Name = product.Name;
                    p.EAN = product.EAN;
                    p.Active = product.Active;
                    p.OldPrice = product.OldPrice;
                    p.Price = product.Price;
                    p.QuantityStock = product.QuantityStock;
                    p.SKU = product.SKU;
                    context.SaveChanges();
                }                
                response.text = "OK!";
                response.logical = true;
            }
            catch (Exception ex)
            {
                response.text = ex.ToString();
                return response;
            }
            return response;
        }

        public ModelResponse Delete(Models.ModelDomain ModelDomain)
        {
            Product product = (Product)ModelDomain;
            ModelResponse response = new ModelResponse();
            try
            {
                using(var context = new EntityContext())
                {
                    var p = context.Products.FirstOrDefault(q => q.Id == product.Id);
                    context.Products.Remove(p);
                    context.SaveChanges();
                }
                response.logical = true;
                response.text = "OK !";
            }
            catch (Exception ex)
            {
                response.text = ex.ToString();
                return response;
            }
            return response;
        }
        #endregion
    }
}