using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
using AForge.Video;
using AForge.Video.DirectShow;
using WebApplication1.Models;
using System.IO;
using Path = System.IO.Path;

//using Firma = ProjektMesse.Models.Firma;

namespace ProjektMesse
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Dateneingabe : Window
    {
        private FilterInfoCollection videoDevices;

        private VideoCaptureDevice videoSource;

        // Neukunde Datenerfassung
        public Dateneingabe()
        {
            InitializeComponent();
            InitializeWebcam();
        }

        private void BtnAbbruch(object sender, RoutedEventArgs e)
        {
            Utils.changeWindowTo<Welcomescreen>(this);
        }

        private void BtnWeiter(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" || tbVorname.Text == "" || tbStraße.Text == "" || tbPLZ.Text == "" ||
                tbStadt.Text == "" || tbPLZ.Text == "")
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus.");
                return;
            }

            // TODO Fix Firma Attribute not nullable

            Firma firma = Utils.context.Firma.FirstOrDefault(t => t.Name == tbFirma.Text);

            if (firma == null)
            {
                Firma neueFirma = new Firma { Name = tbFirma.Text, Stadt = "", PLZ = "", Straße = ""};
                Utils.context.Firma.Add(neueFirma);
                Utils.context.SaveChanges();
                firma = neueFirma;
            }


            Utils.aktuellerKunde = new Kunde
            {
                Name = tbName.Text,
                Vorname = tbVorname.Text,
                Straße = tbStraße.Text,
                PLZ = tbPLZ.Text,
                Stadt = tbStadt.Text,
                Firma = firma,
                Firmenberater = tbFirma.Text != ""
            };
            Utils.changeWindowTo<Produktgruppenwahl>(this);
        }

        private void InitializeWebcam()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("No webcam found.");
            }
        }

        private void BtnBildaufnehmen(object sender, RoutedEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                "capturedImage.jpg");
            bitmap.Save(filePath, ImageFormat.Jpeg);
            Console.WriteLine("Image saved to: " + filePath);
            // Convert Bitmap to BitmapImage
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }

            // Set the Source property of imgKunde
            imgKunde.Source = bitmapImage;
            bitmap.Dispose();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            base.OnClosed(e);
        }
    }
}