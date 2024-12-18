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
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace ProjektMesseDesktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DesktopDbContext _context = new DesktopDbContext();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("Button clicked");
        Console.WriteLine(_context.Database.GetConnectionString());
        _context.Database.EnsureCreated();
        _context.Kunden.Add( new Kunde { Name = "26", Id = 1, });
        _context.SaveChanges();
        
    }
}