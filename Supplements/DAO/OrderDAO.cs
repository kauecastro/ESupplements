using Supplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Supplements.DAO
{
    public class OrderDAO : IDAO
    {
        public Models.ModelResponse Create(Models.ModelDomain ModelDomain)
        {
            ModelResponse response = new ModelResponse();
            Order order = (Order)ModelDomain;
            try
            {
                using (var context = new EntityContext())
                {
                    context.Orders.Add(order);
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

        public Models.ModelResponse Read(Models.ModelDomain ModelDomain)
        {
            Order order = (Order)ModelDomain;
            ModelResponse response = new ModelResponse() { Domain = new List<ModelDomain>() };
            try
            {
                using (var context = new EntityContext())
                {
                    var orderEF = context.Orders.Include(q => q.StatusOrder)
                        .Include(q => q.product)
                        .Include(q => q.Client).ToList();
                    if (order.Id > 0)
                        orderEF = orderEF.Where(q => q.Id == order.Id).ToList();

                    foreach (var p in orderEF)
                    {
                        Client client = new Client()
                        {
                            Address = p.Client.Address,
                            Nome = p.Client.Nome,
                            Id = p.Client.Id,
                            CPF = p.Client.CPF
                        };
                        List<Product> products = new List<Product>();
                        p.product.ForEach(q => products.Add(new Product() {
                            Id = q.Id,
                            Name = q.Name,
                            EAN = q.EAN,
                            Active = q.Active,
                            OldPrice = q.OldPrice,
                            Price = q.Price,
                            QuantityStock = q.QuantityStock,
                            SKU = q.SKU
                        }));
                        StatusOrder statusOrder = new StatusOrder()
                        {
                            Id = p.StatusOrder.Id,
                            Description = p.StatusOrder.Description
                        };
                        response.Domain.Add(new Order()
                        {
                            Id = p.Id,
                            product = products,
                            StatusOrder = statusOrder,
                            Client = client,
                            totalPrice = p.totalPrice,
                        });
                    }
                }
                response.text = response.Domain.Count > 0 ? "OK!" : "There are no results !";
                response.logical = (response.Domain.Count > 0);
            }
            catch (Exception ex)
            {
                response.text = ex.ToString();
                return response;
            }
            return response;
        }

        public Models.ModelResponse Update(Models.ModelDomain ModelDomain)
        {
            ModelResponse response = new ModelResponse();
            Order order = (Order)ModelDomain;
            try
            {
                using (var context = new EntityContext())
                {

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

        public Models.ModelResponse Delete(Models.ModelDomain ModelDomain)
        {
            Order order = (Order)ModelDomain;
            ModelResponse response = new ModelResponse();
            try
            {
                using (var context = new EntityContext())
                {
                    var p = context.Orders.FirstOrDefault(q => q.Id == order.Id);
                    context.Orders.Remove(p);
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
    }
}