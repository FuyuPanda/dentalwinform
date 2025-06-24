using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentaSoft
{
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            using var conn = DatabaseConfig.GetConnection();
            string query = "SELECT InvoiceIdentifier,Firstname,Lastname,InvoiceDate,DueDate,Note,Total,Paid,Discount FROM tblInvoice a Join tblPatient b on a.PatientId = b.PatientId WHERE b.IsDeleted = 0"; // Optional: only active

            var adapter = new SqlDataAdapter(query, conn);
            var table = new DataTable();

            try
            {
                conn.Open();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using var conn = DatabaseConfig.GetConnection();
            string query = "SELECT InvoiceIdentifier,Firstname,Lastname,InvoiceDate,DueDate,Note,Total,Paid,Discount FROM tblInvoice a Join tblPatient b on a.PatientId = b.PatientId WHERE b.IsDeleted = 0 And Firstname + ' ' +Lastname like @search"; // Optional: only active

            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");


            var adapter = new SqlDataAdapter(cmd);
            var table = new DataTable();

            try
            {
                conn.Open();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }
        }
    }
}
