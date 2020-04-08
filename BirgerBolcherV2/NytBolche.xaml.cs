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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BirgerBolcherV2
{
    /// <summary>
    /// Interaction logic for NytBolche.xaml
    /// </summary>
    public partial class NytBolche : Page
    {
        private SqlConnection con;
        public NytBolche()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["BolcheDBCon"].ConnectionString);
            fyldComboBokse();
        }
        private void SubmitBolche_Klik(object sender, RoutedEventArgs e)
        {
            string[] parametre = { "@Navn", "@RåvarePris", "@Vægt", "@Smagtype", "@Styrke", "@Surhed", "@Farve" };
            string[] værdier = {BolcheNavnTxt.Text, RåvarePrisTxt.Text, VægtTxt.Text, SmagtypeComb.SelectedItem.ToString(), StyrkeComb.SelectedItem.ToString(), SurhedComb.SelectedItem.ToString(), FarveComb.SelectedItem.ToString() };
            IndsætBolche nytBolche = new IndsætBolche(con);
            nytBolche.getsetParametre = parametre;
            nytBolche.getsetVærdier = værdier;
            nytBolche.Indsæt();
        }
        private void fyldComboBokse()
        {
            ComboBox[] comboBokse = { SmagtypeComb, StyrkeComb, SurhedComb, FarveComb };
            string[] fillDataQueries = { "SELECT TypeNavn FROM SmagType", "SELECT StyrkeNavn FROM Styrke", "SELECT SurhedNavn FROM Surhed", "SELECT FarveNavn FROM Farve" };
            string[] dataKolonner = { "TypeNavn", "StyrkeNavn", "SurhedNavn", "FarveNavn" };
            for (int i = 0; i < comboBokse.Length; i++)
            {
                ComboFylder fyldCombo = new ComboFylder(con);
                fyldCombo.getsetCombo = comboBokse[i];
                fyldCombo.getsetCmd = new SqlCommand(fillDataQueries[i]);
                fyldCombo.getsetdataKolonne = dataKolonner[i];
                fyldCombo.FyldDropDownBoks();
            }
        }
    }
}
