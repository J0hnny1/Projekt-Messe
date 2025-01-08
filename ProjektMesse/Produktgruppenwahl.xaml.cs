using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebApplication1.Models;

namespace ProjektMesse
{
    /// <summary>
    /// Interaktionslogik für Screen3.xaml
    /// </summary>
    public partial class Produktgruppenwahl : Window
    {
        // Produktgruppen Bildschirm
        public Produktgruppenwahl()
        {
            InitializeComponent();

            //Produktgruppe pr = new Produktgruppe();
            var node = Utils.context.Produktgruppe.GetAsyncEnumerator();
            // Produktgruppen Liste

            while (node.MoveNextAsync().Result)
            {
                ListBoxItem li = new ListBoxItem();
                li.Content = node.Current.Name;
                LBProduktgruppen.Items.Add(li);
            }
        }

        private void BtnFertig(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("BUTTON FERTIG");
            Utils.context.Kunden.Add(Utils.aktuellerKunde);
            // TODO in eine Schleife verschieben
            foreach (ListBoxItem item in LBProduktgruppen.SelectedItems)
            {
                Console.WriteLine("IN FOR EACH 1");
                string produktgruppeName = item.Content.ToString();
                Utils.produktgruppenNamen.Add(produktgruppeName);
            }

            foreach (string item in Utils.produktgruppenNamen)
            {
                Console.WriteLine("PLSSS");
                Console.WriteLine(item);
                Utils.context.Database.EnsureCreated();
                Produktgruppe produktgruppe = Utils.context.Produktgruppe.FirstOrDefault(pg => pg.Name == item);
                if (produktgruppe != null)
                {
                    MatchKundeProduktgruppe match = new MatchKundeProduktgruppe
                    {
                        // TODO kundeId ist 0
                        KundeId = Utils.aktuellerKunde.Id,
                        ProduktgruppeId = produktgruppe.ProduktgruppenID
                    };

                    Utils.context.MatchKundeProduktgruppe.Add(match);
                }
            }

            Utils.context.SaveChanges();
            Utils.changeWindowTo<Welcomescreen>(this);

            MessageBox.Show("Glückwunsch!!\nDer Gutscheincode lautet:\nog34-fje9-02lm-82md");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Utils.changeWindowTo<Dateneingabe>(this);
        }

        private void Button_Click_Abbrechen(object sender, RoutedEventArgs e)
        {
            Utils.aktuellerKunde = null;
            Utils.produktgruppenNamen = null;
            Utils.changeWindowTo<Welcomescreen>(this);
        }
    }
}