using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DAL;
using POS.Models;

namespace POS.BusinessLogic
{
    public class DBController
    {
        public SQLModel GetDBConnection()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SQLModel SQLModel = new SQLModel()
            {
                ConnectionState = conn.State.ToString(),
                ConnectionStatus = "Connected",
                ConnectionTimeOut = conn.ConnectionTimeout,
                DataSourceName = conn.DataSource,
                DatabaseName = conn.Database
            };
            return SQLModel;
        }
    }
}
