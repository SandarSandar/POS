using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class SQLModel
    {
        public string ConnectionStatus { get; set; }
        public string DataSourceName { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionState { get; set; }
        public int ConnectionTimeOut { get; set; }
    }
}
