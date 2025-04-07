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
    public class OwnerForm : Form
    {
        private string _firstName;
        private string _lastName;
        private byte[] _avatarImage;
        private List<string> _clinics = new List<string>();

        public OwnerForm(string firstName, string lastName)
        {
            this.Text = "Owner form";

            _lastName = lastName;
            _firstName = firstName;
  
            Label fullnamelbl = new Label();
            fullnamelbl.Text = _firstName + " "+ _lastName;
            fullnamelbl.Location = new System.Drawing.Point(20, 10);
            fullnamelbl.Size = new Size(this.Width - 100, 40);
            fullnamelbl.Font = new Font("Arial", 16);
            this.Controls.Add(fullnamelbl);

            PictureBox avatarPictureBox = new PictureBox();
            avatarPictureBox.Location = new System.Drawing.Point(this.Width - 80, 10);
            avatarPictureBox.Size = new System.Drawing.Size(40, 40);
            avatarPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

        
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
            lineSeparator.Size = new System.Drawing.Size(this.Width, 2);
            lineSeparator.Location = new System.Drawing.Point(00, 60);
            lineSeparator.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(lineSeparator);

            GetClinicsOwndedByUser();
        
            DisplayClinics();
        }
        private void GetUserAvatarImage()
        {
            string connectionString = "Server=DESKTOP-JD7EVB7\\SQLEXPRESS; Database=Session1; Integrated Security=True;";
            string query = "SELECT AvatarImage FROM [User] WHERE FirstName = @FirstName AND LastName = @LastName";

            using (SqlConnection connection = new SqlConnection(connectionString))
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
                    MessageBox.Show($"Error fetching avatar image: {ex.Message}");
                }
            }
        }

        private void GetClinicsOwndedByUser()
        {
            string connectionString = "Server=DESKTOP-JD7EVB7\\SQLEXPRESS; Database=Session1; Integrated Security=True;";
            string query = "select ShortName from Clinic where OwnerUserId = (Select UserId FROM [USER] where FirstName = @FirstName AND LastName = @Lastname)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", _firstName);
                        cmd.Parameters.AddWithValue("@LastName", _lastName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _clinics.Add(reader["ShortName"].ToString());
                            }
                        }

                    }
                } catch (Exception ex)
                {
                    MessageBox.Show($"clinic error fail : {ex.Message}");
                }
            }
        }

        private void DisplayClinics()
        {
            int xPos = 20;

            foreach (var clinic in _clinics)
            {
                Label cliniclbl = new Label();
                cliniclbl.Text = clinic;
                cliniclbl.Location = new Point(xPos, 80);
                cliniclbl.Size = new Size(100, 40);
                cliniclbl.BackColor = Color.AliceBlue;
                this.Controls.Add(cliniclbl);
                xPos += 120;
            }
        }

    }
}
