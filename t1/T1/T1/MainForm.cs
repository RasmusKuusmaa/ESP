using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1
{
    public class MainForm : Form
    {
       public MainForm()
        {
            this.Text = "Test app 1 - Main Menu";
            this.Size = FormSettings.DefaultFormSize;
            this.StartPosition = FormSettings.DefaultFormStartPosition;

            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem menu = new ToolStripMenuItem("menu");
            menu.DropDownItems.Add("Edit Codebook");
            menu.DropDownItems.Add("Isotopes");
            menu.DropDownItems.Add("Connections");
            menu.DropDownItems.Add("Periodic Table");

            menuStrip.Items.Add(menu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            var buttonSize = new System.Drawing.Size(100, 150);


            Button btnCodeBook = new Button()
            {
                Text = "Edit Codebook",
                Location = new System.Drawing.Point(50, 100),
                Size = buttonSize,
                TextAlign = System.Drawing.ContentAlignment.BottomCenter,

            };
            btnCodeBook.Click += (sender, e) =>
            {
                EditCodebookForm editForm = new EditCodebookForm();
                editForm.Show();
                this.Hide();
            };

            Button btnIsotopes = new Button()
            {
                Text = "Isotopes",
                Size = buttonSize,
                Location = new System.Drawing.Point(175, 100),
                TextAlign = System.Drawing.ContentAlignment.BottomCenter,

            };

            Button btnConnections = new Button()
            {
                Text = "Connections",
                Size = buttonSize,
                Location = new System.Drawing.Point(300, 100),
                TextAlign = System.Drawing.ContentAlignment.BottomCenter,

            };

            Button btnPeriodic = new Button()
            {
                Text = "Periodic table",
                Size = buttonSize,
                Location = new System.Drawing.Point(425, 100),
                TextAlign = System.Drawing.ContentAlignment.BottomCenter,
            };

            this.Controls.Add(btnCodeBook);
            this.Controls.Add(btnIsotopes);
            this.Controls.Add(btnConnections);
            this.Controls.Add(btnPeriodic);
        
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
