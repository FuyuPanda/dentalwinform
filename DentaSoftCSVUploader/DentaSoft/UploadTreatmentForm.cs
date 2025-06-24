using DentaSoft.Common.Validation;
using DentaSoft.Model;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace DentaSoft
{
    public partial class UploadTreatmentForm : Form
    {
        public UploadTreatmentForm()
        {
            InitializeComponent();
        }

        private void UploadTreatmentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Select Treatment CSV File"
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

            HashSet<string> existingIds = new HashSet<string>();

            using (var conn = DatabaseConfig.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT PatientIdentifier FROM tblPatient", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    existingIds.Add(reader.GetString(0));
                }
            }

            string[] headers = parser.ReadFields();
            foreach (string header in headers)
                dt.Columns.Add(header);

            dt.Columns.Add("ErrorMessage");

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                var newRow = dt.NewRow();
                string errorMessage = "";

                for (var i = 0; i < headers.Length; i++)
                {
                    newRow[i] = fields[i];

                    if (headers[i].Equals("PatientID"))
                    {
                        var patientID = "PT-" + newRow["PatientID"].ToString();
                        if (!existingIds.Contains(patientID))
                        {
                            errorMessage += "Please Upload Patient Data First|";

                        }
                    }
                    newRow["ErrorMessage"] = errorMessage;
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

            if (!dt.Columns.Contains("IsVoided"))
                dt.Columns.Add("IsVoided", typeof(bool));

            if (!dt.Columns.Contains("TreatmentIdentifier"))
                dt.Columns.Add("TreatmentIdentifier", typeof(string));


            if (!dt.Columns.Contains("Quantity"))
                dt.Columns.Add("Quantity", typeof(int));


            DataTable validTable = dt.Clone();
            DataTable invalidTable = dt.Clone();
            var identifier = "TR";
            bool hasError = false;

            List<TreatmentModel> treatments = new List<TreatmentModel>();

            foreach (DataRow row in dt.Rows)
            {
                
                if (row["Paid"].ToString()=="Yes")
                {
                    row["Paid"] = true;
                }
                else
                {
                    row["Paid"] = false;
                }
                row["IsVoided"] = false;
                row["Quantity"] = 1;
                var treatmentIdentifier = treatments.Where(a=>a.Date.Date == DateTime.Parse(row["Date"].ToString()).Date && a.PatientID == int.Parse(row["PatientID"].ToString())).Select(a=>a.TreatmentIdentifier).FirstOrDefault();
                if(!string.IsNullOrEmpty(treatmentIdentifier))
                {
                    row["TreatmentIdentifier"] = treatmentIdentifier;
                }
                else
                {
                    row["TreatmentIdentifier"] = identifier + "-" + row["Id"];
                    treatmentIdentifier = identifier + "-" + row["Id"];

                }
                
                if (!string.IsNullOrWhiteSpace(row["ErrorMessage"].ToString()))
                {
                    hasError = true;
                    invalidTable.ImportRow(row);

                }
                else
                {
                    validTable.ImportRow(row);
                }
                treatments.Add(new TreatmentModel()
                {
                    TreatmentIdentifier = treatmentIdentifier,
                    Date = DateTime.Parse(row["Date"].ToString()),
                    DentistID = int.Parse(row["DentistID"].ToString()),
                    PatientID = int.Parse(row["PatientID"].ToString()),
                    Description = row["Description"].ToString(),
                    Fee = decimal.Parse(row["Fee"].ToString()),
                    Paid = row["Paid"].ToString(),
                    Price = decimal.Parse(row["Price"].ToString()),
                    Surface  = row["Description"].ToString(),
                    ToothNumber = row["ToothNumber"].ToString(),
                    TreatmentItem = row["TreatmentItem"].ToString(),
                    Quantity=1
                }
                );

            }

            using var conn = DatabaseConfig.GetConnection();

            conn.Open();

            using SqlBulkCopy bulkCopy = new SqlBulkCopy(conn)
            {
                DestinationTableName = "tblTreatment"
            };

            bulkCopy.ColumnMappings.Add("PatientID", "PatientId");
            bulkCopy.ColumnMappings.Add("TreatmentIdentifier", "TreatmentIdentifier");
            bulkCopy.ColumnMappings.Add("TreatmentItem", "ItemCode");
            bulkCopy.ColumnMappings.Add("Description", "Description");
            bulkCopy.ColumnMappings.Add("ToothNumber", "Tooth");
            bulkCopy.ColumnMappings.Add("Surface", "Surface");
            bulkCopy.ColumnMappings.Add("Fee", "Fee");
            bulkCopy.ColumnMappings.Add("Paid", "IsPaid");
            bulkCopy.ColumnMappings.Add("IsVoided", "IsVoided");
            bulkCopy.ColumnMappings.Add("Quantity", "Quantity");
            


            if (hasError)
            {
                MessageBox.Show("Upload failed: Please revise your patients data before uploading it again!");
            }
            else
            {
                try
                {
                    bulkCopy.WriteToServer(dt);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Upload failed: {ex.Message}");
                }

                //List of treatments that occured on the same day
                var groupedInvoices = treatments
               .GroupBy(t => new { t.TreatmentIdentifier,t.TreatmentItem,t.PatientID, t.Date.Date })
            .Select(group => new
            {
                TreatmentIdentifier = group.Key.TreatmentIdentifier,
                Date = group.Key.Date,
                DentistID = group.First().DentistID,
                PatientID = group.Key.PatientID,
                Description = group.First().Description,
                Fee = group.First().Fee,
                Paid = group.First().Paid,
                Price = group.First().Price,
                Surface = group.First().Surface,
                ToothNumber = group.First().ToothNumber,
                TreatmentItem = group.Key.TreatmentItem
            }).ToList();
                if (groupedInvoices.Count > 0)
                {
                    using var trx = conn.BeginTransaction();
                    var invoiceNo = 1;
                    foreach(var items in groupedInvoices)
                    {
                        //insert invoice one by one then inserting into invoice details
                        //Validate whether invoice has been created before
                        string selectInvoiceQuery = "Select * From tblInvoice where PatientId = @PatientID And InvoiceDate = @Date";
                        using var cmdSelectInvoice = new SqlCommand(selectInvoiceQuery, conn,trx);
                        cmdSelectInvoice.Parameters.AddWithValue("@PatientID", items.PatientID);
                        cmdSelectInvoice.Parameters.AddWithValue("@Date", items.Date.Date);

                        var adapter = new SqlDataAdapter(cmdSelectInvoice);
                        var table = new DataTable();

                        try
                        {
                            adapter.Fill(table);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to load data: " + ex.Message);
                        }

                        int invoiceId = 0;

                        if (table.Rows.Count > 0)
                        {
                            //get invoice id from existing invoice
                            invoiceId = Convert.ToInt32(table.Rows[0]["InvoiceId"]);
                        }

                        else
                        {
                            //Create new Invoice if the invoice had not created
                            string insertInvoiceQuery = @"
                             INSERT INTO tblInvoice (InvoiceIdentifier
                            ,InvoiceNo
                            ,InvoiceDate
                            ,DueDate
                            ,Note
                            ,Total
                            ,Paid
                            ,Discount
                            ,PatientId
                            ,IsDeleted)
                             OUTPUT INSERTED.InvoiceID
                             VALUES (@InvoiceIdentifier, @InvoiceNo, @InvoiceDate,@DueDate,@Note,@Total,@Paid,@Discount,@PatientId,@IsDeleted)";
                            identifier = "INV";
                            var invoiceLine = InvoiceNoGenerator(identifier);
                            

                            using var cmdInvoice = new SqlCommand(insertInvoiceQuery, conn, trx);
                            cmdInvoice.Parameters.AddWithValue("@InvoiceIdentifier", invoiceLine);
                            cmdInvoice.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                            cmdInvoice.Parameters.AddWithValue("@InvoiceDate", items.Date);
                            cmdInvoice.Parameters.AddWithValue("@DueDate", items.Date.AddDays(14));
                            cmdInvoice.Parameters.AddWithValue("@Note", items.Paid == "True" ? "Paid" : "Not Fully Paid");
                            cmdInvoice.Parameters.AddWithValue("@Total", groupedInvoices.Where(x => x.Date == items.Date && x.PatientID == x.PatientID).Sum(x => x.Fee));
                            cmdInvoice.Parameters.AddWithValue("@Paid", groupedInvoices.Where(x => x.Date == items.Date && x.PatientID == x.PatientID && x.Paid == "True").Sum(x => x.Fee));
                            cmdInvoice.Parameters.AddWithValue("@Discount", 0);
                            cmdInvoice.Parameters.AddWithValue("@PatientId", items.PatientID);
                            cmdInvoice.Parameters.AddWithValue("@IsDeleted", false);

                            invoiceId = (int)cmdInvoice.ExecuteScalar();

                        }

                        
                        //Get all treatment data by PatientID and TreatmentIdentifier
                        string selectTreatmentQuery = "Select * From tblTreatment where PatientId = @PatientID And TreatmentIdentifier = @TreatmentIdentifier";
                        using var cmdSelectTreatment = new SqlCommand(selectTreatmentQuery, conn,trx);
                        cmdSelectTreatment.Parameters.AddWithValue("@PatientID", items.PatientID);
                        cmdSelectTreatment.Parameters.AddWithValue("@TreatmentIdentifier", items.TreatmentIdentifier);

                        adapter = new SqlDataAdapter(cmdSelectTreatment);
                        table = new DataTable();

                        try
                        {
                            adapter.Fill(table);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to load data: " + ex.Message);
                        }

                        List<TblTreatmentModel> treatment_data = new List<TblTreatmentModel>();

                        for (var i = 0; i < table.Rows.Count; i++)
                        {
                            treatment_data.Add(new TblTreatmentModel { TreatmentId=Convert.ToInt32(table.Rows[i]["TreatmentId"]),IsPaid = (bool)table.Rows[i]["IsPaid"] });
                        }

                        foreach(var treatmentid in treatment_data)
                        {
                            string insertInvoiceLineQuery = @"
                             INSERT INTO tblInvoiceLineItem (InvoiceLineItemIdentifier
                            ,Description
                            ,ItemCode
                            ,Quantity
                            ,UnitAmount
                            ,LineAmount
                            ,PatientId
                            ,TreatmentId
                            ,InvoiceId
                            )
                             OUTPUT INSERTED.InvoiceLineItemID
                             VALUES (@InvoiceLineItemIdentifier, @Description, @ItemCode,@Quantity,@UnitAmount,@LineAmount,@PatientId,@TreatmentId,@InvoiceId)";

                            identifier = "INVL";
                            var invoiceLineItem = InvoiceNoGenerator(identifier);

                            using var cmdInvoiceLine = new SqlCommand(insertInvoiceLineQuery, conn, trx);
                            cmdInvoiceLine.Parameters.AddWithValue("@InvoiceLineItemIdentifier", invoiceLineItem);
                            cmdInvoiceLine.Parameters.AddWithValue("@Description", items.Description);
                            cmdInvoiceLine.Parameters.AddWithValue("@ItemCode", items.TreatmentItem);
                            cmdInvoiceLine.Parameters.AddWithValue("@Quantity", 1);
                            cmdInvoiceLine.Parameters.AddWithValue("@UnitAmount", 1);
                            cmdInvoiceLine.Parameters.AddWithValue("@LineAmount", 1);
                            cmdInvoiceLine.Parameters.AddWithValue("@PatientId", items.PatientID);
                            cmdInvoiceLine.Parameters.AddWithValue("@TreatmentId", treatmentid.TreatmentId);
                            cmdInvoiceLine.Parameters.AddWithValue("@InvoiceId", invoiceId);
                            cmdInvoiceLine.ExecuteScalar();

                            if(items.Paid=="True")
                            {

                                string updateQuery = "Update tblTreatment Set InvoiceId = @InvoiceID, CompleteDate = @CompleteDate where TreatmentId = @TreatmentID";
                                using var cmdUpdateTreatment = new SqlCommand(updateQuery, conn, trx);
                                cmdUpdateTreatment.Parameters.AddWithValue("@TreatmentID", treatmentid.TreatmentId);
                                cmdUpdateTreatment.Parameters.AddWithValue("@InvoiceID", invoiceId);
                                cmdUpdateTreatment.Parameters.AddWithValue("@CompleteDate", items.Date.Date);
                                cmdUpdateTreatment.ExecuteScalar();

                            }
                            else
                            {

                                string updateQuery = "Update tblTreatment Set InvoiceId = @InvoiceID where TreatmentId = @TreatmentID";
                                using var cmdUpdateTreatment = new SqlCommand(updateQuery, conn, trx);
                                cmdUpdateTreatment.Parameters.AddWithValue("@TreatmentID", treatmentid.TreatmentId);
                                cmdUpdateTreatment.Parameters.AddWithValue("@InvoiceID", invoiceId);
                                
                                cmdUpdateTreatment.ExecuteScalar();
                            }


                        }
                        
                        invoiceNo++;

                    }
                    trx.Commit();
                    MessageBox.Show("Upload successful!");


                }



            }

            conn.Close();

 

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
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

        private string InvoiceNoGenerator(string identifier)
        {
            string chars = "0123456789";
            Random random = new Random();
            string character = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            if (!string.IsNullOrEmpty(identifier))
            {
                return identifier + character;

            }
            return character;

            
        }
    }
}
