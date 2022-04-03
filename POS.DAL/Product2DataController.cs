using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Models;
using System.Data;
using System.Data.SqlClient;
using POS.Utilities;
using POS.Models.ModelCollections;

namespace POS.DAL
{
    public class Product2DataController
    {
        public bool SaveProduct(Product2Model productModel)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand("Product2_Insert", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Char).Value = productModel.Id;
                sqlCommand.Parameters.Add("@Code", SqlDbType.NVarChar).Value = productModel.Code;
                sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar).Value = productModel.Description;
                sqlCommand.Parameters.Add("@BuyingPrice", SqlDbType.Decimal).Value = productModel.BuyingPrice;
                sqlCommand.Parameters.Add("@SellingPrice", SqlDbType.Decimal).Value = productModel.SellingPrice;
                sqlCommand.Parameters.Add("@IsInStock", SqlDbType.Bit).Value = productModel.IsInStock;
                sqlCommand.Parameters.Add("@UOMId", SqlDbType.Char).Value = productModel.UOMId;
                sqlCommand.Parameters.Add("@CreatedUserId", SqlDbType.Char).Value = AuditUser.UserId;
                sqlCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = productModel.CreatedDate;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool UpdateProduct(ProductModel productModel)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand("Product_Update", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Char).Value = productModel.Id;
                sqlCommand.Parameters.Add("@Code", SqlDbType.NVarChar).Value = productModel.Code;
                sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar).Value = productModel.Description;
                sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = productModel.Quantity;
                sqlCommand.Parameters.Add("@Price", SqlDbType.Decimal).Value = productModel.Price;
                sqlCommand.Parameters.Add("@Category", SqlDbType.SmallInt).Value = productModel.Category;
                sqlCommand.Parameters.Add("@UpdatedUserId", SqlDbType.Char).Value = AuditUser.UserId;
                sqlCommand.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.Now;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public Product2ModelCollections GetProductList()
        {
            try
            {
                var productModelCollections = new Product2ModelCollections();
                SqlConnection conn = DBConnection.GetConnection();
                string query = "SELECT * FROM Product2 WHERE IsDelete=0;";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Product2Model productModel = new Product2Model();
                    productModel.Id = sqlDataReader["Id"].ToString();
                    productModel.Code = sqlDataReader["Code"].ToString();
                    productModel.Description = sqlDataReader["Description"].ToString();
                    productModel.BuyingPrice = Convert.ToDecimal(sqlDataReader["BuyingPrice"]);
                    productModel.SellingPrice = Convert.ToDecimal(sqlDataReader["SellingPrice"]);
                    productModel.IsInStock = Convert.ToBoolean(sqlDataReader["IsInStock"]);
                    productModelCollections.Add(productModel);
                }
                conn.Close();
                return productModelCollections;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductModel GetProductById(string id)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand("Product_SelectById", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Char).Value = id;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                ProductModel productModel = new ProductModel();
                while (sqlDataReader.Read())
                {
                    productModel.Id = sqlDataReader["Id"].ToString();
                    productModel.Code = sqlDataReader["Code"].ToString();
                    productModel.Description = sqlDataReader["Description"].ToString();
                    productModel.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    productModel.Price = Convert.ToDecimal(sqlDataReader["Price"]);
                    productModel.Category = Convert.ToInt32(sqlDataReader["Category"]);
                }
                conn.Close();
                return productModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
           
        public bool DeleteProduct(string id)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand("Product_Delete", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Char).Value = id;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
