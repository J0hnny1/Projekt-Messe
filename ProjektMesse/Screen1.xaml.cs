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

namespace ProjektMesse;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Screen1 : Window
{
    ContextLokaleDB context = new ContextLokaleDB();

    // Willkommens Bildschirm
    public Screen1()
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //var tableExists =
        //    context.Database.ExecuteSqlRaw(
        //        "SELECT name FROM sqlite_master WHERE type='table' AND name='Produktgruppe';");
        //context.Add(Produktgruppe);
        //Console.WriteLine(tableExists);
        //if (tableExists == 0)
        //{
        //    Console.WriteLine("Table 'Produktgruppe' does not exist.");
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 1, Name = "Medien und Unterhaltung" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 2, Name = "Bekleidung und Mode" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 3, Name = "Haushalt" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 4, Name = "Möbel und Einrichtung" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 5, Name = "Lebensmittelwaren" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 6, Name = "Hygiene und Kosmetik" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 7, Name = "Sport- und Freizeitartikel" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 8, Name = "Büro und Schreibwaren" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 9, Name = "Bau- und Heimwerk" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 10, Name = "Autozubehör" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 11, Name = "Wellnessprodukte" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 12, Name = "Bücher, Musik und Filme" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 13, Name = "Schmuck und Uhren" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 14, Name = "Baby- und Kinderprodukte" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 15, Name = "Reisebedarf" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 16, Name = "Haustierbedarf" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 17, Name = "Softwareprodukte" });
        //    context.Produktgruppe.Add(new Produktgruppe
        //        { ProduktgruppenID = 18, Name = "Dienstleistungen für Schönheitsbehandlungen" });
        //    context.Produktgruppe.Add(
        //        new Produktgruppe { ProduktgruppenID = 19, Name = "Industrie- und Gewerbebedarf" });
        //    context.Produktgruppe.Add(new Produktgruppe
        //        { ProduktgruppenID = 20, Name = "Veranstaltungs- und Partybedarf" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 21, Name = "Energie und Umwelt" });
        //    context.Produktgruppe.Add(new Produktgruppe
        //        { ProduktgruppenID = 22, Name = "Bildung und Lernmaterialien" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 23, Name = "Kunst und Bastelbedarf" });
        //    context.Produktgruppe.Add(new Produktgruppe
        //        { ProduktgruppenID = 24, Name = "Sicherheits- und Überwachungsausrüstung" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 25, Name = "Musik- und Tontechnik" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 26, Name = "Spielzeuge" });
        //    context.Produktgruppe.Add(
        //        new Produktgruppe { ProduktgruppenID = 27, Name = "Souvenir und Geschenkartikel" });
        //    context.Produktgruppe.Add(new Produktgruppe
        //        { ProduktgruppenID = 28, Name = "Fotografie- und Videografie" });
        //    context.Produktgruppe.Add(new Produktgruppe
        //        { ProduktgruppenID = 29, Name = "Garten- und Landschaftsbedarf" });
        //    context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 30, Name = "Transport und Logistik" });
        //    context.SaveChanges();
        //}
        //else
        //{
        //    Console.WriteLine("Table 'Produktgruppe' exists.");
        //}

        Utils.changeWindowTo<Screen2>(this);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Utils.changeWindowTo<Screen4>(this);
    }
}