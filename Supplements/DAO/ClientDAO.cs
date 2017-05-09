using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Supplements.Models;
using System.Data.Entity;

namespace Supplements.DAO
{
    public class ClientDAO : IDAO
    {
        public Models.ModelResponse Create(Models.ModelDomain ModelDomain)
        {
            ModelResponse response = new ModelResponse();
            Client client = (Client)ModelDomain;
            try
            {
                using (var context = new EntityContext())
                {
                    context.Clients.Add(client);
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
            Client client = (Client)ModelDomain;
            ModelResponse response = new ModelResponse() { Domain = new List<ModelDomain>() };
            try
            {
                using (var context = new EntityContext())
                {
                    var clients = context.Clients.Include(q => q.UserAccount).ToList();
                    if (client.Id > 0)
                        clients = clients.Where(q => q.Id == client.Id).ToList();
                    if (client.UserAccount.UserName != null && !string.IsNullOrEmpty(client.UserAccount.UserName))
                        clients = clients.Where(q => q.UserAccount.UserName == client.UserAccount.UserName).ToList();
                    if (client.UserAccount.Password != null && !string.IsNullOrEmpty(client.UserAccount.Password))
                        clients = clients.Where(q => q.UserAccount.Password == client.UserAccount.Password).ToList();

                    foreach (var p in clients)
                    {
                        UserAccount userAccount = new UserAccount()
                        {
                            Id = p.UserAccount.Id,
                            UserName = p.UserAccount.UserName,
                            Password = p.UserAccount.Password,
                            AccountType = p.UserAccount.AccountType
                        };
                        response.Domain.Add(new Client()
                        {
                            Address = p.Address,
                            Nome = p.Nome,
                            Id = p.Id,
                            CPF = p.CPF,
                            UserAccount = userAccount 
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
            Client client = (Client)ModelDomain;
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
            Client client = (Client)ModelDomain;
            ModelResponse response = new ModelResponse();
            try
            {
                using (var context = new EntityContext())
                {
                    var p = context.Clients.FirstOrDefault(q => q.Id == client.Id);
                    context.Clients.Remove(p);
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