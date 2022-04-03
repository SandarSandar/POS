using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimpleMVCProject.Models
{
    public class TownshipModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual CityModel City { get; set; }
    }
}