using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DentaSoft.Common.Validation;
using Microsoft.VisualBasic.FileIO;

namespace DentaSoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new UploadPatientForm();
            form.FormClosed += (s, args) => this.Show();
            form.Show();

        }

        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ViewPatientForm();
            form.FormClosed += (s, args) => this.Show();
            form.Show();

        }
    }
}