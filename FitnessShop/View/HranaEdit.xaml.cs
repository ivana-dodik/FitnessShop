using FitnessShop.ServiceLayer.Domain;
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
    /// Interaction logic for HranaEdit.xaml
    /// </summary>
    public partial class HranaEdit : Window
    {
        private DataGrid dataGrid;
        private DataTable dataTable;
        private int id;
        private HranaService hranaService = new HranaServiceImpl();
        private AdminPanel adminPanel;
        private string oldRobnaMarka;

        public HranaEdit(DataGrid dataGrid, DataTable dataTable, Hrana hrana, List<RobnaMarka> robneMarke, AdminPanel adminPanel)
        {
            InitializeComponent();

            this.dataGrid = dataGrid;
            this.dataTable = dataTable;
            this.id = hrana.Id;
            this.adminPanel = adminPanel;
            hranaNazivTxtBox.Text = hrana.Naziv;
            hranaOpisTxtBox.Text = hrana.Opis;
            hranaCijenaTxtBox.Text = hrana.Cijena.ToString();
            hranaKolicinaTxtBox.Text = hrana.KolicinaNaStanju.ToString();
            hranaRobnaMarkaComboBox.ItemsSource = robneMarke;
            SelectOldRobnaMarka(robneMarke, hrana.RobnaMarka);
            oldRobnaMarka = hrana.RobnaMarka;
        }

        private void SelectOldRobnaMarka(List<RobnaMarka> robneMarke, string robnaMarka)
        {
            foreach (var rm in robneMarke)
            {
                if (rm.Naziv == robnaMarka)
                {
                    hranaRobnaMarkaComboBox.SelectedItem = rm;
                    return;
                }
            }
        }

        private void btnIzmijeni_Click(object sender, RoutedEventArgs e)
        {
            var updatedNaziv = hranaNazivTxtBox.Text;
            var updatedOpis = hranaOpisTxtBox.Text;
            var updatedCijena = Convert.ToDouble(hranaCijenaTxtBox.Text);
            var updatedKolicina = Convert.ToInt32(hranaKolicinaTxtBox.Text);

            if (hranaRobnaMarkaComboBox.SelectedItem != null)
            {
                RobnaMarka rm = (RobnaMarka)hranaRobnaMarkaComboBox.SelectedItem;

                hranaService.EditHrana(updatedNaziv, updatedOpis, updatedCijena, updatedKolicina, rm.Id, id);

                // Assume that dt is the DataTable that is bound to the DataGrid
                DataRow[] rows = dataTable.Select("id = " + id); // id is the ID of the edited row
                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    // Assume that naziv and opis are the columns that were edited in the database
                    row["Naziv"] = updatedNaziv;
                    row["Opis"] = updatedOpis;
                    row["Cijena"] = updatedCijena;
                    row["KolicinaNaStanju"] = updatedKolicina;
                    row["RobnaMarka"] = rm.Naziv;
                }

                if (rm.Naziv != oldRobnaMarka)
                {
                    adminPanel.ReloadRobneMarke();
                }

                this.Close();
            }
        }
    }
}
