using FitnessShop.ServiceLayer.Domain;
using FitnessShop.ServiceLayer.Services;
using FitnessShop.ServiceLayer.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FitnessShop.View
{
    /// <summary>
    /// Interaction logic for ObucaEdit.xaml
    /// </summary>
    public partial class ObucaEdit : Window
    {
        private DataGrid dataGrid;
        private DataTable dataTable;
        private int id;
        private VelicinaAttr velicinaObuce;
        private AdminPanel adminPanel;
        private string oldRobnaMarka;

        private ObucaService obucaService = new ObucaServiceImpl();

        public ObucaEdit(DataGrid dataGrid, DataTable dataTable, Obuca obuca, List<RobnaMarka> robneMarke, List<PolAttr> polovi, AdminPanel adminPanel)
        {
            List<VelicinaAttr> velicinaAttrList = Enum.GetValues(typeof(Velicina))
                .Cast<Velicina>()
                .Select(v => Velicine.GetAttr(v))
                .ToList();

            InitializeComponent();

            this.dataGrid = dataGrid;
            this.dataTable = dataTable;
            this.id = obuca.Id;
            this.adminPanel = adminPanel;
            this.oldRobnaMarka = obuca.RobnaMarka;

            obucaNazivTxtBox.Text = obuca.Naziv;
            obucaOpisTxtBox.Text = obuca.Opis;
            obucaCijenaTxtBox.Text = obuca.Cijena.ToString();
            obucaKolicinaTxtBox.Text = obuca.KolicinaNaStanju.ToString();
            obucaBojaTxtBox.Text = obuca.Boja;

            obucaRobnaMarkaComboBox.ItemsSource = robneMarke;
            SelectOldRobnaMarka(robneMarke, obuca.RobnaMarka);

            obucaPolComboBox.ItemsSource = polovi;
            obucaPolComboBox.DisplayMemberPath = "StringValue";
            SelectOldPol(polovi, obuca.Pol);

            foreach (var velicina in velicinaAttrList)
            {
                if (velicina.Naziv == obuca.Velicina)
                {
                    velicinaObuce = velicina;
                    break;
                }
            }

        }

        private void SelectOldPol(List<PolAttr> polovi, string pol)
        {
            foreach (var p in polovi)
            {
                if (p.StringValue == pol)
                {
                    obucaPolComboBox.SelectedItem = p;
                    return;
                }
            }
        }

        private void SelectOldRobnaMarka(List<RobnaMarka> robneMarke, string robnaMarka)
        {
            foreach (var rm in robneMarke)
            {
                if (rm.Naziv == robnaMarka)
                {
                    obucaRobnaMarkaComboBox.SelectedItem = rm;
                    return;
                }
            }
        }

        private void btnIzmijeni_Click(object sender, RoutedEventArgs e)
        {
            var updatedNaziv = obucaNazivTxtBox.Text;
            var updatedOpis = obucaOpisTxtBox.Text;
            var updatedCijena = Convert.ToDouble(obucaCijenaTxtBox.Text);
            var updatedKolicina = Convert.ToInt32(obucaKolicinaTxtBox.Text);
            var updatedBoja = obucaBojaTxtBox.Text;

            if (obucaRobnaMarkaComboBox.SelectedItem != null && obucaPolComboBox.SelectedItem != null)
            {
                RobnaMarka rm = (RobnaMarka)obucaRobnaMarkaComboBox.SelectedItem;
                PolAttr pol = (PolAttr)obucaPolComboBox.SelectedItem;

                obucaService.EditObuca(updatedNaziv, updatedOpis, updatedCijena, updatedKolicina, updatedBoja, pol, rm.Id, velicinaObuce, id);

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
                    row["Boja"] = updatedBoja;
                    row["RobnaMarka"] = rm.Naziv;
                    row["Pol"] = pol.StringValue;
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
