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
    public partial class DohvatiSliku : Form
    {
        public DohvatiSliku()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("server=.\\sqlexpress2019;database=Session1;integrated security=true;"))
            {
                conn.Open();

                using (SqlCommand cm = new SqlCommand("select AvatarImage from [User] where UserId=1", conn))
                {
                    cm.CommandType = CommandType.Text;

                    byte[] bytes = cm.ExecuteScalar() as byte[];

                    using (MemoryStream ms = new MemoryStream(bytes))
                        pictureBox1.Image = Bitmap.FromStream(ms);
                }
            }
        }
    }
}
