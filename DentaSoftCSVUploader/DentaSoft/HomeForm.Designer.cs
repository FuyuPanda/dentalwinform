namespace DentaSoft
{
    partial class HomeForm
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
            label1 = new System.Windows.Forms.Label();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            TotalTreatments = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            TotalPatients = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            UploadTreatment = new System.Windows.Forms.LinkLabel();
            UploadPatient = new System.Windows.Forms.LinkLabel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            viewToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            viewToolStripMenuItem.Text = "View";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // uploadToolStripMenuItem
            // 
            uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            uploadToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
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
            viewToolStripMenuItem1.Click += viewToolStripMenuItem1_Click;
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
            viewToolStripMenuItem2.Click += viewToolStripMenuItem2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(21, 61);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(318, 41);
            label1.TabIndex = 5;
            label1.Text = "Welcome to DentaSoft";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new System.Drawing.Point(32, 120);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TotalTreatments);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(TotalPatients);
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(UploadTreatment);
            splitContainer1.Panel2.Controls.Add(UploadPatient);
            splitContainer1.Size = new System.Drawing.Size(864, 231);
            splitContainer1.SplitterDistance = 396;
            splitContainer1.TabIndex = 6;
            // 
            // TotalTreatments
            // 
            TotalTreatments.Location = new System.Drawing.Point(215, 88);
            TotalTreatments.Name = "TotalTreatments";
            TotalTreatments.ReadOnly = true;
            TotalTreatments.Size = new System.Drawing.Size(125, 27);
            TotalTreatments.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 95);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(126, 20);
            label3.TabIndex = 2;
            label3.Text = "Total Treatments :";
            // 
            // TotalPatients
            // 
            TotalPatients.Location = new System.Drawing.Point(215, 22);
            TotalPatients.Name = "TotalPatients";
            TotalPatients.ReadOnly = true;
            TotalPatients.Size = new System.Drawing.Size(125, 27);
            TotalPatients.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 20);
            label2.TabIndex = 0;
            label2.Text = "Total Patients :";
            // 
            // UploadTreatment
            // 
            UploadTreatment.AutoSize = true;
            UploadTreatment.Location = new System.Drawing.Point(29, 95);
            UploadTreatment.Name = "UploadTreatment";
            UploadTreatment.Size = new System.Drawing.Size(163, 20);
            UploadTreatment.TabIndex = 1;
            UploadTreatment.TabStop = true;
            UploadTreatment.Text = "Upload New Treatment";
            UploadTreatment.LinkClicked += UploadTreatment_LinkClicked;
            // 
            // UploadPatient
            // 
            UploadPatient.AutoSize = true;
            UploadPatient.Location = new System.Drawing.Point(29, 24);
            UploadPatient.Name = "UploadPatient";
            UploadPatient.Size = new System.Drawing.Size(141, 20);
            UploadPatient.TabIndex = 0;
            UploadPatient.TabStop = true;
            UploadPatient.Text = "Upload New Patient";
            UploadPatient.LinkClicked += UploadPatient_LinkClicked;
            // 
            // HomeForm
            // 
            ClientSize = new System.Drawing.Size(987, 440);
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "HomeForm";
            Text = "DentaSoft - CSV Uploader";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TotalTreatments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TotalPatients;
        private System.Windows.Forms.LinkLabel UploadTreatment;
        private System.Windows.Forms.LinkLabel UploadPatient;
    }
}