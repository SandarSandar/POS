using POS.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models;
using POS.Models.ModelCollections;
using POS.DAL;

namespace POS.BusinessLogic
{
    public class UOMController : IUOMService
    {
        UOMDataController uomDataController;

        public UOMController()
        {
            uomDataController = new UOMDataController();
        }

        public UOMModel GetUOMById(string Id)
        {
            return uomDataController.GetUOMById(Id);
        }

        public UOMModelCollections getUOMList()
        {
            return uomDataController.GetUOMList();
        }

        public bool SaveUOM(UOMModel uomModel)
        {
            return uomDataController.SaveUOM(uomModel);
        }

        public bool UpdateUOM(UOMModel uomModel)
        {
            return uomDataController.UpdateUOM(uomModel);
        }

        public bool DeleteUOM(string id)
        {
            return uomDataController.DeleteUOM(id);
        }

        public void DeleteUOM(object id)
        {
            throw new NotImplementedException();
        }
    }
}
