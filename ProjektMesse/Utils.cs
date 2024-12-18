using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebApplication1.Models;

namespace ProjektMesse
{
    public class Utils
    {
        public static Kunde aktuellerKunde;
        public static ContextLokaleDB context = new ContextLokaleDB();
        public static List<String> produktgruppenNamen = new List<string>();

        public Utils()
        {
            context.Database.EnsureCreated();

        }

        public static void changeWindowTo<T>(Window activeWindow) where T : Window, new()
        {
            T w = new T();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            activeWindow.Close();
            w.Show();
        }
    }
}
