using POS.BusinessLogic;
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
    public partial class Product2ListUI : Form
    {
        Product2Controller product2Controller;

        public Product2ListUI()
        {
            InitializeComponent();
            product2Controller = new Product2Controller();
        }

        private void Product2ListUI_Load(object sender, EventArgs e)
        {
            this.Product2GridView.AutoGenerateColumns = false;
            this.Product2GridView.DataSource = product2Controller.GetProductList();
        }
    }
}
