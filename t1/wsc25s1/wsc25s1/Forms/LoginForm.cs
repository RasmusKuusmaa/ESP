using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using wsc25s1.Forms;
using System.Configuration;

namespace wsc25s1
{
    public class LoginForm : Form
    {
        int Fails = 0;
        private Button btnLogin;
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

        public LoginForm()
        {
            this.Text = "Login Form";
            this.Size = new System.Drawing.Size(300, 180);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblEmail = new Label();
            lblEmail.Location = new System.Drawing.Point(50, 5);
            lblEmail.Size = new System.Drawing.Size(150, 20);
            lblEmail.Text = "Email";

            TextBox txtEmail = new TextBox();
            txtEmail.Location = new System.Drawing.Point(50, 25);
            txtEmail.Size = new System.Drawing.Size(100, 30);

            Label lblPassword = new Label();
            lblPassword.Location = new System.Drawing.Point(50, 55);
            lblPassword.Size = new System.Drawing.Size(150, 20);
            lblPassword.Text = "Password";

            TextBox txtpassword = new TextBox();
            txtpassword.Location = new System.Drawing.Point(50, 75);
            txtpassword.Size = new System.Drawing.Size(100, 30);
            txtpassword.UseSystemPasswordChar = true;
                
            btnLogin = new Button();
            btnLogin.Location = new System.Drawing.Point(50, 110);
            btnLogin.Text = "SIGN IN";
            btnLogin.Size = new System.Drawing.Size(60, 30);
            btnLogin.Click += (sender, e) => btnLogin_Click(sender, e, txtEmail, txtpassword);
            //btnLogin.Click += (sender, e) => testDbConnection(sender, e);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtpassword);
            this.Controls.Add(btnLogin);
        }

        private void testDbConnection(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection successful!");
             
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}");
                }
            }
        }

        private void ShowCaptcha()
        {

        }
        private void btnLogin_Click(object sender, EventArgs e, TextBox txtEmail, TextBox txtPassword)
        {
            string Email = txtEmail.Text;
            string password = txtPassword.Text;

            string query = "SELECT FirstName, LastName, RoleId FROM [User] where EMailAddress = @Email AND Password = @Password";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {


                                string firstName = reader.GetString(0);
                                string lastName = reader.GetString(1);
                                int roleId = reader.GetInt32(2);
                                if (Fails > 2)
                                {
                                    CaptchaForm captchaForm = new CaptchaForm(firstName, lastName, roleId);
                                    captchaForm.Show();
                                    this.Hide();
                                }
                                if (roleId == 3)
                                {
                                    PatientForm patientForm = new PatientForm(firstName, lastName);
                                    patientForm.Show();
                                    this.Hide();
                                    
                                }

                                else if (roleId == 2)
                                {
                                    OwnerForm ownderForm = new OwnerForm(firstName, lastName);
                                    ownderForm.Show();
                                    this.Hide();
                                }
                                else if (roleId == 1)
                                {
                                    AdminForm adminForm = new AdminForm(firstName, lastName);
                                    adminForm.Show();
                                    this.Hide();
                                }
                            }
                            else
                               {
                                    if (Fails < 2)
                                {
                                    MessageBox.Show("oh no wrong pass bitch");

                                } else
                                {
                                    

                                    txtEmail.Enabled = false;
                                    txtPassword.Enabled = false;
                                    btnLogin.Enabled = false;
                                    MessageBox.Show("Further login disabled, please contact the administrator");
                                }


                                Fails++;

                                   
                                    
                               }
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}");
                }
            }
        }
    }
}
