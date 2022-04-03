using POS.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.ModelCollections;
using POS.Models.Models;
using POS.DAL;

namespace POS.BusinessLogic
{
    public class Product2Controller : IProduct2Service
    {
        Product2DataController productDataController;

        public Product2Controller()
        {
            productDataController = new Product2DataController();
        }

        public Product2ModelCollections GetProductList()
        {
            return productDataController.GetProductList();
        }

        public bool SaveProduct(Product2ModelCollections productModels)
        {
            try
            {              
                foreach (var productModel in productModels)
                {
                    var productExists = productDataController.GetProductList().Where(x => x.Code.Equals(productModel.Code));
                    if (productExists.Any())
                    {

                    }
                    else
                    {
                        productDataController.SaveProduct(productModel);
                    }                   
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveProduct(Product2Model productModel)
        {
            try
            {
                productDataController.SaveProduct(productModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
