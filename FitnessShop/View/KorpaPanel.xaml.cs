using FitnessShop.ServiceLayer.Domain;
using FitnessShop.ServiceLayer.Services;
using FitnessShop.ServiceLayer.Util;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Korpa.xaml
    /// </summary>
    public partial class KorpaPanel : Window
    {
        private Klijent klijent;
        private Korpa korpa;
        private KorpaService korpaService;

        private DataTable obucaDataTable;
        private DataTable hranaDatatable;

        public KorpaPanel(Korpa korpa, Klijent klijent, DataTable hranaDatatable, DataTable obucaDataTable)
        {
            InitializeComponent();
            this.korpa = korpa;
            this.klijent = klijent;
            korpaTextBox.Text = this.korpa.ToString();
            this.korpaService = new KorpaServiceImpl();
            this.hranaDatatable = hranaDatatable;
            this.obucaDataTable = obucaDataTable;
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            korpaTextBox.Text = string.Empty;
            korpa.Clear();
            korpaService.Clear(klijent.KlijentId);
        }

        private void btnNaruci_Click(object sender, RoutedEventArgs e)
        {
            korpaService.Order(korpa);

            // obuca
            foreach (var stavka in korpa.getStavke())
            {
                // Assume that dt is the DataTable that is bound to the DataGrid
                DataRow[] rows = obucaDataTable.Select($"id = {stavka.ProizvodId}"); // id is the ID of the edited row
                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    // Assume that naziv and opis are the columns that were edited in the database
                    row["KolicinaNaStanju"] = Convert.ToInt32(row["KolicinaNaStanju"]) - stavka.Kolicina;
                    int kolicna = Convert.ToInt32(row["KolicinaNaStanju"]);
                    if (kolicna == 0)
                    {
                        obucaDataTable.Rows.Remove(row);
                    }
                }
            }

            // hrana
            foreach (var stavka in korpa.getStavke())
            {
                // Assume that dt is the DataTable that is bound to the DataGrid
                DataRow[] rows = hranaDatatable.Select($"id = {stavka.ProizvodId}"); // id is the ID of the edited row
                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    // Assume that naziv and opis are the columns that were edited in the database
                    row["KolicinaNaStanju"] = Convert.ToInt32(row["KolicinaNaStanju"]) - stavka.Kolicina;
                    int kolicna = Convert.ToInt32(row["KolicinaNaStanju"]);
                    if (kolicna == 0)
                    {
                        hranaDatatable.Rows.Remove(row);
                    }
                }
            }

            korpa.Clear();
            korpaTextBox.Text = string.Empty;
            MessageBox.Show("Uspješno naručeno!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
