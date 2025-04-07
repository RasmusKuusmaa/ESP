using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1
{
    public partial class EditCodebookForm : Form
    {
        public EditCodebookForm()
        {
            this.Size = FormSettings.DefaultFormSize;
            this.Text = "Edid Codebook";
            this.StartPosition = FormSettings.DefaultFormStartPosition;

            Button btnBack = new Button()
            {
                Text = "back to main screen",
                Size = new System.Drawing.Size(100, 50),
                Location = new System.Drawing.Point(450, 250)

            };
            btnBack.Click += (sender, e) =>
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            };

            this.Controls.Add(btnBack);

            InitializeUI();
        }

        private void InitializeUI()
        {
            TabControl tabControl = new TabControl()
            {
                Dock = DockStyle.Top,
                Height = 100
            };
                  TabPage tabTypeTable = new TabPage("Edit Type Table");
            tabTypeTable.Controls.Add(new Label()
            {
                Text = "Type Table content will go here.",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            });

            // Tab for "Connection table"
            TabPage tabConnectionTable = new TabPage("Connection Table");
            tabConnectionTable.Controls.Add(new Label()
            {
                Text = "Connection Table content will go here.",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            });

            // Add the tabs to the TabControl
            tabControl.TabPages.Add(tabTypeTable);
            tabControl.TabPages.Add(tabConnectionTable);

          
            this.Controls.Add(tabControl);
        
        

        }
    }
}
