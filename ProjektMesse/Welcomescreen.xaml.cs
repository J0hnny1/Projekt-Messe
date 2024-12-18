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
public partial class Welcomescreen : Window
{
    // Willkommens Bildschirm
    public Welcomescreen()
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
        Utils.context.Database.EnsureCreated();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        /*

        */
        //initProdugtgruppen();
        Utils.changeWindowTo<Dateneingabe>(this);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Utils.changeWindowTo<Login>(this);
    }

    private void initProdugtgruppen()
    {
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Medien und Unterhaltung" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Bekleidung und Mode" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Haushalt" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Möbel und Einrichtung" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Lebensmittelwaren" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Hygiene und Kosmetik" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Sport- und Freizeitartikel" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Büro und Schreibwaren" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Bau- und Heimwerk" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Autozubehör" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Wellnessprodukte" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Bücher, Musik und Filme" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Schmuck und Uhren" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Baby- und Kinderprodukte" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Reisebedarf" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Haustierbedarf" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { Name = "Softwareprodukte" });
        Utils.context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 18, Name = "Dienstleistungen für Schönheitsbehandlungen" });
        Utils.context.Produktgruppe.Add(
            new Produktgruppe { ProduktgruppenID = 19, Name = "Industrie- und Gewerbebedarf" });
        Utils.context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 20, Name = "Veranstaltungs- und Partybedarf" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 21, Name = "Energie und Umwelt" });
        Utils.context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 22, Name = "Bildung und Lernmaterialien" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 23, Name = "Kunst und Bastelbedarf" });
        Utils.context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 24, Name = "Sicherheits- und Überwachungsausrüstung" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 25, Name = "Musik- und Tontechnik" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 26, Name = "Spielzeuge" });
        Utils.context.Produktgruppe.Add(
            new Produktgruppe { ProduktgruppenID = 27, Name = "Souvenir und Geschenkartikel" });
        Utils.context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 28, Name = "Fotografie- und Videografie" });
        Utils.context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 29, Name = "Garten- und Landschaftsbedarf" });
        Utils.context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 30, Name = "Transport und Logistik" });
        Utils.context.SaveChanges();
    }
}