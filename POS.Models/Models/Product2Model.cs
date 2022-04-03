using POS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Models
{
    public class Product2Model:BaseModel
    {
        public string UOMId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool IsInStock { get; set; }

    }
}
