using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace wsc25s1t2.Forms
{
    public partial class CaptchaForm : Form
    {
        private HashSet<PictureBox> selectedImages = new HashSet<PictureBox>();
        public CaptchaForm()
        {
            InitializeComponent();
            this.Text = "captcha";

            LoadCaptchaImages();
        }

        private void LoadCaptchaImages()
        {
            var images = new List<(string filePath, bool isCorrect)>
            {
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "cat-1.jpg"), true),
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "cat-2.jpg"), true),
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "no-cat.jpg"), false),

            };
            var random = new Random();
            var selectedImagesList = images.OrderBy(x => random.Next()).Take(3).ToList();

            Label tit = new Label();
            tit.Text = "choose cats";
            tit.Location = new Point(10, 10);
            this.Controls.Add(tit);

            int startX = 10;
            int startY = 50;
            int spacing = 150;
            for (int i =0; i < selectedImagesList.Count; i++)
            {
                var(file, isCorrect) = selectedImagesList[i];
                PictureBox pb = new PictureBox
                {
                    Image = Image.FromFile(file),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(startX + i * spacing, startY),
                    Size = new Size(120, 120),
                    Cursor = Cursors.Hand,
                    
                    Tag = isCorrect,
                };
                pb.Click += (sender, e) => ToggleSelection(pb);
                this.Controls.Add(pb);
            };
            
            Button doneButton = new Button
            {
                Text = "Continue",
                Location = new Point(10, 200),

            };
            doneButton.Click += DoneButton_cliock;
            this.Controls.Add(doneButton);
        }

        private void ToggleSelection(PictureBox pb)
        {
            if (selectedImages.Contains(pb))
            {
                selectedImages.Remove(pb);
                pb.BackColor = Color.Transparent;

                pb.Paint -= PictureBox_Paint;
            }
            else
            {
                selectedImages.Add(pb);
                pb.BackColor = Color.Green; 

                pb.Paint += PictureBox_Paint;
            }
        }
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb == null) return;

            int borderThickness = 5;
            Color borderColor = Color.Green;

            ControlPaint.DrawBorder(e.Graphics, pb.ClientRectangle,
                borderColor, borderThickness, ButtonBorderStyle.Solid,
                borderColor, borderThickness, ButtonBorderStyle.Solid,
                borderColor, borderThickness, ButtonBorderStyle.Solid,
                borderColor, borderThickness, ButtonBorderStyle.Solid);
        }

        private void DoneButton_cliock(object sender, EventArgs e)
        {
            bool allCorrect = selectedImages.All(pb => (bool)pb.Tag == true);


            if (allCorrect && selectedImages.Count == 2)
            {
                MessageBox.Show("true");
            } 
            else
            {
                this.Controls.Clear();
                Label faillbl = new Label();
                faillbl.Size = new Size(300, 30);
                faillbl.Text = "you failed to prove that you are a humna being, please contact the administrator";
                faillbl.Location = new Point(10, 10);
                this.Controls.Add(faillbl);


            }
        }


    }
}
