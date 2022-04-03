using POS.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Models;
using POS.DAL;
using POS.Models.ModelCollections;

namespace POS.BusinessLogic
{
    public class ProductController : IProductService
    {
        ProductDataController productDataController;

        public ProductController()
        {
            productDataController = new ProductDataController();
        }

        public bool SaveProduct(ProductModel productModel)
        {
            return productDataController.SaveProduct(productModel);
        }

        public ProductModelCollections GetProductList()
        {
            return productDataController.GetProductList();
        }

        public bool DeleteProduct(string id)
        {
            return productDataController.DeleteProduct(id);
        }

        public ProductModel GetProductById(string id)
        {
            return productDataController.GetProductById(id);
        }

        public bool UpdateProduct(ProductModel productModel)
        {
            return productDataController.UpdateProduct(productModel);
        }
    }
}
