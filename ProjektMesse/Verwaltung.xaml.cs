using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    /// Interaktionslogik für Screen5.xaml
    /// </summary>
    public partial class Verwaltung : Window
    {
        // Datenverwaltung
        public Verwaltung()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Utils.changeWindowTo<Welcomescreen>(this);
        }

        private async void BtnUpload(object sender, RoutedEventArgs e)
        {
            
            // Load local data
            var localFirmen = Utils.context.Firma.ToList();
            var localKunden = Utils.context.Kunden.ToList();
            var localProduktgruppenmatches = Utils.context.MatchKundeProduktgruppe.ToList();

            // Upload local data
            bool uploadSuccess = await UploadData(localFirmen, localKunden, localProduktgruppenmatches);

            if (uploadSuccess)
            {
                // Delete local data after successful upload
                Utils.context.Firma.RemoveRange(localFirmen);
                Utils.context.Kunden.RemoveRange(localKunden);
                Utils.context.MatchKundeProduktgruppe.RemoveRange(localProduktgruppenmatches);
                Utils.context.SaveChanges();
                tbLogbox.Text = "Upload and deletion successful.";
            }
            else
            {
                //tbLogbox.Text = "Upload failed.";
            }
        }
        
        
        private async Task<bool> UploadData(List<Firma> firmen, List<Kunde> kunden, List<MatchKundeProduktgruppe> matches)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // TODO Null fehler fixen
                    // TODO IDs entfernen
                    
                    // Upload Firmen
                    //var firmenResponse = await httpClient.PostAsJsonAsync("http://localhost:5251/firma", firmen);
                    //if (!firmenResponse.IsSuccessStatusCode) return false;

                    // Upload Kunden
                    var kundenResponse = await httpClient.PostAsJsonAsync("http://localhost:5251/customer", kunden);
                    if (!kundenResponse.IsSuccessStatusCode) return false;

                    //Upload Produktgruppenmatches
                    var matchesResponse = await httpClient.PostAsJsonAsync("http://localhost:5251/zuordnung", matches);
                    if (!matchesResponse.IsSuccessStatusCode) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                tbLogbox.Text = $"Error: {ex.Message}";
                return false;
            }
        }
    }
}