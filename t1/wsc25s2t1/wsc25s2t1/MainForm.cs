using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace wsc25s2t1
{
    public partial class MainForm : Form
    {
        private string _connectionString = "Server=DESKTOP-JD7EVB7\\SQLEXPRESS; Database=Session2; Integrated Security = True";
        public MainForm()
        {
            InitializeComponent();
            LoadClinicTypes();
            LoadClinics();
        }
        private void LoadClinics()
        {
            string query = @"SELECT Clinic.Name, ClinicType.Name AS ClinicType, Clinic.Description, Clinic.OwnerUserId, Clinic.Address, 
                     City.Name AS CityName, Country.Name AS CountryName
                     FROM Clinic
                     INNER JOIN ClinicType ON Clinic.ClinicTypeId = ClinicType.ClinicTypeId
                     INNER JOIN City ON Clinic.CityId = City.CityId
                     INNER JOIN Country ON City.CountryId = Country.CountryId";

            string selectedClinicType = ClinicTypeFilterComboBox.SelectedItem?.ToString()?.ToLower();

            int? clinicTypeId = null;

            // Apply filter only if a specific clinic type is selected (and not "All Clinics")
            if (selectedClinicType != "all clinics" && !string.IsNullOrEmpty(selectedClinicType))
            {
                // Map the clinic type string to the respective ClinicTypeId
                switch (selectedClinicType)
                {
                    case "medical":
                        clinicTypeId = 1;
                        break;
                    case "dental":
                        clinicTypeId = 2;
                        break;
                    case "veterinary":
                        clinicTypeId = 3;
                        break;
                    default:
                        MessageBox.Show("Invalid clinic type selected.");
                        return;
                }

                // Add the WHERE condition for ClinicTypeId (add this after the SELECT statement)
                query += " WHERE Clinic.ClinicTypeId = @ClinicTypeId";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // If a filter is applied, add the parameter for the query
                    if (clinicTypeId.HasValue)
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@ClinicTypeId", clinicTypeId.Value);
                    }

                    DataTable clinicTable = new DataTable();
                    dataAdapter.Fill(clinicTable);
                    Clinicdgv.DataSource = clinicTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to connect: {ex.Message}");
                }
            }
        }

        private void LoadClinicTypes()
        {
            ClinicTypeFilterComboBox.Items.Clear();  // Clear existing items
            ClinicTypeFilterComboBox.Items.Add("All Clinics");

            // Fetch clinic types from the database
            string query = "SELECT ClinicTypeId, Name FROM ClinicType";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable clinicTypeTable = new DataTable();
                    dataAdapter.Fill(clinicTypeTable);

                    // Populate ComboBox with clinic types
                    foreach (DataRow row in clinicTypeTable.Rows)
                    {
                        ClinicTypeFilterComboBox.Items.Add(row["Name"].ToString());
                    }

                    // Set default selection
                    ClinicTypeFilterComboBox.SelectedIndex = 0;  // Default to "All Clinics"
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load clinic types: {ex.Message}");
                }
            }
        }
        private void ClinicTypeFilterComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadClinics();

        }




        private void ClinicTypeFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ComboBox selection changed to: " + ClinicTypeFilterComboBox.SelectedItem?.ToString());
            LoadClinics();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ComboBox selection changed to: " + ClinicTypeFilterComboBox.SelectedItem?.ToString());

            LoadClinics();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Clinicdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
