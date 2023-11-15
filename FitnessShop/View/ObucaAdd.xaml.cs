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
    /// Interaction logic for ObucaAdd.xaml
    /// </summary>
    public partial class ObucaAdd : Window
    {
        private DataGrid dataGrid;
        private DataTable dataTable;
        private ObucaService obucaService = new ObucaServiceImpl();

        public ObucaAdd(List<RobnaMarka> robneMarke, List<PolAttr> polovi, List<VelicinaAttr> velicine, DataGrid dataGrid, DataTable dataTable)
        {
            InitializeComponent();
            obucaRobnaMarkaComboBox.ItemsSource = robneMarke;
            obucaPolComboBox.ItemsSource = polovi;
            obucaPolComboBox.DisplayMemberPath = "StringValue";
            obucaVelicinaComboBox.ItemsSource = velicine;
            obucaVelicinaComboBox.DisplayMemberPath = "Naziv";
            this.dataGrid = dataGrid;
            this.dataTable = dataTable;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var newRow = dataTable.NewRow();
            var naziv = obucaNazivTxtBox.Text;
            var opis = obucaOpisTxtBox.Text;
            var cijena = Convert.ToDouble(obucaCijenaTxtBox.Text);
            var kolicina = Convert.ToInt32(obucaKolicinaTxtBox.Text);
            var boja = obucaBojaTxtBox.Text;

            if (obucaRobnaMarkaComboBox.SelectedItem != null && obucaPolComboBox.SelectedItem != null && obucaVelicinaComboBox.SelectedItem != null)

            {
                RobnaMarka rm = (RobnaMarka)obucaRobnaMarkaComboBox.SelectedItem;
                PolAttr pol = (PolAttr)obucaPolComboBox.SelectedItem;
                VelicinaAttr velicina = (VelicinaAttr)obucaVelicinaComboBox.SelectedItem;

                Obuca obuca = obucaService.AddObuca(naziv, opis, cijena, kolicina, boja, pol, rm.Id, rm.Naziv, velicina);

                newRow["Id"] = obuca.Id;
                newRow["Naziv"] = obuca.Naziv;
                newRow["Opis"] = obuca.Opis;
                newRow["KolicinaNaStanju"] = obuca.KolicinaNaStanju;
                newRow["Cijena"] = obuca.Cijena;
                newRow["RobnaMarka"] = obuca.RobnaMarka;
                newRow["Boja"] = obuca.Boja;
                newRow["Pol"] = obuca.Pol;
                newRow["Velicina"] = obuca.Velicina;

                dataTable.Rows.Add(newRow);

                dataGrid.Items.Refresh();

                this.Close();
            }


        }
    }
}
