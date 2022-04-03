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
    public partial class DashboardUI : Form
    {
        private int childFormNumber = 0;

        public DashboardUI()
        {
            InitializeComponent();
            welcomeUserInfoToolStripMenuItem.Text = $"Welcome {AuditUser.UserName}";
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserListUI userListUI = new UserListUI();
            userListUI.MdiParent = this;
            userListUI.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserUI userUI = new UserUI();
            userUI.MdiParent = this;
            userUI.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginUI().Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductUI productUI = new ProductUI();
            productUI.MdiParent = this;
            productUI.Show();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UOMUI uomUI = new UOMUI();
            uomUI.MdiParent = this;
            uomUI.Show();
        }

        private void ProductlistToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductListUI productListUI = new ProductListUI();
            productListUI.MdiParent = this;
            productListUI.Show();
        }

        private void UOMlistToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UOMListUI uomListUI = new UOMListUI();
            uomListUI.MdiParent = this;
            uomListUI.Show();
        }

        private void DashboardUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Product2UI ui = new Product2UI();
            ui.MdiParent = this;
            ui.Show();
        }

        private void Product2listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product2ListUI ui = new Product2ListUI();
            ui.MdiParent = this;
            ui.Show();
        }

        private void excelUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelUploadUI ui = new ExcelUploadUI();
            ui.MdiParent = this;
            ui.Show();
        }
    }
}
