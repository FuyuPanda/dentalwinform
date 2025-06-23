namespace DentaSoft
{
    partial class ViewPatientForm
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
            button1 = new System.Windows.Forms.Button();
            textBox1 = new System.Windows.Forms.TextBox();
            button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(12, 54);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new System.Drawing.Size(1033, 350);
            dataGridView1.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(317, 22);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(94, 29);
            button1.TabIndex = 9;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(12, 22);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search Patient Name Here";
            textBox1.Size = new System.Drawing.Size(199, 27);
            textBox1.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(217, 22);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(94, 29);
            button2.TabIndex = 11;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ViewPatientForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1057, 450);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "ViewPatientForm";
            Text = "ViewPatientForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}