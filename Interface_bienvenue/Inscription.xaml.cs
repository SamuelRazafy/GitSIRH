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

namespace Interface_bienvenue
{
    /// <summary>
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        MySqlConnection conn;
        public Inscription()
        {
            InitializeComponent();
            string connectionString = "SERVER=127.0.0.1;DATABASE=sirh; UID =root; PASSWORD=";
            conn = new MySqlConnection(connectionString);
            textBoxNom.Text = "RATOVOLALAO";
            textBoxPrenom.Text = "Nambinina";
            textBoxEmail.Text = "nambininaratovo@gmail.com";
            textBoxMdp.Password = "12345";
            textBoxConfirmerMdp.Password = "12345";
        }

        private void btnInscription(object sender, RoutedEventArgs e)
        {
            conn.Open();
            string nom = textBoxNom.Text;
            string prenom = textBoxPrenom.Text;
            string email = textBoxEmail.Text;
            string mdp = textBoxMdp.Password.ToString();
            string confimerMdp = textBoxConfirmerMdp.Password.ToString();

            if (confimerMdp != mdp)
            {
                MessageBox.Show("Les deux mots de passe ne sont pas identiques. Réessayez");
                Color color = (Color)ColorConverter.ConvertFromString("#FF0000");
                textBoxConfirmerMdp.Foreground = new System.Windows.Media.SolidColorBrush(color);
            }
            else
            {
                if (String.IsNullOrEmpty(textBoxNom.Text) | String.IsNullOrEmpty(textBoxNom.Text) | String.IsNullOrEmpty(textBoxNom.Text) | String.IsNullOrEmpty(textBoxNom.Text) | String.IsNullOrEmpty(textBoxNom.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs. Réessayez");
                }
                else
                {
                    string requete1 = "INSERT INTO `utillisateur` (`idUtilisateur`, `email`, `mdp`, `Prenom`, `Nom`) VALUES (NULL, '" + email + "', '" + mdp + "', '" + nom + "', '" + prenom + "');";
                    MySqlCommand cmd = new MySqlCommand(requete1, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Les valeurs ont bien été entrée dans la Base de Données. Veuillez Entrez les informations suivantes pour confirmer");
                    this.Hide();
                    ConfirmerInscription ins1 = new ConfirmerInscription();
                    ins1.Show();
                }




            }
            conn.Close();

        }

        private void fermerInscription(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            new essaiConn().Show();
        }
    }
}
