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
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private readonly RobneMarkeService robneMarkeService;
        private readonly HranaService hranaService;
        private readonly ObucaService obucaService;
        private DataTable robneMarkeDataTable = new DataTable();
        private DataTable hranaDataTable = new DataTable();
        private DataTable obucaDataTable = new DataTable();

        public AdminPanel()
        {
            robneMarkeService = new RobneMarkeServiceImpl();
            hranaService = new HranaServiceImpl();
            obucaService = new ObucaServiceImpl();
            InitializeComponent();
            InitRobneMarke();
            InitHrana();
            InitObuca();
        }

        private void InitRobneMarke()
        {
            var robneMarke = robneMarkeService.GetAllRobnaMarka();

            // Add columns to the DataTable
            robneMarkeDataTable.Columns.Add("Id", typeof(int));
            robneMarkeDataTable.Columns.Add("Naziv", typeof(string));
            robneMarkeDataTable.Columns.Add("Opis", typeof(string));
            robneMarkeDataTable.Columns.Add("BrojProizvoda", typeof(int));

            // Loop through the list and add each item as a row to the DataTable
            foreach (RobnaMarka robnaMarka in robneMarke)
            {
                DataRow row = robneMarkeDataTable.NewRow();
                row["Id"] = robnaMarka.Id;
                row["Naziv"] = robnaMarka.Naziv;
                row["Opis"] = robnaMarka.Opis;
                row["BrojProizvoda"] = robnaMarka.BrojProizvoda;
                robneMarkeDataTable.Rows.Add(row);
            }

            // Set the DataTable as the ItemsSource of a DataGrid, for example
            robneMarkeDataGrid.ItemsSource = robneMarkeDataTable.DefaultView;
        }

        public void ReloadRobneMarke()
        {
            var robneMarke = robneMarkeService.GetAllRobnaMarka();
            robneMarkeDataTable.Clear();

            foreach (RobnaMarka robnaMarka in robneMarke)
            {
                DataRow row = robneMarkeDataTable.NewRow();
                row["Id"] = robnaMarka.Id;
                row["Naziv"] = robnaMarka.Naziv;
                row["Opis"] = robnaMarka.Opis;
                row["BrojProizvoda"] = robnaMarka.BrojProizvoda;
                robneMarkeDataTable.Rows.Add(row);
            }
        }

        private void ReloadHrana()
        {
            var hrana = hranaService.GetAllHrana();
            hranaDataTable.Clear();

            foreach (var h in hrana)
            {
                DataRow row = hranaDataTable.NewRow();
                row["Id"] = h.Id;
                row["Naziv"] = h.Naziv;
                row["Opis"] = h.Opis;
                row["Cijena"] = h.Cijena;
                row["KolicinaNaStanju"] = h.KolicinaNaStanju;
                row["RobnaMarka"] = h.RobnaMarka;
                hranaDataTable.Rows.Add(row);
            }
        }

        private void InitHrana()
        {
            var hrana = hranaService.GetAllHrana();

            // Add columns to the DataTable
            hranaDataTable.Columns.Add("Id", typeof(int));
            hranaDataTable.Columns.Add("Naziv", typeof(string));
            hranaDataTable.Columns.Add("Opis", typeof(string));
            hranaDataTable.Columns.Add("Cijena", typeof(double));
            hranaDataTable.Columns.Add("KolicinaNaStanju", typeof(int));
            hranaDataTable.Columns.Add("RobnaMarka", typeof(string));

            // Loop through the list and add each item as a row to the DataTable
            foreach (var h in hrana)
            {
                DataRow row = hranaDataTable.NewRow();
                row["Id"] = h.Id;
                row["Naziv"] = h.Naziv;
                row["Opis"] = h.Opis;
                row["Cijena"] = h.Cijena;
                row["KolicinaNaStanju"] = h.KolicinaNaStanju;
                row["RobnaMarka"] = h.RobnaMarka;
                hranaDataTable.Rows.Add(row);
            }

            // Set the DataTable as the ItemsSource of a DataGrid, for example
            hranaDataGrid.ItemsSource = hranaDataTable.DefaultView;
        }

        private void ReloadObuca()
        {
            var obuca = obucaService.GetAllObuca();
            obucaDataTable.Clear();

            foreach (var o in obuca)
            {
                DataRow row = obucaDataTable.NewRow();
                row["Id"] = o.Id;
                row["Naziv"] = o.Naziv;
                row["Opis"] = o.Opis;
                row["Cijena"] = o.Cijena;
                row["KolicinaNaStanju"] = o.KolicinaNaStanju;
                row["RobnaMarka"] = o.RobnaMarka;
                row["Boja"] = o.Boja;
                row["Pol"] = o.Pol;
                row["Velicina"] = o.Velicina;
                obucaDataTable.Rows.Add(row);
            }
        }

        private void InitObuca()
        {
            var obuca = obucaService.GetAllObuca();

            // Add columns to the DataTable
            obucaDataTable.Columns.Add("Id", typeof(int));
            obucaDataTable.Columns.Add("Naziv", typeof(string));
            obucaDataTable.Columns.Add("Opis", typeof(string));
            obucaDataTable.Columns.Add("Cijena", typeof(double));
            obucaDataTable.Columns.Add("Pol", typeof(string));
            obucaDataTable.Columns.Add("Velicina", typeof(string));
            obucaDataTable.Columns.Add("Boja", typeof(string));
            obucaDataTable.Columns.Add("KolicinaNaStanju", typeof(int));
            obucaDataTable.Columns.Add("RobnaMarka", typeof(string));

            // Loop through the list and add each item as a row to the DataTable
            foreach (var o in obuca)
            {
                DataRow row = obucaDataTable.NewRow();
                row["Id"] = o.Id;
                row["Naziv"] = o.Naziv;
                row["Opis"] = o.Opis;
                row["Cijena"] = o.Cijena;
                row["KolicinaNaStanju"] = o.KolicinaNaStanju;
                row["RobnaMarka"] = o.RobnaMarka;
                row["Boja"] = o.Boja;
                row["Pol"] = o.Pol;
                row["Velicina"] = o.Velicina;
                obucaDataTable.Rows.Add(row);
            }

            // Set the DataTable as the ItemsSource of a DataGrid, for example
            obucaDataGrid.ItemsSource = obucaDataTable.DefaultView;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var windowToShow = new RobnaMarkaAdd(robneMarkeDataGrid, robneMarkeDataTable);
            windowToShow.Owner = this; // set the owner window to the current window
            windowToShow.ShowDialog(); // show the window as a modal dialog
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            if (robneMarkeDataGrid.SelectedItem != null)
            {
                if (robneMarkeDataGrid.SelectedItem is DataRowView row)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string naziv = Convert.ToString(row["naziv"]);
                    string opis = Convert.ToString(row["opis"]);

                    var windowToShow = new RobnaMarkaEdit(robneMarkeDataGrid, robneMarkeDataTable, id, naziv, opis);
                    windowToShow.Owner = this; // set the owner window to the current window
                    bool? completed = windowToShow.ShowDialog(); // show the window as a modal dialog

                    if (completed != null && completed.HasValue)
                    {
                        ReloadHrana();
                        ReloadObuca();
                    }
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (robneMarkeDataGrid.SelectedItem != null)
            {
                if (robneMarkeDataGrid.SelectedItem is DataRowView row)
                {
                    int id = Convert.ToInt32(row["id"]);

                    int brojProizvoda = Convert.ToInt32(row["BrojProizvoda"]);

                    if (brojProizvoda > 0)
                    {
                        MessageBox.Show("Nije moguće obrisati robnu marku koja ima proizovde! Prvo obrišite proizvode.", "Greška", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Delete the row from the database
                    robneMarkeService.DeleteRobnaMarka(id);

                    // Remove the row from the DataTable
                    DataRow dataRow = row.Row;
                    robneMarkeDataTable.Rows.Remove(dataRow);
                }

            }
        }

        private void btnOdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            View.Primary objPrimary = new View.Primary();
            this.Close();
            objPrimary.Show();
        }

        private void btnOdjaviSe2_Click(object sender, RoutedEventArgs e)
        {
            View.Primary objPrimary = new View.Primary();
            this.Close();
            objPrimary.Show();
        }

        private void btnObrisi2_Click(object sender, RoutedEventArgs e)
        {
            if (hranaDataGrid.SelectedItem != null)
            {
                if (hranaDataGrid.SelectedItem is DataRowView row)
                {
                    int id = Convert.ToInt32(row["id"]);

                    // Delete the row from the database
                    hranaService.DeleteHrana(id);

                    // Remove the row from the DataTable
                    DataRow dataRow = row.Row;
                    hranaDataTable.Rows.Remove(dataRow);
                    ReloadRobneMarke();
                }

            }
        }

        private void btnIzmjeni2_Click(object sender, RoutedEventArgs e)
        {
            if (hranaDataGrid.SelectedItem != null)
            {
                if (hranaDataGrid.SelectedItem is DataRowView row)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string naziv = Convert.ToString(row["Naziv"]);
                    string opis = Convert.ToString(row["Opis"]);
                    string robnaMarka = Convert.ToString(row["RobnaMarka"]);
                    double cijena = Convert.ToDouble(row["Cijena"]);
                    int kolicina = Convert.ToInt32(row["KolicinaNaStanju"]);

                    var hrana = new Hrana(id, naziv, opis, cijena, kolicina, robnaMarka);
                    var robneMarke = robneMarkeService.GetAllRobnaMarka();
                    var windowToShow = new HranaEdit(hranaDataGrid, hranaDataTable, hrana, robneMarke, this);
                    windowToShow.Owner = this; // set the owner window to the current window
                    windowToShow.ShowDialog(); // show the window as a modal dialog
                }
            }
        }

        private void btnDodaj2_Click(object sender, RoutedEventArgs e)
        {
            var robneMarke = robneMarkeService.GetAllRobnaMarka();
            var windowToShow = new HranaAdd(robneMarke, hranaDataGrid, hranaDataTable);
            
            windowToShow.Owner = this; // set the owner window to the current window
            bool? added = windowToShow.ShowDialog(); // show the window as a modal dialog

            if (added.HasValue)
            {
                ReloadRobneMarke();
            }
        }

        private void btnDodaj3_Click(object sender, RoutedEventArgs e)
        {
            var robneMarke = robneMarkeService.GetAllRobnaMarka();
            var polovi = Polovi.GetPolAttrs();
            var velicineObuce = Velicine.GetVelicinaAttrs();
            var windowToShow = new ObucaAdd(robneMarke, polovi,velicineObuce, obucaDataGrid, obucaDataTable);
            windowToShow.Owner = this; // set the owner window to the current window
            bool? added = windowToShow.ShowDialog(); // show the window as a modal dialog

            if (added.HasValue)
            {
                ReloadRobneMarke();
            }
        }

        private void btnIzmjeni3_Click(object sender, RoutedEventArgs e)
        {
            if (obucaDataGrid.SelectedItem != null)
            {
                if (obucaDataGrid.SelectedItem is DataRowView row)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string naziv = Convert.ToString(row["Naziv"]);
                    string opis = Convert.ToString(row["Opis"]);
                    string robnaMarka = Convert.ToString(row["RobnaMarka"]);
                    string boja = Convert.ToString(row["Boja"]);
                    string pol = Convert.ToString(row["Pol"]);
                    string velicina = Convert.ToString(row["Velicina"]);
                    double cijena = Convert.ToDouble(row["Cijena"]);
                    int kolicina = Convert.ToInt32(row["KolicinaNaStanju"]);

                    var obuca = new Obuca(id, naziv, opis, cijena, kolicina, boja, pol, robnaMarka, velicina);
                    var robneMarke = robneMarkeService.GetAllRobnaMarka();
                    var polovi = Polovi.GetPolAttrs();
                    var windowToShow = new ObucaEdit(obucaDataGrid, obucaDataTable, obuca, robneMarke, polovi, this);
                    windowToShow.Owner = this; // set the owner window to the current window
                    windowToShow.ShowDialog(); // show the window as a modal dialog
                }
            }
        }

        private void btnObrisi3_Click(object sender, RoutedEventArgs e)
        {
            if (obucaDataGrid.SelectedItem != null)
            {
                if (obucaDataGrid.SelectedItem is DataRowView row)
                {
                    int id = Convert.ToInt32(row["id"]);

                    // Delete the row from the database
                    obucaService.DeleteObuca(id);

                    // Remove the row from the DataTable
                    DataRow dataRow = row.Row;
                    obucaDataTable.Rows.Remove(dataRow);
                    ReloadRobneMarke();
                }

            }
        }

        private void btnOdjaviSe3_Click(object sender, RoutedEventArgs e)
        {
            View.Primary objPrimary = new View.Primary();
            this.Close();
            objPrimary.Show();
        }
    }
}
