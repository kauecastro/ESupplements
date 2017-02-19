using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Supplements.Models;

namespace Supplements.DAO
{
    public abstract class AbstractDAO 
    {
        public MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString);
    }
}