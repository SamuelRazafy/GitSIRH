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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Interface_bienvenue
{
    /// <summary>
    /// Logique d'interaction pour DemandeDeCongeAdmin.xaml
    /// </summary>
    public partial class DemandeDeCongeAdmin : Window
    {
        MySqlConnection conn;

        public string idFP { get; set; }

        public DemandeDeCongeAdmin()
        {
            InitializeComponent();
            conn = new MySqlConnection("SERVER=127.0.0.1; DATABASE='sirh'; UID=root; PASSWORD=");

        }
        public DemandeDeCongeAdmin(string i)
        {
            InitializeComponent();
            this.idFP = i;
            conn = new MySqlConnection("SERVER=127.0.0.1; DATABASE='sirh'; UID=root; PASSWORD=");
            loadFicheDePaie();
        }

        public void loadFicheDePaie()


        {
            conn.Open();
            
            string reqUser = "SELECT utillisateur.nom, fichedepaie.idFP, fichedepaie.salaireBrut, fichedepaie.indemnite1, fichedepaie.Indemnite2, fichedepaie.SalaireDeBase, fichedepaie.SalaireDeBase " +
                "FROM ficheDepaie inner join utillisateur on fichedepaie.idEmploye = utillisateur.idUtilisateur where fichedepaie.idFP = " + idFP; ;
            
            MySqlCommand selectCmd = new MySqlCommand(reqUser, conn);
            try
            {
                using (DbDataReader reader = selectCmd.ExecuteReader())
                {
                    reader.Read();
                    int A = int.Parse(reader.GetString(2));
                    int salaireNet = int.Parse(reader.GetString(2));
                    int Impot = A * (5 / 100);
                    int I1 = int.Parse(reader.GetString(3));
                    int I2 = int.Parse(reader.GetString(4));
                    int Sbrute = int.Parse(reader.GetString(2));
                    Sbrute = I1 + I2 + Sbrute;
                    TextBoxSalaireBase.Text = ""+Sbrute;
                    TextBoxNom.Text = reader.GetString(0);
                    TextBoxMatricule.Text = "0000000" + reader.GetString(1);
                    TextBoxSalaireBrut.Text = reader.GetString(2);
                    TextBoxIndemnite1.Text = reader.GetString(3);
                    TextBoxIndemnite2.Text = reader.GetString(4);
                    TextBoxImpot.Text = "" + Impot;
                    int salaireNetFarany = A - Impot;
                    TextBoxSalaireSalaireNet.Text = "" + salaireNetFarany;
                    reader.Close();

                }
            }
            catch (Exception ex) { }

           
         
            conn.Close();
        }


        private void BtnImprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                gridImprimer.Visibility = Visibility.Hidden;
                if (printDialog.ShowDialog() == true)
                {

                    printDialog.PrintVisual(gridPage, "FICHE DE PAIE");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
