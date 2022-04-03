using POS.Models;
using POS.Models.ModelCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BusinessLogic.Services
{
    public interface IUOMService
    {
        UOMModelCollections getUOMList();

        bool SaveUOM(UOMModel uomModel);

        bool UpdateUOM(UOMModel uomModel);

        UOMModel GetUOMById(string Id);


    }
}
