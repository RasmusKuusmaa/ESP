using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    bool IsXPlaying = true;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btn_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;

        if (IsXPlaying)
        {
            clickedButton.Content = "x";
        } else
        {
            clickedButton.Content = "o";
        }
        IsXPlaying = !IsXPlaying;
    }
}