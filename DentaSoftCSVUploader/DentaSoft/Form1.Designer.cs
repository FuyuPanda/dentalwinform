namespace DentaSoft
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            treatmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            uploadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { homeToolStripMenuItem, patientToolStripMenuItem, treatmentToolStripMenuItem, invoiceToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(987, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            homeToolStripMenuItem.Text = "Home";
            // 
            // patientToolStripMenuItem
            // 
            patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { viewToolStripMenuItem, uploadToolStripMenuItem });
            patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            patientToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            patientToolStripMenuItem.Text = "Patient";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            viewToolStripMenuItem.Text = "View";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // uploadToolStripMenuItem
            // 
            uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            uploadToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            uploadToolStripMenuItem.Text = "Upload";
            uploadToolStripMenuItem.Click += uploadToolStripMenuItem_Click;
            // 
            // treatmentToolStripMenuItem
            // 
            treatmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { viewToolStripMenuItem1, uploadToolStripMenuItem1 });
            treatmentToolStripMenuItem.Name = "treatmentToolStripMenuItem";
            treatmentToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            treatmentToolStripMenuItem.Text = "Treatment";
            // 
            // viewToolStripMenuItem1
            // 
            viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            viewToolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            viewToolStripMenuItem1.Text = "View";
            // 
            // uploadToolStripMenuItem1
            // 
            uploadToolStripMenuItem1.Name = "uploadToolStripMenuItem1";
            uploadToolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            uploadToolStripMenuItem1.Text = "Upload";
            uploadToolStripMenuItem1.Click += uploadToolStripMenuItem1_Click;
            // 
            // invoiceToolStripMenuItem
            // 
            invoiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { viewToolStripMenuItem2 });
            invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            invoiceToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            invoiceToolStripMenuItem.Text = "Invoice";
            // 
            // viewToolStripMenuItem2
            // 
            viewToolStripMenuItem2.Name = "viewToolStripMenuItem2";
            viewToolStripMenuItem2.Size = new System.Drawing.Size(124, 26);
            viewToolStripMenuItem2.Text = "View";
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(987, 440);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "DentaSoft - CSV Uploader";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treatmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem2;
    }
}