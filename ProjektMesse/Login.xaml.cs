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
    /// Interaktionslogik für Screen4.xaml
    /// </summary>
    public partial class Login : Window
    {
        private string usernameLogin;
        private string passwordLogin;
        // Mitarbeiter Login
        public Login()
        {
            InitializeComponent();

            usernameLogin = "admin";
            passwordLogin = "admin";

            lbErrormsg.Content = "";
        }

        private bool passwordIsCorrect()
        {
            return usernameLogin == tbUsername.Text && passwordLogin == pbPassword.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!passwordIsCorrect())
            {
                lbErrormsg.Content = "Username or Password is incorrect";
                tbUsername.Text = "";
                pbPassword.Password = "";
                return;
            }
            Utils.changeWindowTo<Verwaltung>(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Utils.changeWindowTo<Welcomescreen>(this);
        }
    }
}
