using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using POS.Models.ModelCollections;
using POS.Models.Models;
using POS.BusinessLogic;

namespace POS.UI
{
    public partial class ExcelUploadUI : Form
    {
        private DataTable dt;
        UOMController uomController;
        Product2Controller productController;

        public ExcelUploadUI()
        {
            InitializeComponent();
            dt = new DataTable();
            uomController = new UOMController();
            productController = new Product2Controller();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            //open file dialog.
            this.openFileDialogUpload.ShowDialog();
        }

        private void openFileDialogUpload_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialogUpload.FileName;

            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                IXLWorksheet workSheet = workBook.Worksheet(1);

                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            //reading header value current rows and add to data table
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add data rows to DataTable
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                        //bind data from datatable to gridview
                        this.excelGridView.DataSource = dt;
                    }
                }
                    
            }

        }

        private Product2ModelCollections ConvertDataTableToProductModelCollections(DataTable dt)
        {
            var products = new Product2ModelCollections();
            foreach (DataRow row in dt.Rows)
            {
                Product2Model productModel = new Product2Model();
                productModel.Id = Guid.NewGuid().ToString();
                productModel.Code = row["ProductCode"].ToString();
                productModel.Description = row["ProductDescription"].ToString();
                productModel.BuyingPrice = Convert.ToDecimal(row["BuyingPrice"]);
                productModel.SellingPrice = Convert.ToDecimal(row["SellingPrice"]);
                productModel.IsInStock = row["IsInStock"].ToString().Equals("Yes") ? true : false;

                string uomCode = row["UOMCode"].ToString(); //101, 102,
                var uomId = uomController.getUOMList().Where(x => x.Code.Equals(uomCode)).SingleOrDefault().Id;
                if (uomId != null)
                {
                    productModel.UOMId = uomId;                 
                }
                products.Add(productModel);
            }
            return products;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var products = ConvertDataTableToProductModelCollections(dt);
            if (productController.SaveProduct(products))
            {
                MessageBox.Show($"upload {products.Count} records is completed successfully.");
            }
            else
            {
                MessageBox.Show("Upload failed.");
            }
        }
    }
}
