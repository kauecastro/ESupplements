using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Supplements.Models;
namespace Supplements.DAO
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("Data Source=.\\SQLEXPRESS;Initial Catalog=ESupplements;Persist Security Info=True;User ID=sa;Password=Zener47kaue") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}