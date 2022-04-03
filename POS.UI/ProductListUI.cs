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
    public partial class ProductListUI : Form
    {
        ProductController productController;

        public ProductListUI()
        {
            InitializeComponent();
            productController = new ProductController();
        }

        private void ProductListUI_Load(object sender, EventArgs e)
        {
            this.productGridView.AutoGenerateColumns = false;
            this.productGridView.DataSource = productController.GetProductList();
        }

        private void productGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    ProductUI productUI = new ProductUI();
                    productUI.IsUpdateStatus = true;
                    AuditUser.Id = productGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    productUI.Show();
                }
                else if (e.ColumnIndex == 7)
                {
                    AuditUser.Id = productGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    DialogResult result = MessageBox.Show("Are you sure to delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (productController.DeleteProduct(AuditUser.Id))
                        {
                            MessageBox.Show("Delete Success.");
                        }
                    }
                }
            }
        }
    }
}
