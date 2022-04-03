using POS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class UOMModel:BaseModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }       
}
