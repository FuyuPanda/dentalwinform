namespace DentaSoft
{
    partial class UploadTreatmentForm
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
            txtFilePath = new System.Windows.Forms.TextBox();
            btnUpload = new System.Windows.Forms.Button();
            btnBrowse = new System.Windows.Forms.Button();
            btnBack = new System.Windows.Forms.Button();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new System.Drawing.Point(12, 27);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new System.Drawing.Size(297, 27);
            txtFilePath.TabIndex = 0;
            // 
            // btnUpload
            // 
            btnUpload.Location = new System.Drawing.Point(415, 25);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new System.Drawing.Size(94, 29);
            btnUpload.TabIndex = 1;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new System.Drawing.Point(315, 25);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new System.Drawing.Size(94, 29);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(515, 25);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(94, 29);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(12, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new System.Drawing.Size(875, 356);
            dataGridView1.TabIndex = 4;
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;
            // 
            // UploadTreatmentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(899, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnBack);
            Controls.Add(btnBrowse);
            Controls.Add(btnUpload);
            Controls.Add(txtFilePath);
            Name = "UploadTreatmentForm";
            Text = "UploadTreatmentForm";
            Load += UploadTreatmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}