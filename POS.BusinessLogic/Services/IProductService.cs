using POS.Models.ModelCollections;
using POS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BusinessLogic.Services
{
    interface IProductService
    {
        bool SaveProduct(ProductModel productModel);

        ProductModelCollections GetProductList();

        bool DeleteProduct(string id);

        ProductModel GetProductById(string id);

        bool UpdateProduct(ProductModel productModel);
    }
}
