using FitnessShop.ServiceLayer.Domain;
using FitnessShop.ServiceLayer.Services;
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

namespace FitnessShop.View
{
    /// <summary>
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {

        private Klijent trenutniKlijent;
        private NarudzbaService narudzbaService;

        public Profil(Klijent trenutniKlijent)
        {
            InitializeComponent();
            this.trenutniKlijent = trenutniKlijent;
            this.narudzbaService = new NarudzbaServiceImpl();
            vasProfilTextBox.Text = trenutniKlijent.ToString();
            stareNardzbeTextBox.Text = formatNarudzbe(narudzbaService.GetAllNarudzbe(trenutniKlijent.KlijentId));
        }

        private string formatNarudzbe(List<Narudzba> narudzbas)
        {
            var sb = new StringBuilder();

            foreach (var narudzba in narudzbas)
            {
                sb.Append(narudzba.ToString()).Append("\n\n");
            }

            return sb.ToString();
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            View.KlijentPanel objKlijentPanel = new View.KlijentPanel(trenutniKlijent);
            this.Close();
            objKlijentPanel.Show();
        }

    }
}
