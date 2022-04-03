using POS.Models.ModelCollections;
using POS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BusinessLogic.Services
{
    public interface IProduct2Service
    {
        Product2ModelCollections GetProductList();
        bool SaveProduct(Product2Model productModel);

        bool SaveProduct(Product2ModelCollections productModels);
    }
}
