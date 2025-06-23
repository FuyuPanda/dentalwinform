namespace DentaSoft
{
    partial class UploadPatientForm
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
            dataGridView1 = new System.Windows.Forms.DataGridView();
            txtFilePath = new System.Windows.Forms.TextBox();
            btnUpload = new System.Windows.Forms.Button();
            btnBrowse = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(12, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new System.Drawing.Size(963, 350);
            dataGridView1.TabIndex = 7;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new System.Drawing.Point(12, 35);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new System.Drawing.Size(500, 27);
            txtFilePath.TabIndex = 6;
            // 
            // btnUpload
            // 
            btnUpload.Location = new System.Drawing.Point(600, 33);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new System.Drawing.Size(75, 29);
            btnUpload.TabIndex = 5;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new System.Drawing.Point(520, 33);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new System.Drawing.Size(75, 29);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(681, 33);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UploadPatientForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(981, 427);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(txtFilePath);
            Controls.Add(btnUpload);
            Controls.Add(btnBrowse);
            Name = "UploadPatientForm";
            Text = "UploadPatientForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button button1;
    }
}