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
    public class ProductDataController
    {
        public bool SaveProduct(ProductModel productModel)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand("Product_Insert", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Char).Value = productModel.Id;
                sqlCommand.Parameters.Add("@Code", SqlDbType.NVarChar).Value = productModel.Code;
                sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar).Value = productModel.Description;
                sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = productModel.Quantity;
                sqlCommand.Parameters.Add("@Price", SqlDbType.Decimal).Value = productModel.Price;
                sqlCommand.Parameters.Add("@Category", SqlDbType.SmallInt).Value = productModel.Category;
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

        public ProductModelCollections GetProductList()
        {
            try
            {
                var productModelCollections = new ProductModelCollections();
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand("Product_SelectAll", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    ProductModel productModel = new ProductModel();
                    productModel.Id = sqlDataReader["Id"].ToString();
                    productModel.Code = sqlDataReader["Code"].ToString();
                    productModel.Description = sqlDataReader["Description"].ToString();
                    productModel.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    productModel.Price = Convert.ToDecimal(sqlDataReader["Price"]);
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
