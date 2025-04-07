using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace wsc25s1.Forms
{
    public class PatientForm : Form
    {
        private string _firstName;
        private string _lastName;
        public PatientForm(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;

            this.Text = "Patient";

            Label fullnamelbl = new Label();
            fullnamelbl.Text = _firstName + "  " + _lastName;
            fullnamelbl.Location = new System.Drawing.Point(20, 10);
            this.Controls.Add(fullnamelbl);

            Panel lineSeparator = new Panel();
            lineSeparator.Size = new System.Drawing.Size(this.Width, 2);
            lineSeparator.Location = new System.Drawing.Point(00, 40);
            lineSeparator.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(lineSeparator);


            //todo label
            Label todo = new Label();
            todo.Text = "//TODO";
            todo.Location = new System.Drawing.Point(20, 60);
            todo.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            this.Controls.Add(todo);

        }
    }
}
