namespace POS.UI
{
    partial class ExcelUploadUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.excelGridView = new System.Windows.Forms.DataGridView();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.openFileDialogUpload = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // excelGridView
            // 
            this.excelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.excelGridView.Location = new System.Drawing.Point(13, 13);
            this.excelGridView.Name = "excelGridView";
            this.excelGridView.RowTemplate.Height = 24;
            this.excelGridView.Size = new System.Drawing.Size(766, 266);
            this.excelGridView.TabIndex = 0;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(13, 285);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(94, 35);
            this.btnChoose.TabIndex = 1;
            this.btnChoose.Text = "Choose File";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(126, 285);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 35);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // openFileDialogUpload
            // 
            this.openFileDialogUpload.FileName = "Pls Choose Excel File";
            this.openFileDialogUpload.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogUpload_FileOk);
            // 
            // ExcelUploadUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 348);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.excelGridView);
            this.Name = "ExcelUploadUI";
            this.Text = "ExcelUploadUI";
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView excelGridView;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialogUpload;
    }
}