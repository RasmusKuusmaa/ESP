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
    private string[,] board = new string[3, 3];
    private string cur = "o";
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btn_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = sender as Button;
        int row = Grid.GetRow(clickedButton);
        int col = Grid.GetColumn(clickedButton);
  
        if (cur == "x")
        {
            cur = "o";
        }
        else
        {
            cur = "x";
        }

        clickedButton.IsEnabled = false;
        clickedButton.Content = cur;
        board[row, col] = cur;
        if (CheckDraw())
        {
            MessageBox.Show("draw");
            ResetBoard();
        }
        if (CheckWinner())
        {
            MessageBox.Show($"{cur} won");
            ResetBoard();
        }
    }
    private bool CheckWinner()
    {
        
        for (int i = 0; i < 3; i++)
        {
          
            if (!string.IsNullOrEmpty(board[0, i]) && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                return true;

            if (!string.IsNullOrEmpty(board[i, 0]) && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return true;
        }
        if (!string.IsNullOrEmpty(board[0, 0]) && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return true;
        

        if (!string.IsNullOrEmpty(board[0, 2]) && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return true;
        

        return false;    
    }
    private void ResetBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = null;
            }
        }
        foreach (Button button in grid.Children) 
        {
            button.Content = "";
            button.IsEnabled = true;
        }
    }
    private bool CheckDraw()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == null)
                {
                    return false;
                }
            }
        }
        return true;
    }
}