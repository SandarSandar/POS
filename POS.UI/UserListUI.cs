using POS.BusinessLogic;
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
    public partial class UserListUI : Form
    {
        UserController userController;

        public UserListUI()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private void UserListUI_Load(object sender, EventArgs e)
        {
            LoadUserList();
        }

        private void LoadUserList()
        {
            userGridView.DataSource = userController.GetUserList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete", "Deleting data", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //string userId = "43d69019-8a94-4f8d-b102-439ecdeacd68";
                if (userController.DeleteUserById(AuditUser.Id))
                {
                    MessageBox.Show("Delete successfully.");
                }
            }
            LoadUserList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserUI userUI = new UserUI();
            userUI.IsUpdateStatus = true;
            userUI.Show();
        }

        private void userGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = userGridView.Rows[e.RowIndex];
                AuditUser.Id = row.Cells["Id"].Value.ToString();
            }
        }
    }
}
