using POS.BusinessLogic;
using POS.Models;
using POS.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class UserUI : Form
    {
        public UserUI()
        {
            InitializeComponent();
        }

        public bool IsUpdateStatus { get; set; }
        UserController userController = new UserController();

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBController dbController = new DBController();
            SQLModel sqlModel = dbController.GetDBConnection();
            lblServer.Text = sqlModel.DataSourceName;
            lblDB.Text = sqlModel.DatabaseName;
            lblConn.Text = sqlModel.ConnectionStatus;
            lblState.Text = sqlModel.ConnectionState;
            lbltime.Text = sqlModel.ConnectionTimeOut.ToString();

            SaveUser();
        }

        private void SaveUser()
        {
            UserModel userModel = new UserModel()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = txtUser.Text,
                Password = EncryptionUtility.EncryptPlainTextToCipherText(txtPassword.Text, "posadmin@123"),
                Email = txtEmail.Text
            };

            if (btnSave.Text == "Update")
            {
                userModel.Id = AuditUser.Id;
                if (userController.UpdateUser(userModel))
                {
                    MessageBox.Show("Update successfully.");
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
            }
            else
            {
                if (userController.CheckUserAlreadyExists(userModel))
                {
                    MessageBox.Show("Already Exists!");
                }
                else if (userController.SaveUser(userModel))
                {
                    MessageBox.Show("Save successfully.");
                }
                else
                {
                    MessageBox.Show("Save failed.");
                }
            }            
        }

        private void UserUI_Load(object sender, EventArgs e)
        {
            if (IsUpdateStatus)
            {
                btnSave.Text = "Update";
                UserModel userModel = userController.GetUserById(AuditUser.Id);
                txtUser.Text = userModel.UserName;
                txtPassword.Text = userModel.Password;
                txtEmail.Text = userModel.Email;               
            }
            else
            {

            }
        }
    }
}
