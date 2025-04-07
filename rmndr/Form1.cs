using System;
using System.Windows.Forms;

public class MainForm : Form
{
    private System.Windows.Forms.Timer timer;

    public MainForm()
    {
        timer = new Timer();
        timer.Interval = 1800000; // 30 minutes in milliseconds
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        MessageBox.Show("This is your 30-minute notice!");
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new MainForm());
    }
}
