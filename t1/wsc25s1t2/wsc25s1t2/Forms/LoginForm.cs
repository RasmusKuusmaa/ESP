using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using wsc25s1t2.Forms;

namespace wsc25s1t2
{
    public partial class LoginForm : Form
    {
        string connectionString = "Server=DESKTOP-JD7EVB7\\SQLEXPRESS; Database=Session1; Integrated Security=true";
        private int _tries = 0;
        Button loginbtn;

        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Login";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#ffe4cd"); // Light orange background

            Font normalFont = new Font("Arial", 10);
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);

            // Add Logo
            PictureBox logo = new PictureBox();
            logo.Image = Image.FromFile("Images/cat-1.jpg");
            logo.Size = new Size(100, 100);
            logo.Location = new Point(150, 10);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(logo);

            int startY = 120;

            // Heading
            Label headingLbl = new Label();
            headingLbl.Text = "Please Sign In";
            headingLbl.Font = headingFont;
            headingLbl.ForeColor = ColorTranslator.FromHtml("#302a77"); // Purple
            headingLbl.Location = new Point(120, startY);
            headingLbl.AutoSize = true;
            this.Controls.Add(headingLbl);

            // Email Label
            Label Emaillbl = new Label();
            Emaillbl.Text = "Email:";
            Emaillbl.Font = normalFont;
            Emaillbl.Location = new Point(50, startY + 40);
            Emaillbl.AutoSize = true;
            this.Controls.Add(Emaillbl);

            TextBox EmailtxtBox = new TextBox();
            EmailtxtBox.Font = normalFont;
            EmailtxtBox.Size = new Size(250, 20);
            EmailtxtBox.Location = new Point(50, startY + 60);
            this.Controls.Add(EmailtxtBox);

            // Password Label
            Label Passwordlbl = new Label();
            Passwordlbl.Text = "Password:";
            Passwordlbl.Font = normalFont;
            Passwordlbl.Location = new Point(50, startY + 100);
            Passwordlbl.AutoSize = true;
            this.Controls.Add(Passwordlbl);

            TextBox PasswordtxtBox = new TextBox();
            PasswordtxtBox.Font = normalFont;
            PasswordtxtBox.Size = new Size(250, 20);
            PasswordtxtBox.Location = new Point(50, startY + 120);
            PasswordtxtBox.UseSystemPasswordChar = true;
            this.Controls.Add(PasswordtxtBox);

            // Login Button
            loginbtn = new Button();
            loginbtn.Text = "Sign In";
            loginbtn.Font = normalFont;
            loginbtn.BackColor = ColorTranslator.FromHtml("#eebb55"); // Orange
            loginbtn.ForeColor = Color.Black;
            loginbtn.Size = new Size(100, 40);
            loginbtn.Location = new Point(150, startY + 170);
            loginbtn.Click += (sender, e) => loginbtn_click(sender, e, EmailtxtBox, PasswordtxtBox);
            this.Controls.Add(loginbtn);
        }

        private void loginbtn_click(object sender, EventArgs e, TextBox EmailtxtBox, TextBox PasswordtxtBox)
        {
            string email = EmailtxtBox.Text;
            string password = PasswordtxtBox.Text;
            string query = "SELECT FirstName, LastName, RoleId FROM [USER] WHERE EMailAddress = @Email AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int roleId = Convert.ToInt32(reader["RoleId"]);
                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();

                                if (roleId == 3)
                                {
                                    PatientForm patientForm = new PatientForm(firstName, lastName);
                                    patientForm.Show();
                                    this.Hide();
                                }
                                else if (roleId == 2)
                                {
                                    // Future role logic
                                }
                            }
                            else
                            {
                                _tries++;
                                if (_tries >= 3)
                                {
                                    EmailtxtBox.Enabled = false;
                                    PasswordtxtBox.Enabled = false;
                                    loginbtn.Enabled = false;
                                    MessageBox.Show("Further login disabled. Please contact the administrator.");
                                }
                                else
                                {
                                    MessageBox.Show("Login Failed");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed: {ex.Message}");
                }
            }
        }
    }
}
