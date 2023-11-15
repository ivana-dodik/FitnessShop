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
    /// Interaction logic for RobnaMarkaEdit.xaml
    /// </summary>
    public partial class RobnaMarkaEdit : Window
    {
        private DataGrid dataGrid;
        private DataTable dataTable;
        private int id;
        private RobneMarkeService robnaMarkaService = new RobneMarkeServiceImpl();
        public RobnaMarkaEdit(DataGrid dataGrid, DataTable dataTable, int id, string naziv, string opis)
        {
            this.dataGrid = dataGrid;
            this.dataTable = dataTable;
            this.id = id;
            InitializeComponent();
            robnaMarkaNazivTxtBox.Text = naziv;
            robnaMarkaOpisTxtBox.Text = opis;
        }

        private void btnIzmijeni_Click(object sender, RoutedEventArgs e)
        {
            var updatedNaziv = robnaMarkaNazivTxtBox.Text;
            var updatedOpis = robnaMarkaOpisTxtBox.Text;

            robnaMarkaService.EditRobnaMarka(id, updatedNaziv, updatedOpis);

            // Assume that dt is the DataTable that is bound to the DataGrid
            DataRow[] rows = dataTable.Select("id = " + id); // id is the ID of the edited row
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                // Assume that naziv and opis are the columns that were edited in the database
                row["naziv"] = updatedNaziv;
                row["opis"] = updatedOpis;
            }

            this.Close();
        }
    }
}
