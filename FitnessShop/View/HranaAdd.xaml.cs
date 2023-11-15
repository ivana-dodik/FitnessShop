using FitnessShop.ServiceLayer.Domain;
using FitnessShop.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FitnessShop.View
{
    /// <summary>
    /// Interaction logic for HranaAdd.xaml
    /// </summary>
    public partial class HranaAdd : Window
    {

        private DataGrid dataGrid;
        private DataTable dataTable;
        private HranaService hranaService = new HranaServiceImpl();

        public HranaAdd(List<RobnaMarka> robneMarke, DataGrid dataGrid, DataTable dataTable)
        {
            InitializeComponent();
            hranaRobnaMarkaComboBox.ItemsSource = robneMarke;
            this.dataGrid = dataGrid;
            this.dataTable = dataTable;
        }


        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var newRow = dataTable.NewRow();
            var naziv = hranaNazivTxtBox.Text;
            var opis = hranaOpisTxtBox.Text;
            var kolicina = Convert.ToInt32(hranaKolicinaTxtBox.Text);
            var cijena = Convert.ToDouble(hranaCijenaTxtBox.Text);
            
            if (hranaRobnaMarkaComboBox.SelectedItem != null)
            {
                RobnaMarka rm = (RobnaMarka)hranaRobnaMarkaComboBox.SelectedItem;
                Hrana hrana = hranaService.AddHrana(
                        naziv,
                        opis,
                        cijena,
                        kolicina,
                        rm.Id,
                        rm.Naziv
                    );

                // Update the new row with the values from the UI
                newRow["Id"] = hrana.Id;
                newRow["Naziv"] = hrana.Naziv;
                newRow["Opis"] = hrana.Opis;
                newRow["KolicinaNaStanju"] = hrana.KolicinaNaStanju;
                newRow["Cijena"] = hrana.Cijena;
                newRow["RobnaMarka"] = hrana.RobnaMarka;


                // Add the new row to the DataTable
                dataTable.Rows.Add(newRow);

                // Refresh the DataGrid
                dataGrid.Items.Refresh();

                // Close the dialog window
                this.Close();
            }


        }
    }
}
