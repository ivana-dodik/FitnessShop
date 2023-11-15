using FitnessShop.ServiceLayer.Domain;
using FitnessShop.ServiceLayer.Services;
using FitnessShop.ServiceLayer.Util;
using System;
using System.Data;
using System.Windows;

namespace FitnessShop.View
{
    /// <summary>
    /// Interaction logic for KlijentPanel.xaml
    /// </summary>
    public partial class KlijentPanel : Window
    {

        private readonly HranaService hranaService;
        private readonly ObucaService obucaService;
        private readonly KorpaService korpaService;
        private DataTable hranaDataTable = new DataTable();
        private DataTable obucaDataTable = new DataTable();
        private Klijent trenutniKlijent;
        private Korpa korpa;

        public KlijentPanel(Klijent result)
        {
            InitializeComponent();
            this.trenutniKlijent = result;
            this.korpa = new Korpa();
            hranaService = new HranaServiceImpl();
            obucaService = new ObucaServiceImpl();
            korpaService = new KorpaServiceImpl();
            InitHrana();
            InitObuca();
            korpa.AddStavke(korpaService.GetAll(this.trenutniKlijent.KlijentId));
        }

        private void InitObuca()
        {
            var obuca = obucaService.GetAllKlijentObuca();

            // Add columns to the DataTable
            obucaDataTable.Columns.Add("Naziv", typeof(string));
            obucaDataTable.Columns.Add("Opis", typeof(string));
            obucaDataTable.Columns.Add("Cijena", typeof(double));
            obucaDataTable.Columns.Add("Pol", typeof(string));
            obucaDataTable.Columns.Add("Velicina", typeof(string));
            obucaDataTable.Columns.Add("Boja", typeof(string));
            obucaDataTable.Columns.Add("KolicinaNaStanju", typeof(int));
            obucaDataTable.Columns.Add("Id", typeof(int));
            obucaDataTable.Columns.Add("RobnaMarka", typeof(string));

            // Loop through the list and add each item as a row to the DataTable
            foreach (var o in obuca)
            {
                DataRow row = obucaDataTable.NewRow();
                row["Naziv"] = o.Naziv;
                row["Opis"] = o.Opis;
                row["Cijena"] = o.Cijena;
                row["KolicinaNaStanju"] = o.KolicinaNaStanju;
                row["RobnaMarka"] = o.RobnaMarka;
                row["Boja"] = o.Boja;
                row["Pol"] = o.Pol;
                row["Velicina"] = o.Velicina;
                row["Id"] = o.GetProizvodId();
                obucaDataTable.Rows.Add(row);
            }

            // Set the DataTable as the ItemsSource of a DataGrid, for example
            obucaDataGrid.ItemsSource = obucaDataTable.DefaultView;
        }

        private void InitHrana()
        {
            var hrana = hranaService.GetAllKlijentHrana();

            // Add columns to the DataTable
            hranaDataTable.Columns.Add("Naziv", typeof(string));
            hranaDataTable.Columns.Add("Opis", typeof(string));
            hranaDataTable.Columns.Add("Cijena", typeof(double));
            hranaDataTable.Columns.Add("KolicinaNaStanju", typeof(int));
            hranaDataTable.Columns.Add("Id", typeof(int));
            hranaDataTable.Columns.Add("HranljiveVrijednosti", typeof(string));
            hranaDataTable.Columns.Add("RobnaMarka", typeof(string));
            
            // Loop through the list and add each item as a row to the DataTable
            foreach (var h in hrana)
            {
                DataRow row = hranaDataTable.NewRow();
                row["HranljiveVrijednosti"] = h.HranljiveVrijednosti;
                row["Naziv"] = h.Naziv;
                row["Id"] = h.GetProizvodId();
                row["Opis"] = h.Opis;
                row["Cijena"] = h.Cijena;
                row["KolicinaNaStanju"] = h.KolicinaNaStanju;
                row["RobnaMarka"] = h.RobnaMarka;
                hranaDataTable.Rows.Add(row);
            }

            // Set the DataTable as the ItemsSource of a DataGrid, for example
            hranaDataGrid.ItemsSource = hranaDataTable.DefaultView;
        }

        private void btnKorpa_Click(object sender, RoutedEventArgs e)
        {
            KorpaPanel objKorpaPanel = new KorpaPanel(korpa, trenutniKlijent, hranaDataTable, obucaDataTable);
            objKorpaPanel.Owner = this;
            objKorpaPanel.ShowDialog();
        }

        private void btnProfil_Click(object sender, RoutedEventArgs e)
        {
            View.Profil objProfil = new View.Profil(trenutniKlijent);
            this.Close();
            objProfil.Show();
        }

        private void btnDodajUKorpu1_Click(object sender, RoutedEventArgs e)
        {
            if (hranaDataGrid.SelectedItem != null)
            {
                if (hranaDataGrid.SelectedItem is DataRowView row)
                {
                    int proizvodId = Convert.ToInt32(row["Id"]);
                    int kolicinaNaStanju = Convert.ToInt32(row["KolicinaNaStanju"]);

                    if (korpa.ContainsStavka(proizvodId))
                    {
                        if (korpa.GetKolicinaForProizvod(proizvodId) == kolicinaNaStanju)
                        {
                            MessageBox.Show("Nema na zalihama.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            korpa.IncreaseKolicina(proizvodId);
                            korpaService.IncrementKorpaStavkaKolicina(proizvodId, trenutniKlijent.KlijentId);
                        }
                    } else
                    {
                        string proizvodNaziv = Convert.ToString(row["Naziv"]);
                        int klijentId = trenutniKlijent.KlijentId;

                        korpa.AddStavka(new KorpaStavka(proizvodId, klijentId, 1, proizvodNaziv));
                        korpaService.AddKorpaStavka(proizvodId, klijentId);
                    }
                }
            }
        }

        private void btnDodajUKorpu2_Click(object sender, RoutedEventArgs e)
        {
            if (obucaDataGrid.SelectedItem != null)
            {
                if (obucaDataGrid.SelectedItem is DataRowView row)
                {
                    int proizvodId = Convert.ToInt32(row["Id"]);
                    int kolicinaNaStanju = Convert.ToInt32(row["KolicinaNaStanju"]);


                    if (korpa.ContainsStavka(proizvodId))
                    {
                        if (korpa.GetKolicinaForProizvod(proizvodId) == kolicinaNaStanju)
                        {
                            MessageBox.Show("Nema na zalihama.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            korpa.IncreaseKolicina(proizvodId);
                            korpaService.IncrementKorpaStavkaKolicina(proizvodId, trenutniKlijent.KlijentId);
                        }
                    }
                    else
                    {
                        string proizvodNaziv = Convert.ToString(row["Naziv"]);
                        int klijentId = trenutniKlijent.KlijentId;

                        korpa.AddStavka(new KorpaStavka(proizvodId, klijentId, 1, proizvodNaziv));
                        korpaService.AddKorpaStavka(proizvodId, klijentId);
                    }
                }
            }
        }

        private void btnOdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            View.Primary objPrimary = new View.Primary();
            this.Close();
            objPrimary.Show();
        }
    }
}
