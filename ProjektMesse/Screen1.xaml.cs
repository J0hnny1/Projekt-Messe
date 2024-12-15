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
using ProjektMesse.Models;

namespace ProjektMesse;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Screen1 : Window
{
    DatabseContext context = new DatabseContext();

    // Willkommens Bildschirm
    public Screen1()
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var tableExists =
            context.Database.ExecuteSqlRaw(
                "SELECT name FROM sqlite_master WHERE type='table' AND name='Produktgruppe';");
        //context.Add(Produktgruppe);
        Console.WriteLine(tableExists);

        Console.WriteLine("Table 'Produktgruppe' does not exist.");
        context.Produktgruppe.Add(new Produktgruppe { Name = "Medien und Unterhaltung" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Bekleidung und Mode" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Haushalt" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Möbel und Einrichtung" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Lebensmittelwaren" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Hygiene und Kosmetik" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Sport- und Freizeitartikel" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Büro und Schreibwaren" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Bau- und Heimwerk" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Autozubehör" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Wellnessprodukte" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Bücher, Musik und Filme" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Schmuck und Uhren" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Baby- und Kinderprodukte" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Reisebedarf" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Haustierbedarf" });
        context.Produktgruppe.Add(new Produktgruppe { Name = "Softwareprodukte" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenId = 18, Name = "Dienstleistungen für Schönheitsbehandlungen" });
        context.Produktgruppe.Add(
            new Produktgruppe { ProduktgruppenId = 19, Name = "Industrie- und Gewerbebedarf" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenId = 20, Name = "Veranstaltungs- und Partybedarf" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenId = 21, Name = "Energie und Umwelt" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenId = 22, Name = "Bildung und Lernmaterialien" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenId = 23, Name = "Kunst und Bastelbedarf" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenId = 24, Name = "Sicherheits- und Überwachungsausrüstung" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenId = 25, Name = "Musik- und Tontechnik" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenId = 26, Name = "Spielzeuge" });
        context.Produktgruppe.Add(
            new Produktgruppe { ProduktgruppenId = 27, Name = "Souvenir und Geschenkartikel" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenId = 28, Name = "Fotografie- und Videografie" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenId = 29, Name = "Garten- und Landschaftsbedarf" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenId = 30, Name = "Transport und Logistik" });
        context.SaveChanges();
    
    
    Utils.changeWindowTo<Screen2>(this);
}

private void Button_Click_1(object sender, RoutedEventArgs e)
{
    Utils.changeWindowTo<Screen4>(this);
}

}