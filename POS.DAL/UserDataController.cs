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

namespace POS.DAL
{
    public class UserDataController
    {
        public List<UserModel> GetUserList()
        {
            var userList = new List<UserModel>();
            SqlConnection conn = DBConnection.GetConnection();
            string query = "SELECT * FROM [User] WHERE isDelete=0";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                UserModel user = new UserModel();
                user.Id = sqlDataReader["Id"].ToString();
                user.UserName = sqlDataReader["UserName"].ToString();
                user.Email = sqlDataReader["Email"].ToString();
                user.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                if (!(sqlDataReader["UpdatedDate"] is DBNull))
                user.UpdatedDate = (Convert.ToDateTime(sqlDataReader["UpdatedDate"]));
                userList.Add(user);
            }
            conn.Close();
            return userList;
        }

        public UserModel GetUserById(string userId)
        {
            SqlConnection conn = DBConnection.GetConnection();
            string query = "SELECT * FROM [User] WHERE isDelete=0 AND Id = '"+ userId +"'";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            UserModel user = new UserModel();
            while (sqlDataReader.Read())
            {
                user.Id = sqlDataReader["Id"].ToString();
                user.UserName = sqlDataReader["UserName"].ToString();
                user.Email = sqlDataReader["Email"].ToString();
                user.Password = sqlDataReader["Password"].ToString();
                user.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                if (!(sqlDataReader["UpdatedDate"] is DBNull))
                    user.UpdatedDate = (Convert.ToDateTime(sqlDataReader["UpdatedDate"]));
            }
            conn.Close();
            return user;
        }

        public UserModel GetUserByUserNameAndPassword(string userName, string password)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand sqlCommand = new SqlCommand("User_Login", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            UserModel user = new UserModel();
            while (sqlDataReader.Read())
            {
                user.Id = sqlDataReader["Id"].ToString();
                user.UserName = sqlDataReader["UserName"].ToString();
            }
            conn.Close();
            return user;
        }

        public bool SaveUser(UserModel user)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                string query = $"insert into [User] (Id, UserName, Email, Password, CreatedDate, isDelete) values ('{user.Id}', '{user.UserName}', '{user.Email}','{user.Password}', '{user.CreatedDate}', '{user.IsDelete}')";
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

        public bool DeleteUserById(string userId)
        {
            try
            {
                SqlConnection conn = DBConnection.GetConnection();
                string query = $"UPDATE [User] SET isDelete=1, DeletedUserId='{AuditUser.UserId}' WHERE Id = '{userId}'";
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
