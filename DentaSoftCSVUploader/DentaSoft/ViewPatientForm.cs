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
    public partial class ViewPatientForm : Form
    {
        public ViewPatientForm()
        {
            InitializeComponent();
            LoadPatients();
        }

        private void LoadPatients()
        {
            using var conn = DatabaseConfig.GetConnection();
            string query = "SELECT PatientIdentifier,Firstname,Lastname,DateOfBirth as DOB, Sex as Gender, Email, Mobile as MobileNumber, HomePhone as PhoneNumber, AddressLine1 as Street, Suburb, State, Postcode  FROM tblPatient WHERE IsDeleted = 0"; // Optional: only active

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



        //Back Button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Search Button
        private void button2_Click(object sender, EventArgs e)
        {
            using var conn = DatabaseConfig.GetConnection();
            string query = "SELECT PatientIdentifier,Firstname,Lastname,DateOfBirth as DOB, Sex as Gender, Email, Mobile as MobileNumber, HomePhone as PhoneNumber, AddressLine1 as Street, Suburb, State, Postcode  FROM tblPatient WHERE IsDeleted = 0 And Firstname + ' ' +Lastname like @search"; // Optional: only active

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
