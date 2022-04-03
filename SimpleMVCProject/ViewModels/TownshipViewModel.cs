using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVCProject.ViewModels
{
    public class TownshipViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
    }
}