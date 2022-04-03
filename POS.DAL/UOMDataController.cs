using POS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Utilities;
using POS.Models.ModelCollections;

namespace POS.DAL
{
    public class UOMDataController
    {
        public UOMModelCollections GetUOMList()
        {
            var uomModelCollection = new UOMModelCollections();
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand sqlCommand = new SqlCommand("UOM_SelectAll", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                UOMModel uom = new UOMModel();
                uom.Id = sqlDataReader["Id"].ToString();
                uom.Code = sqlDataReader["Code"].ToString();
                uom.Description = sqlDataReader["Description"].ToString();
                uom.CreatedUserId = sqlDataReader["CreatedUserId"].ToString();
                uom.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                if (!(sqlDataReader["UpdatedDate"] is DBNull))
                uom.UpdatedDate = (Convert.ToDateTime(sqlDataReader["UpdatedDate"]));
                uomModelCollection.Add(uom);
            }
            conn.Close();
            return uomModelCollection;
        }

        public bool UpdateUOM(UOMModel uomModel)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand("UOM_Update", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Char).Value = uomModel.Id;
                sqlCommand.Parameters.Add("@Code", SqlDbType.NVarChar).Value = uomModel.Code;
                sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar).Value = uomModel.Description;
                sqlCommand.Parameters.Add("@UpdatedUserId", SqlDbType.Char).Value = AuditUser.UserId;
                sqlCommand.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.Now;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {              
                throw;
            }
            return true;
        }

        public bool DeleteUOM(string Id)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand("UOM_Delete", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Char).Value = Id;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public UOMModel GetUOMById(string Id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand sqlCommand = new SqlCommand("UOM_SelectById", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@Id", SqlDbType.Char).Value = Id;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            UOMModel uom = new UOMModel();

            while (sqlDataReader.Read())
            {               
                uom.Id = sqlDataReader["Id"].ToString();
                uom.Code = sqlDataReader["Code"].ToString();
                uom.Description = sqlDataReader["Description"].ToString();
            }
            conn.Close();
            return uom;
        }

        public bool SaveUOM(UOMModel uomModel)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand("UOM_Insert", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.Char).Value = uomModel.Id;
                sqlCommand.Parameters.Add("@Code", SqlDbType.NVarChar).Value = uomModel.Code;
                sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar).Value = uomModel.Description;
                sqlCommand.Parameters.Add("@CreatedUserId", SqlDbType.Char).Value = AuditUser.UserId;
                sqlCommand.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = uomModel.CreatedDate;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public bool UpdateUser(UserModel UserModel)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                string query = $"UPDATE [User] SET UserName='{UserModel.UserName}', Email='{UserModel.Email}', Password='{UserModel.Password}', UpdatedDate='{DateTime.Now}' WHERE Id = '{UserModel.Id}' ";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

    }
}
