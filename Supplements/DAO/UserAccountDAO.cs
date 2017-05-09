﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Supplements.Models;

namespace Supplements.DAO
{
    public class UserAccountDAO : AbstractDAO, IDAO
    {
        public Models.ModelResponse Create(Models.ModelDomain ModelDomain)
        {
            ModelResponse response = new ModelResponse();
            UserAccount userAccount = (UserAccount)ModelDomain;
            try
            {
                using (var context = new EntityContext())
                {
                    context.UserAccounts.Add(userAccount);
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
            UserAccount userAccount = (UserAccount)ModelDomain;
            ModelResponse response = new ModelResponse() { Domain = new List<ModelDomain>() };
            try
            {
                using (var context = new EntityContext())
                {
                    var userAccounts = from p in context.UserAccounts select p;
                    if (userAccount.Id > 0)
                        userAccounts = userAccounts.Where(q => q.Id == userAccount.Id);
                    if (userAccount.UserName != null && !string.IsNullOrEmpty(userAccount.UserName))
                        userAccounts = userAccounts.Where(q => q.UserName == userAccount.UserName);
                    if (userAccount.Password != null && !string.IsNullOrEmpty(userAccount.Password))
                        userAccounts = userAccounts.Where(q => q.UserName == userAccount.UserName);

                    foreach (var p in userAccounts)
                    {
                        response.Domain.Add(new UserAccount()
                        {
                            Id = p.Id,
                            UserName = p.UserName,
                            Password = p.Password,
                            AccountType = p.AccountType
                        });
                    }
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

        public Models.ModelResponse Update(Models.ModelDomain ModelDomain)
        {
            ModelResponse response = new ModelResponse();
            UserAccount userAccount = (UserAccount)ModelDomain;
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
            UserAccount userAccount = (UserAccount)ModelDomain;
            ModelResponse response = new ModelResponse();
            try
            {
                using (var context = new EntityContext())
                {
                    var p = context.UserAccounts.FirstOrDefault(q => q.Id == userAccount.Id);
                    context.UserAccounts.Remove(p);
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