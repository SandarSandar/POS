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
    public partial class UOMUI : Form
    {
        UOMController uomController;
        public bool IsUpdateStatus { get; set; }

        public UOMUI()
        {
            InitializeComponent();
            uomController = new UOMController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UOMModel uomModel = new UOMModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = txtCode.Text,
                    Description = txtDesc.Text
                };
                

                if (btnSave.Text == "Update")
                {
                    uomModel.Id = AuditUser.Id;
                    if (uomController.UpdateUOM(uomModel))
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
                    if (uomController.SaveUOM(uomModel))
                    {
                        MessageBox.Show("Saved UOM successfully.");
                    }
                    else
                    {
                        MessageBox.Show("UOM save failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UOMUI_Load(object sender, EventArgs e)
        {
            if (IsUpdateStatus)
            {
                btnSave.Text = "Update";
                UOMModel uomModel = uomController.GetUOMById(AuditUser.Id);
                txtCode.Text = uomModel.Code;
                txtDesc.Text = uomModel.Description;
            }
        }
    }
}
