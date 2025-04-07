using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarbinaryStuff
{
    public partial class SpremiSlikuUBazu : Form
    {
        public SpremiSlikuUBazu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bytes = File.ReadAllBytes("C:\\GoogleDrive\\DRŽAVNA RAZINA-WSC-2023\\Generalno\\assets\\users\\robert.png");


            using (SqlConnection conn = new SqlConnection("server=.\\sqlexpress2019;database=Session1;integrated security=true;"))
            {
                conn.Open();

                using (SqlCommand cm = new SqlCommand("SaveImage", conn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add(new SqlParameter("@Id", int.Parse(txtUserId.Text)));
                    cm.Parameters.Add(new SqlParameter("@Data", SqlDbType.VarBinary, bytes.Length, ParameterDirection.Input, false, 0, 0, "Data", DataRowVersion.Current, (SqlBinary)bytes));

                    cm.ExecuteNonQuery();
                }
            }

            lblInfo.Text = "Spremio.";
        }
    }
}
