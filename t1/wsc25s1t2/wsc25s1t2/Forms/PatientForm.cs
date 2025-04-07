using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsc25s1t2.Forms
{
    public partial class PatientForm : Form
    {
        public PatientForm(string FirstName, string lastName)
        {
            this.Text = "patientForm";

            Label fullnamelbl = new Label();
            fullnamelbl.Text = FirstName + " " + lastName;
            fullnamelbl.Size = new Size(200, 30);
            fullnamelbl.Location = new Point(10, 10);
            this.Controls.Add(fullnamelbl);


            //line separator 
            Panel lineSeparator = new Panel();
            lineSeparator.Size = new Size(this.Width, 2);
            lineSeparator.Location = new Point(0, 40);
            lineSeparator.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(lineSeparator);


            Label todolbl = new Label();
            todolbl.Text = "//TODO";
            todolbl.Size = new Size(250, 50);
            todolbl.Font = new Font("Arial", 24);
            todolbl.Location = new Point(10, 70);
            this.Controls.Add(todolbl);
        }
    }
}
