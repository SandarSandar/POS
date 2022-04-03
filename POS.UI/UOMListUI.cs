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
    public partial class UOMListUI : Form
    {
        UOMController uomController;

        public UOMListUI()
        {
            InitializeComponent();
            uomController = new UOMController();
        }

        private void UOMListUI_Load(object sender, EventArgs e)
        {
            LoadUOMList();
        }

        private void LoadUOMList()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = uomController.getUOMList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5) //edit link button
                {
                    UOMUI uomUI = new UOMUI();
                    uomUI.IsUpdateStatus = true;
                    AuditUser.Id = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    uomUI.Show();
                }
                else if (e.ColumnIndex == 6) //Delete link button
                {
                    AuditUser.Id = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    DialogResult result = MessageBox.Show("Are you sure to delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (uomController.DeleteUOM(AuditUser.Id))
                        {
                            MessageBox.Show("Delete Success.");
                            LoadUOMList();
                        }
                    }

                }
            }
        }
    }
}
