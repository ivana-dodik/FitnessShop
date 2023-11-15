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

using FitnessShop.ServiceLayer.Services;

namespace FitnessShop.View
{
    /// <summary>
    /// Interaction logic for KlijentLogin.xaml
    /// </summary>
    public partial class KlijentLogin : Window
    {

        private KlijentService klijentService;
        public KlijentLogin()
        {
            klijentService = new KlijentServiceImpl();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUser.Text;
            var password = txtPass.Password;

            var result = klijentService.Login(username, password);
            if (result != null)
            {
                View.KlijentPanel objKlijentPanel = new View.KlijentPanel(result);
                this.Close();
                objKlijentPanel.Show();
            }
            else
            {
                //vrongCredentialsLabel.Visibility = Visibility.Visible;
                // MessageBox.Show("Pogrešni kredencijali!");
                MessageBox.Show("Pogrešni kredencijali!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            View.Primary objPrimary = new View.Primary();
            this.Close();
            objPrimary.Show();
        }
    }
}
