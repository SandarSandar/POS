using POS.BusinessLogic;
using POS.Models.Models;
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
    public partial class ProductUI : Form
    {
        ProductController productController;

        public bool IsUpdateStatus { get; set; }

        public ProductUI()
        {
            InitializeComponent();
            productController = new ProductController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProductModel productModel = new ProductModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = txtCode.Text,
                    Description = txtDesc.Text,
                    Quantity = Convert.ToInt32(txtQty.Text),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Category = Convert.ToInt32(cboCategory.SelectedValue)                 
                };

                if (btnSave.Text == "Update")
                {
                    if (productController.UpdateProduct(productModel))
                    {
                        MessageBox.Show("Updated product successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update product failed.");
                    }
                }
                else
                {
                    if (productController.SaveProduct(productModel))
                    {
                        MessageBox.Show("Saved product successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Save product failed.");
                    }
                }
                
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductUI_Load(object sender, EventArgs e)
        {
            if (IsUpdateStatus)
            {
                btnSave.Text = "Update";
                ProductModel productModel = productController.GetProductById(AuditUser.Id);
                txtCode.Text = productModel.Code;
                txtDesc.Text = productModel.Description;
                txtQty.Text = productModel.Quantity.ToString();
                txtPrice.Text = productModel.Price.ToString();
            }
        }
    }
}
