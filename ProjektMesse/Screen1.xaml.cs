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

namespace ProjektMesse;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Screen1 : Window
{
    // Willkommens Bildschirm
    public Screen1()
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Utils.changeWindowTo<Screen2>(this);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Utils.changeWindowTo<Screen4>(this);
    }
}