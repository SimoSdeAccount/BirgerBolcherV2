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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BirgerBolcherV2
{
    /// <summary>
    /// Interaction logic for VisBolcher.xaml
    /// </summary>
    public partial class VisBolcher : Page
    {
        DataGridFylder grid;
        public VisBolcher()
        {
            InitializeComponent();
            grid = new DataGridFylder(new SqlConnection(ConfigurationManager.ConnectionStrings["BolcheDBCon"].ConnectionString));
            grid.getsetDataGrid = BolcheDataGrid;
        }
        private void loadGrid(string view)
        {
            grid.getsetView = view;
            grid.Fyld();
        }
        private void AltData_Click(object sender, RoutedEventArgs e)
        {
            loadGrid("SELECT * FROM AltBolcheData");
        }
        private void RødeBolcher_Click(object sender, RoutedEventArgs e)
        {
            loadGrid("SELECT Navn FROM AltBolcheData WHERE Farve = 'Rød'");
        }
        private void RødeblåBolcher_Click(object sender, RoutedEventArgs e)
        {
            loadGrid("SELECT Navn FROM AltBolcheData WHERE Farve = 'Rød' OR Farve = 'Blå'");
        }
        private void IkkeRødeBolcher_Click(object sender, RoutedEventArgs e)
        {
            loadGrid("SELECT Navn FROM AltBolcheData WHERE Farve != 'Rød' ORDER BY Navn ASC");
        }
        private void StarterMedB_Click(object sender, RoutedEventArgs e)
        {
            loadGrid("SELECT Navn FROM AltBolcheData WHERE Navn LIKE 'B%'");
        }
        private void MindstEtE_Click(object sender, RoutedEventArgs e)
        {
            loadGrid("SELECT Navn FROM AltBolcheData WHERE Navn LIKE '%e%'");
        }
        private void NavnVægtUnder10_Click(object sender, RoutedEventArgs e)
        {
            loadGrid("SELECT Navn, Vægt FROM AltBolcheData WHERE Vægt < 10 ORDER BY Vægt ASC");
        }
        private void VægtMellem10og12_Click(object sender, RoutedEventArgs e)
        {
            loadGrid("SELECT Navn, Vægt FROM AltBolcheData WHERE Vægt >= 10 AND Vægt <= 12 ORDER BY Navn, Vægt ASC");
        }
        private void TreTungeste_click(object sender, RoutedEventArgs e)
        {
            loadGrid("SELECT TOP 3 * FROM AltBolcheData ORDER BY Vægt DESC");
        }
        private void BolcheSøgning_Click(object sender, RoutedEventArgs e)
        {
            string betingelsesKolonne = string.Empty;
            string tekst = "'" + SøgeTekst.Text + "'";
            switch(SøgeKriterie.SelectedIndex.ToString())
            {
                case "0":
                    betingelsesKolonne = "RåvarePris";
                    break;
                case "1":
                    betingelsesKolonne = "Vægt";
                    break;
                case "2":
                    betingelsesKolonne = "SmagType";
                    break;
                case "3":
                    betingelsesKolonne = "Styrke";
                    break;
                case "4":
                    betingelsesKolonne = "Surhed";
                    break;
                case "5":
                    betingelsesKolonne = "Farve";
                    break;
            }
            string betingelsesTekst = betingelsesKolonne + " = " + tekst;
            loadGrid("SELECT * FROM AltBolcheData WHERE " + betingelsesTekst);
        }
    }
}
