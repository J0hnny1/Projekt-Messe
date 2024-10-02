using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektMesse
{
    public class Utils
    {
        public static void changeWindowTo<T>(Window activeWindow) where T : Window, new()
        {
            T w = new T();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            activeWindow.Close();
            w.Show();
        }
    }
}
