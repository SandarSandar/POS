using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace POS.Utilities
{
    public class BaseModel
    {
        public string Id { get; set; }
        //built-in field       
             
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }

        [Browsable(false)]
        public string DeletedUserId { get; set; }

        [Browsable(false)]
        public bool IsDelete { get; set; } = false;
        public byte[] Version { get; set; }
    }
}
