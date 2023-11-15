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

namespace FitnessShop
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        AdminService adminService;

        public AdminLogin()
        {
            adminService = new AdminServiceImpl();
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUser.Text;
            var password = txtPass.Password;

            bool result = adminService.Login(username, password);
            //Console.WriteLine(result);
            if (result)
            {
                View.AdminPanel objAdminPanel = new View.AdminPanel();
                this.Close();
                objAdminPanel.Show();
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
