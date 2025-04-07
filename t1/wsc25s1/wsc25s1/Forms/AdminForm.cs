using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace wsc25s1.Forms
{
    public class AdminForm : Form
    {
        string _firstName;
        string _lastName;
        private byte[] _avatarImage;
        private int _PatientCount = 0;
        private int _OwnerCount = 0;
        private int _AdminCount = 0;
        private string _connectionString = "Server=DESKTOP-JD7EVB7\\SQLEXPRESS; Database=Session1; Integrated Security=True;";

        private Label totadminlbl; 
        private Label totclinicOwnerslbl;
        private Label totPatientslbl;
        public AdminForm(string firstName, string lastName)
        {
            this.Text = "admin form";

            _lastName = lastName;
            _firstName = firstName;

            Label fullNamelbl = new Label();
            fullNamelbl.Text = _firstName + " " + _lastName;
            fullNamelbl.Location = new System.Drawing.Point(10, 20);
            fullNamelbl.Size = new Size(this.Width - 100, 40);
            fullNamelbl.Font = new Font("Arial", 16);
            this.Controls.Add(fullNamelbl);

            PictureBox avatarPictureBox = new PictureBox();
            avatarPictureBox.Size = new Size(40, 40);
            avatarPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            avatarPictureBox.Location = new Point(this.Width - 70, 10);
            GetUserAvatarImage();
            if (_avatarImage != null)
            {
                using (MemoryStream ms = new MemoryStream(_avatarImage))
                {
                    avatarPictureBox.Image = Image.FromStream(ms);
                }
            }
            this.Controls.Add(avatarPictureBox);

            Panel lineSeparator = new Panel();
            lineSeparator.Size = new Size(this.Width, 2);
            lineSeparator.Location = new Point(0, 60);
            lineSeparator.BackColor = Color.Black;
            this.Controls.Add(lineSeparator);



            Panel statsBox = new Panel();
            statsBox.BorderStyle = BorderStyle.FixedSingle;
            statsBox.Location = new Point(30, 80);
            statsBox.Size = new Size(150, 100);
            this.Controls.Add(statsBox);

            LoadUserCounts();


             totadminlbl = new Label();
            totadminlbl.Text = $"Total Administrators: {_AdminCount}";
            totadminlbl.Name = "totAdminLbl";
            totadminlbl.Size = new Size(150, 20);
            totadminlbl.Location = new Point(5, 5);
            statsBox.Controls.Add(totadminlbl);

            totclinicOwnerslbl = new Label();
            totclinicOwnerslbl.Text = $"Total Owners: {_OwnerCount}";
            totclinicOwnerslbl.Size = new Size(150, 30);
            totclinicOwnerslbl.Name = "totclinicOwnerslbl";
            totclinicOwnerslbl.Location = new Point(5, 35);
            statsBox.Controls.Add(totclinicOwnerslbl);

             totPatientslbl = new Label();
            totPatientslbl.Name = "totPatientslbl";
            totPatientslbl.Text = $"Total Patients: {_PatientCount}";
            totPatientslbl.Size = new Size(150, 30);
            totPatientslbl.Location = new Point(5, 65);
            statsBox.Controls.Add(totPatientslbl);


            Button csvbtn = new Button();
            csvbtn.Text = "Import Patients";
            csvbtn.Size = new Size(75, 35);
            csvbtn.Location = new Point(30, 190);
            csvbtn.Click += (sender, e) => ImportPatientsFromCsv();
            this.Controls.Add(csvbtn);
        }


        private void GetUserAvatarImage()
        {

            string query = "SELECT AvatarImage FROM [USER] WHERE FirstName = @FirstName AND LastName = @LastName";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", _firstName);
                        cmd.Parameters.AddWithValue("@LastName", _lastName);
                        _avatarImage = cmd.ExecuteScalar() as byte[];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"f{ex.Message}");
                }

            }
        }
        private void UpdateStatsLabels()
        {
            
            if (totadminlbl != null)
                totadminlbl.Text = $"Total Administrators: {_AdminCount}";
            if (totclinicOwnerslbl != null)
                totclinicOwnerslbl.Text = $"Total Owners: {_OwnerCount}";
            if (totPatientslbl != null)
                totPatientslbl.Text = $"Total Patients: {_PatientCount}";

        }


        private void LoadUserCounts()
        {
         
            _AdminCount = 0;
            _OwnerCount = 0;
            _PatientCount = 0;

            string query = "SELECT RoleId, COUNT(*) as Count FROM [User] GROUP BY RoleId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roleId = Convert.ToInt32(reader["RoleId"]);
                            int count = Convert.ToInt32(reader["Count"]); 

                            if (roleId == 1)
                            {
                                _AdminCount = count; 
                            }
                            else if (roleId == 2)
                            {
                                _OwnerCount = count; // 
                            }
                            else if (roleId == 3)
                            {
                                _PatientCount = count;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load user counts: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ImportPatientsFromCsv()
        {
         
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files | *.csv";
            openFileDialog.Title = "Select the csv file to import";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    var lines = File.ReadAllLines(filePath);
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        foreach (var line in lines.Skip(1))
                        {
                            var columns = line.Split(';');
                            if (columns.Length < 4) continue;

                            string firstName = columns[0];
                            string lastName = columns[1];
                            string email = columns[2];
                            string password = columns[3];
                            string query = @"
                                Insert INTO [User] (FirstName, LastName, EMailAddress, Password, CreatedDate, UpdatedDate, AvatarImage, RoleId) 
                                Values (@FirstName, @LastName, @Email, @Password, GETDATE(), GETDATE(), NULL, 3)";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@FirstName", firstName);
                                cmd.Parameters.AddWithValue("@LastName", lastName);
                                cmd.Parameters.AddWithValue("@Email", email);
                                cmd.Parameters.AddWithValue("@Password", password);

                                cmd.ExecuteNonQuery();
                            }
                            


                        }
                        LoadUserCounts();
                        UpdateStatsLabels();
                        this.Refresh();

                        MessageBox.Show("Patients imported successfully!");
                    }
                } catch(Exception ex)
                {
                    MessageBox.Show($"failed to connect: {ex.Message}");
                }
            }
        }

    }
}
