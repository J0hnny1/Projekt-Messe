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

namespace ProjektMesse
{
    /// <summary>
    /// Interaktionslogik für Screen3.xaml
    /// </summary>
    public partial class Screen3 : Window
    {
        // Produktgruppen Bildschirm
        public Screen3()
        {
            InitializeComponent();

            ContextLokaleDB dbL = new ContextLokaleDB();
            dbL.

            // Produktgruppen Liste
            for (int i = 0; i< 10; i++)
            {
                ListBoxItem li = new ListBoxItem();
                li.Content = "Halo";
                LBProduktgruppen.Items.Add(li);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Utils.changeWindowTo<Screen1>(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Utils.changeWindowTo<Screen2>(this);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
