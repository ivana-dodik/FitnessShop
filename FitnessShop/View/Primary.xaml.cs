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

using MySql.Data;
using MySql.Data.MySqlClient;



namespace FitnessShop.View
{
    /// <summary>
    /// Interaction logic for Primary.xaml
    /// </summary>
    public partial class Primary : Window
    {
       
        public Primary()
        {
            InitializeComponent();
        }
    

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin objAdminLogin = new AdminLogin();
            this.Close();
            objAdminLogin.Show();
        }

        private void btnKlijent_Click(object sender, RoutedEventArgs e)
        {
            KlijentLogin objKlijentLogin = new KlijentLogin();
            this.Close();
            objKlijentLogin.Show();
        }
    }
}
