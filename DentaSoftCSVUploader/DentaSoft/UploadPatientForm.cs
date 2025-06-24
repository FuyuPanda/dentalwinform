using DentaSoft.Common.Validation;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
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
    public partial class UploadPatientForm : Form
    {
        public UploadPatientForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Select Patient CSV File"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
                LoadCSV(ofd.FileName);
            }
        }

        private void LoadCSV(string filePath)
        {
            DataTable dt = new DataTable();

            using TextFieldParser parser = new TextFieldParser(filePath);
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;

            PatientValidation validation = new PatientValidation();

            string[] headers = parser.ReadFields();
            foreach (string header in headers)
                dt.Columns.Add(header);

            dt.Columns.Add("ErrorMessage");

            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();

                var newRow = dt.NewRow();
                
                string errorMessages = "";
                List<string> mandatoryFields = new List<string>() { "FirstName", "LastName" };
                for (var i = 0; i < headers.Length; i++)
                {
                    newRow[i] = row[i];

                    if (mandatoryFields.Contains(headers[i]))
                    {
                        if (string.IsNullOrWhiteSpace(newRow[i].ToString()))
                        {
                            errorMessages += $"{headers[i]} is required|";
                        }
                    }


                    if (headers[i].Equals("MobileNumber"))
                    {
                        newRow["MobileNumber"]=newRow["MobileNumber"].ToString().Trim().Replace(" ", "");
                        string mobileNumber = newRow["MobileNumber"].ToString();
                        string mobileNumberValidation = validation.MobilePhoneValidation("Mobile",mobileNumber);
                        if (mobileNumberValidation != "Success")
                        {
                            errorMessages += mobileNumberValidation + "|";
                        }
                    }

                    if (headers[i].Equals("PhoneNumber"))
                    {
                        newRow["PhoneNumber"]=newRow["PhoneNumber"].ToString().Trim().Replace(" ", "");
                        string phoneNumber = newRow["PhoneNumber"].ToString();
                        string phoneNumberValidation = validation.MobilePhoneValidation("Phone",phoneNumber);
                        if (phoneNumberValidation != "Success")
                        {
                            errorMessages += phoneNumberValidation + "|";
                        }
                    }

                    newRow["ErrorMessage"] = errorMessages;

                }



                dt.Rows.Add(newRow);
            }

            dataGridView1.DataSource = dt;
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("No data to upload.");
                return;
            }

            DataTable dt = (DataTable)dataGridView1.DataSource;

            if (!dt.Columns.Contains("Deleted"))
                dt.Columns.Add("Deleted", typeof(bool));

            if (!dt.Columns.Contains("PatientIdentifier"))
                dt.Columns.Add("PatientIdentifier", typeof(string));


            DataTable validTable = dt.Clone();
            DataTable invalidTable = dt.Clone();
            var identifier = "PT";
            bool hasError = false;


            foreach (DataRow row in dt.Rows)
            {
                row["Deleted"] = false;
                row["PatientIdentifier"] = identifier + "-" + row["Id"];
                if (!string.IsNullOrWhiteSpace(row["ErrorMessage"].ToString()))
                {
                    hasError = true;
                    invalidTable.ImportRow(row);
                    
                }
                else
                {
                    validTable.ImportRow(row);
                }

            }

            using var conn = DatabaseConfig.GetConnection();

            conn.Open();

            using SqlBulkCopy bulkCopy = new SqlBulkCopy(conn)
            {
                DestinationTableName = "tblPatient"
            };

            bulkCopy.ColumnMappings.Add("PatientIdentifier", "PatientIdentifier");
            bulkCopy.ColumnMappings.Add("FirstName", "Firstname");
            bulkCopy.ColumnMappings.Add("LastName", "Lastname");
            bulkCopy.ColumnMappings.Add("DOB", "DateOfBirth");
            bulkCopy.ColumnMappings.Add("Gender", "Sex");
            bulkCopy.ColumnMappings.Add("Email", "Email");
            bulkCopy.ColumnMappings.Add("MobileNumber", "Mobile");
            bulkCopy.ColumnMappings.Add("PhoneNumber", "HomePhone");
            bulkCopy.ColumnMappings.Add("Street", "AddressLine1");
            bulkCopy.ColumnMappings.Add("Suburb", "Suburb");
            bulkCopy.ColumnMappings.Add("State", "State");
            bulkCopy.ColumnMappings.Add("Postcode", "Postcode");
            bulkCopy.ColumnMappings.Add("Deleted", "IsDeleted");


            if (hasError)
            {
                MessageBox.Show("Upload failed: Please revise your patients data before uploading it again!");
            }
            else
            {
                try
                {
                    bulkCopy.WriteToServer(dt);
                    MessageBox.Show("Upload successful!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Upload failed: {ex.Message}");
                }
            }


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowPrePaint_1(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var row = grid.Rows[e.RowIndex];

            if (row.Cells["ErrorMessage"].Value != null &&
                !string.IsNullOrWhiteSpace(row.Cells["ErrorMessage"].Value.ToString()))
            {
                row.DefaultCellStyle.BackColor = Color.MistyRose; // or Color.Red
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

        }
    }
}
