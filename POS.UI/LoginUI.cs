using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.BusinessLogic;
using POS.Models;
using POS.Utilities;

namespace POS.UI
{
    public partial class LoginUI : Form
    {
        UserController userController;

        public LoginUI()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel()
            {
                UserName = txtUserName.Text,
                //Password = txtPassword.Text,
                Password = EncryptionUtility.EncryptPlainTextToCipherText(txtPassword.Text, "posadmin@123")
            };

            UserModel dbUser = userController.LoginUser(user);
            if (string.IsNullOrEmpty(dbUser.UserName))
            {
                MessageBox.Show("Invalid User");
            }
            else
            {
                this.Hide();
                AuditUser.UserId = dbUser.Id;
                AuditUser.UserName = dbUser.UserName;
                DashboardUI dashboardUI = new DashboardUI();
                dashboardUI.Show();             
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProviderUserName.SetError(txtUserName,"User Name should not be blank.");
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProviderUserName.SetError(txtUserName, "Password should not be blank.");
            }
        }

       
    }
}
