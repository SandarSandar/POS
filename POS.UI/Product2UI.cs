using POS.BusinessLogic;
using POS.Models.Models;
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
    public partial class Product2UI : Form
    {
        Product2Controller product2Controller;

        public Product2UI()
        {
            InitializeComponent();
            product2Controller = new Product2Controller();
        }       

        private void Product2UI_Load(object sender, EventArgs e)
        {
            LoadUOMList();
        }

        private void LoadUOMList()
        {
            UOMController uomController = new UOMController();
            cboUOM.DataSource = uomController.getUOMList();
            cboUOM.ValueMember = "Id";
            cboUOM.DisplayMember = "Description";
            cboUOM.SelectedIndex = -1;
            cboUOM.SelectedText = "-- Select --";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Product2Model productModel = new Product2Model();
                BindProductModel(productModel);
                if (product2Controller.SaveProduct(productModel))
                {
                    MessageBox.Show("Save successful");
                }
                else
                {
                    MessageBox.Show("Save failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BindProductModel(Product2Model productModel)
        {
            productModel.Id = Guid.NewGuid().ToString();
            productModel.Code = txtCode.Text;
            productModel.Description = txtDesc.Text;
            productModel.SellingPrice = Convert.ToDecimal(txtSelling.Text);
            productModel.BuyingPrice = Convert.ToDecimal(txtBuying.Text);
            productModel.IsInStock = checkInstock.Checked;
            productModel.UOMId = cboUOM.SelectedValue.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCode.Text = txtDesc.Text = txtBuying.Text = txtSelling.Text = string.Empty;
            cboUOM.SelectedIndex = -1;
            checkInstock.Checked = false;
        }
    }
}
