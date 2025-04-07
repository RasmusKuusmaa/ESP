using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public partial class CaptchaForm : Form
{
    private string firstName;
    private string lastName;
    private int roleId;

    private List<(PictureBox pictureBox, bool isCat)> imageBoxes = new List<(PictureBox pictureBox, bool isCat)>();
    private HashSet<PictureBox> selectedImages = new HashSet<PictureBox>();
    private Label resultLabel;
    private Button doneButton;

    public CaptchaForm(string firstName, string lastName, int roleId)
    {

        this.firstName = firstName;
        this.lastName = lastName;
        this.roleId = roleId;

        this.Text = "Captcha Form";
        this.Size = new Size(600, 400);

        LoadCaptchaImages();
    }

    private void LoadCaptchaImages()
    {
        var images = new List<(string filePath, bool isCat)>
        {
        (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "cat-1.jpg"), true),
        (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "cat-2.jpg"), true),
        (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "no-cat.jpg"), false),


        };

        var random = new Random();
        var selectedImagesList = images.OrderBy(x => random.Next()).Take(3).ToList();

        int startX = 50;
        int y = 50;
        int spacing = 150;

        for (int i = 0; i < selectedImagesList.Count; i++)
        {
            var (file, isCat) = selectedImagesList[i];

            PictureBox pb = new PictureBox
            {
                Image = Image.FromFile(file),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(startX + i * spacing, y),
                Size = new Size(120, 120),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = isCat
            };

            pb.Click += (s, e) => ToggleSelection(pb);

            this.Controls.Add(pb);
            imageBoxes.Add((pb, isCat));
        }

        doneButton = new Button
        {
            Text = "DONE",
            Location = new Point(250, 200),
            AutoSize = true
        };
        doneButton.Click += DoneButton_Click;
        this.Controls.Add(doneButton);

        resultLabel = new Label
        {
            Location = new Point(50, 250),
            Size = new Size(500, 50),
            ForeColor = Color.Red,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        this.Controls.Add(resultLabel);
    }

    private void ToggleSelection(PictureBox pb)
    {
        if (selectedImages.Contains(pb))
        {
            selectedImages.Remove(pb);
            pb.BackColor = Color.Transparent;
            pb.BorderStyle = BorderStyle.FixedSingle;
        }
        else
        {
            selectedImages.Add(pb);
            pb.BackColor = Color.LightGreen;
            pb.BorderStyle = BorderStyle.Fixed3D;
        }
    }

    private void DoneButton_Click(object sender, EventArgs e)
    {
        var correct = imageBoxes.Where(box => box.isCat).Select(box => box.pictureBox).ToHashSet();

        if (selectedImages.SetEquals(correct))
        {
            MessageBox.Show("good");
        }
        else
        {
            foreach (var control in this.Controls.OfType<Control>().Where(c => c != resultLabel).ToList())
                this.Controls.Remove(control);

            resultLabel.Text = "You failed to prove that you are a human being, please contact the administrator.";
        }
    }

    
}
