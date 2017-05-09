using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Supplements.Models;
using System.Data.Entity.Infrastructure;
using System.Configuration;

namespace Supplements.DAO
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("data source=.\\SQLEXPRESS; initial catalog=ESupplements; Integrated Security=true; user id=sa; password=Zener47kaue;") { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set;}
    }
}