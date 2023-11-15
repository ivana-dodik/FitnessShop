using FitnessShop.ServiceLayer.Services;
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
    /// Interaction logic for RobnaMarkaAdd.xaml
    /// </summary>
    public partial class RobnaMarkaAdd : Window
    {

        private DataGrid dataGrid;
        private DataTable dataTable;
        private RobneMarkeService robnaMarkaService = new RobneMarkeServiceImpl();

        public RobnaMarkaAdd(DataGrid dataGrid, DataTable dataTable)
        {
            this.dataGrid = dataGrid;
            this.dataTable = dataTable;
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var newRow = dataTable.NewRow();
            var naziv = robnaMarkaNazivTxtBox.Text;
            var opis = robnaMarkaOpisTxtBox.Text;
            var robnaMarka = robnaMarkaService.AddRobnaMarka(naziv, opis);
            //newRow.Table.Columns;
            // Update the new row with the values from the UI
            newRow["Id"] = robnaMarka.Id;
            newRow["Naziv"] = robnaMarka.Naziv;
            newRow["Opis"] = robnaMarka.Opis;
            newRow["BrojProizvoda"] = 0;


            // Add the new row to the DataTable
            dataTable.Rows.Add(newRow);

            // Refresh the DataGrid
            dataGrid.Items.Refresh();

            // Close the dialog window
            this.Close();
        }
    }
}
