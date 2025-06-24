using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DentaSoft.Common.Validation;
using Microsoft.VisualBasic.FileIO;

namespace DentaSoft
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            LoadTotalPatient();
            LoadTotalTreatment();
        }

        private void LoadTotalPatient()
        {
            using var conn = DatabaseConfig.GetConnection();
            string query = "SELECT Count(1) as TotalPatient  FROM tblPatient WHERE IsDeleted = 0"; // Optional: only active

            var adapter = new SqlDataAdapter(query, conn);
            var table = new DataTable();

            try
            {
                conn.Open();
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

            TotalPatients.Text = table.Rows[0]["TotalPatient"].ToString();
        }

        private void LoadTotalTreatment()
        {
            using var conn = DatabaseConfig.GetConnection();
            string query = "SELECT Count(1) as TotalTreatment  FROM tblTreatment"; // Optional: only active

            var adapter = new SqlDataAdapter(query, conn);
            var table = new DataTable();

            try
            {
                conn.Open();
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

            TotalTreatments.Text = table.Rows[0]["TotalTreatment"].ToString();
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
            this.Hide();
            var form = new UploadTreatmentForm();
            form.FormClosed += (s, args) => this.Show();
            form.Show();

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ViewPatientForm();
            form.FormClosed += (s, args) => this.Show();
            form.Show();

        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ViewTreatmentForm();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new InvoiceForm();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void UploadPatient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var form = new UploadPatientForm();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }

        private void UploadTreatment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var form = new UploadTreatmentForm();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
        }
    }
}