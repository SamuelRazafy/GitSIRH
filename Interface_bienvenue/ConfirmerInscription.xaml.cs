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
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace Interface_bienvenue
{
    /// <summary>
    /// Logique d'interaction pour ConfirmerInscription.xaml
    /// </summary>
    public partial class ConfirmerInscription : Window

    {
        MySqlConnection conn;
        string filePathPhoto = "NULL";
        string filePathCV = "NULL";
        string filePathCIN = "NULL";

        public ConfirmerInscription()
        {
            InitializeComponent();
            string connectionString = "SERVER=127.0.0.1;DATABASE=sirh; UID =root; PASSWORD=";
            conn = new MySqlConnection(connectionString);
            comboBoxDepartement.SelectedIndex = 0;
            TextBoxAdresse.Text = "Lot 100 I Bis Ambohinambo Talatamaty";
            TextBoxNombreDenfant.Text = "0";
            TextBoxPoste.Text = "Développeur Full Stack";
            TextBoxSituationMatrimonial.Text = "Célibataire";
            TextBoxTelephone.Text = "+261 34 64 816 15";
            TextBoxTelephone2.Text = "020 22 544 51";
            DatePickerNaissance.SelectedDate = DateTime.Now;


        }

        private void buttonInscription_Click_1(object sender, RoutedEventArgs e)
        {
            
            essaiConn essaiConnexion = new essaiConn();
            this.Hide();
            essaiConnexion.Show();
           
          
        }

        private void TextBoxNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxAdresse_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChangerPdPClick(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? response = openFileDialog.ShowDialog();
            if (response == true)
            {
                filePathPhoto = openFileDialog.FileName;
                filePathPhoto = filePathPhoto.Replace("\\", "\\\\");


                MessageBox.Show(filePathPhoto);  imagePdP.ImageSource = new BitmapImage(new Uri(filePathPhoto, UriKind.Absolute));


            }

        }

        private void btnImporterCin(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
          
            bool? response = openFileDialog.ShowDialog();
            if (response == true)
            {
                filePathPhoto = openFileDialog.FileName;
                
                filePathPhoto = filePathPhoto.Replace("\\", "\\\\");


                MessageBox.Show(filePathPhoto);
                imagePdP.ImageSource = new BitmapImage(new Uri(filePathPhoto, UriKind.Absolute));
                
            }
            
        }
    }
}
