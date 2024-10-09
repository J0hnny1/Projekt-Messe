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
    /// Interaktionslogik für Screen5.xaml
    /// </summary>
    public partial class Screen5 : Window
    {
        // Datenverwaltung
        public Screen5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Utils.changeWindowTo<Screen1>(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
