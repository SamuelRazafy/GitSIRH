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
using System.Data;
using System.Diagnostics;

namespace Interface_bienvenue
{
    /// <summary>
    /// Interaction logic for essaiConn.xaml
    /// </summary>
    public partial class essaiConn : Window
    {
        MySqlConnection conn = new MySqlConnection("SERVER=localhost;PORT=3308;DATABASE=sirh;UID=root;PASSWORD=");
        private string email, password, sql;

        private MySqlCommand command;


        public essaiConn()
        {

            InitializeComponent();
            textMail.Text = "adminGO@gmail.com";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            email = textMail.Text;
            password = textMdp.Password.ToString();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Saisir email et mots de passe ");
            }
            else
            {
                if (email == "adminGO@gmail.com" && password == "admin")
                {
                    InterfaceAdmin interfaceAdmin = new InterfaceAdmin();
                    this.Hide();
                    interfaceAdmin.Show();
                }
                else
                {
                    conn.Open();
                    sql = "SELECT * FROM utillisateur WHERE email = '" + email + "' AND mdp = '" + password + "'";

                    {
                        try
                        {
                            command = new MySqlCommand(sql, conn);
                            object a = command.ExecuteScalar();
                            if (a == null)
                            {
                                MessageBox.Show("Invalide email ou mots de passe");
                            }
                            else
                            {

                                MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn);
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    Test mety = new Test();
                                    this.Hide();
                                    mety.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Ereur");
                                }
                            }
                        }
                        catch (MySqlException x)
                        {
                            MessageBox.Show("" + x);
                        }

                        textMail.Text = "";
                        textMdp.Password = "";
                        conn.Close();
                    }
                }
            }

        }

        private void butGoogle_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.google.com/");
        }

        private void butFace_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.facebook.com/");
        }

        private void choix_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void butMdp_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void textMail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void butInsc_Click(object sender, RoutedEventArgs e)
        {
            Inscription inscription = new Inscription();
            inscription.Show();
            this.Hide();
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pz = new MainWindow();
            this.Hide();
            pz.Show();
        }
    }
}
