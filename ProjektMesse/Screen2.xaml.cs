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
using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.Win32;

namespace ProjektMesse
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Screen2 : Window
    {
        // Neukunde Datenerfassung
        public Screen2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Utils.changeWindowTo<Screen1>(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Utils.changeWindowTo<Screen3>(this);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage picture = new BitmapImage();
                picture.BeginInit();
                picture.UriSource = new Uri(openFileDialog.FileName);
                picture.EndInit();
                imgKunde.Source = picture;
            }
                

        }

    }
}
