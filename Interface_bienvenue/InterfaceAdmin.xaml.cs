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
using System.Net;
using System.Net.Mail;
using System.Windows.Navigation;

namespace Interface_bienvenue
{
    /// <summary>
    /// Interaction logic for InterfaceAdmin.xaml
    /// </summary>
    public partial class InterfaceAdmin : Window
    {
        MySqlConnection conn;
      
       
        string filePathPhoto;
        List<Personnel> lisitra= new List<Personnel>();
        List<PersonnelDepartement> lisitraPD= new List<PersonnelDepartement>();
        List<Conge> congeList = new List<Conge>();
        List<TacheRACI> tacheRaciList = new List<TacheRACI>();
        List<FicheDePaie> ficheDePaieList = new List<FicheDePaie>();
       


        public InterfaceAdmin()
        {
            InitializeComponent();
            conn = new MySqlConnection("SERVER=127.0.0.1;DATABASE=sirh;UID=root;PASSWORD=;Convert Zero Datetime=True");
            PannelConge.Visibility = Visibility.Hidden;
            LoadGridConge();
            
            LoadGrid();
            LoadGridRaci();

            LoadGrid();
            // LoadGridDepartementInfo();


            TableauDeBord.Visibility = Visibility.Visible;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;


            //Nombre Congé du tableau de bord
            TextBlockDemandeConge.Text = LoadNombreConge();
            //Nombre Tache du tableau de bord
            TextblockListeTaches.Text = LoadTaches();
            //Nombre Inscription Non Valide
            TextBlockDemandeInscription.Text = LoadInscription();
            //Affichage pdp DataGrid
            filePathPhoto = retournerUrlPhoto(1);
            // Affichage projet Digitalisation
            TextBlockDigitalisation.Text = " Digitalisation " + LoadpDigit() + " % ";
            //Affichage projet Vaccination
            TextBlockVaccination.Text = " Vaccination " + LoadpVac() + " % ";
            //Affichage projet Campagne Publicitaire 
            TextBlockCampagnePublicitaire.Text = " Campagne Pub " + LoadpCpub() + " % ";
            
            //Changer la couleur d'une ligne de datagrid


        }

        //** Afficher Nombre  Demande de Congé Invalide
        public string LoadNombreConge()
        {
            string nombreCongeInvalide = "15";
            string rqtchargerNombreConge = "SELECT COUNT(*) FROM conge WHERE StatutConge = 'Invalide'";
            conn.Open();
            MySqlCommand cmdNombreConge = new MySqlCommand(rqtchargerNombreConge, conn);
            using (DbDataReader reader = cmdNombreConge.ExecuteReader())
            {
                reader.Read();
                nombreCongeInvalide = reader.GetString(0);
                reader.Close();
            }
            conn.Close();
            return nombreCongeInvalide;
        }

        //** Afficher Nombre de taches Non Prises
        public string LoadTaches()
        {
            string nombreTacheNonPrise = "15";
            string rqtchargerNombeTache = "SELECT COUNT(*) FROM tache WHERE StatutTache = 'Inaccomplie'";
            conn.Open();
            MySqlCommand cmdNombreTache = new MySqlCommand(rqtchargerNombeTache, conn);
            using (DbDataReader reader = cmdNombreTache.ExecuteReader())
            {
                reader.Read();
                nombreTacheNonPrise = reader.GetString(0);
                reader.Close();
            }
            conn.Close();
            return nombreTacheNonPrise;
        }

        //** Afficher Nombre Inscription Non Validé
        public string LoadInscription()
        {
            string nombreInscriptionNonValide = "20";
            string rqtInscriptionNonValide = "SELECT COUNT(*) FROM utillisateur WHERE StatutUtilisateur = 'Invalide'";
            conn.Open();
            MySqlCommand cmdnombreInscriptionNonValide = new MySqlCommand(rqtInscriptionNonValide, conn);
            using (DbDataReader reader = cmdnombreInscriptionNonValide.ExecuteReader())
            {
                reader.Read();
                nombreInscriptionNonValide = reader.GetString(0);
                reader.Close();
            }
            conn.Close();
            return nombreInscriptionNonValide;
        }


        //** Loading Datagrid dans le Pannel Demande d'Inscription
        public void LoadGrid()
        {
            DemandeInscriptionGrid.Items.Clear();
            string rqtchargerGrid1 = "SELECT employe.urlPhoto, utillisateur.Nom,utillisateur.Prenom,departement.nomDepartement,poste.Fonction, employe.idEmploye" +
                                    " FROM utillisateur INNER JOIN employe ON utillisateur.idUtilisateur = employe.idEmploye" +
                                    " INNER JOIN departement ON employe.idDepartement = departement.idDepartement " +
                                    "INNER JOIN poste ON employe.idPoste = poste.idPoste " + "";

            MySqlCommand cmdSelectUtilisateur = new MySqlCommand(rqtchargerGrid1, conn);
            conn.Open();
            using (DbDataReader reader = cmdSelectUtilisateur.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Personnel pers = new Personnel(reader.GetString(0), reader.GetString(1).ToUpper(), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));

                        lisitra.Add(pers);
                        DemandeInscriptionGrid.Items.Add(pers);



                    }
                }
            }
            conn.Close();
        }

        //** Loading Datagrid dans le Pannel Departement Informatique

        public void LoadGridDepartementInfo()
        {
            lisitraPD.Clear();
            DepartementInformatique.Items.Clear();
            string rqtchargerGrid1 = "SELECT employe.urlPhoto, utillisateur.Nom,utillisateur.Prenom,employe.CINEmp,employe.statutMatrimonial, employe.Sexemp,employe.DateEntree,poste.Fonction,employe.idEmploye " +
                                     " FROM employe INNER JOIN utillisateur ON utillisateur.idUtilisateur = employe.idEmploye " +
                                     "INNER JOIN poste ON employe.idPoste = poste.idPoste INNER JOIN departement ON employe.idDepartement = departement.idDepartement " +
                                     "and departement.nomDepartement = 'informatique'" + "";

            MySqlCommand cmdSelectEmpInfo = new MySqlCommand(rqtchargerGrid1, conn);
            conn.Open();
            using (DbDataReader reader = cmdSelectEmpInfo.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PersonnelDepartement persD = new PersonnelDepartement(reader.GetString(0), reader.GetString(1).ToUpper(), reader.GetString(2), reader.GetString(3),
                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));

                        lisitraPD.Add(persD);
                        DepartementInformatique.Items.Add(persD);

                    }

                }
                reader.Close();
            }
            conn.Close();
        }

        //** Load Datagrid dans le Pannel Departement RH
        public void LoadGridDepartementRH()
        {
            lisitraPD.Clear();
            DepartementRH.Items.Clear();
            string rqtchargerGrid3 = "SELECT employe.urlPhoto, utillisateur.Nom,utillisateur.Prenom,employe.CINEmp,employe.statutMatrimonial, employe.Sexemp,employe.DateEntree,poste.Fonction, employe.idEmploye " +
                                     " FROM employe INNER JOIN utillisateur ON utillisateur.idUtilisateur = employe.idEmploye " +
                                     "INNER JOIN poste ON employe.idPoste = poste.idPoste INNER JOIN departement ON employe.idDepartement = departement.idDepartement " +
                                     "and departement.nomDepartement = 'ressources humaines'" + "";

            MySqlCommand cmdSelectEmpRH = new MySqlCommand(rqtchargerGrid3, conn);
            conn.Open();
            using (DbDataReader reader = cmdSelectEmpRH.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PersonnelDepartement persD = new PersonnelDepartement(reader.GetString(0), reader.GetString(1).ToUpper(), reader.GetString(2), reader.GetString(3),
                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));

                        lisitraPD.Add(persD);
                        DepartementRH.Items.Add(persD);
                    }

                }
                reader.Close();
            }
            conn.Close();
        }

        //** Load Datagrid dans le Pannel Departement Comptabilite
        public void LoadGridDepartementComptabilite()
        {
            lisitraPD.Clear();
            DepartementComptabilite.Items.Clear();
            string rqtchargerGrid5 = "SELECT employe.urlPhoto, utillisateur.Nom,utillisateur.Prenom,employe.CINEmp,employe.statutMatrimonial, employe.Sexemp,employe.DateEntree,poste.Fonction, employe.idEmploye" +
                                     " FROM employe INNER JOIN utillisateur ON utillisateur.idUtilisateur = employe.idEmploye " +
                                     "INNER JOIN poste ON employe.idPoste = poste.idPoste INNER JOIN departement ON employe.idDepartement = departement.idDepartement " +
                                     "and departement.nomDepartement = 'comptabilite'" + "";

            MySqlCommand cmdSelectEmpComptabilite = new MySqlCommand(rqtchargerGrid5, conn);
            conn.Open();
            using (DbDataReader reader = cmdSelectEmpComptabilite.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PersonnelDepartement persD = new PersonnelDepartement(reader.GetString(0), reader.GetString(1).ToUpper(), reader.GetString(2), reader.GetString(3),
                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8)); 

                        lisitraPD.Add(persD);
                        DepartementComptabilite.Items.Add(persD);
                    }

                }
                reader.Close();
            }
            conn.Close();
        }

        //** Load Datagrid dans le Pannel Departement Marketing
        public void LoadGridDepartementMarketing()
        {
            lisitraPD.Clear();
            DepartementMarketing.Items.Clear();
            string rqtchargerGrid6 = "SELECT employe.urlPhoto, utillisateur.Nom,utillisateur.Prenom,employe.CINEmp,employe.statutMatrimonial, employe.Sexemp,employe.DateEntree,poste.Fonction, employe.idEmploye" +
                                     " FROM employe INNER JOIN utillisateur ON utillisateur.idUtilisateur = employe.idEmploye " +
                                     "INNER JOIN poste ON employe.idPoste = poste.idPoste INNER JOIN departement ON employe.idDepartement = departement.idDepartement " +
                                     "and departement.nomDepartement = 'Marketing'" + "";

            MySqlCommand cmdSelectEmpMarketing = new MySqlCommand(rqtchargerGrid6, conn);
            conn.Open();
            using (DbDataReader reader = cmdSelectEmpMarketing.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PersonnelDepartement persD = new PersonnelDepartement(reader.GetString(0), reader.GetString(1).ToUpper(), reader.GetString(2), reader.GetString(3),
                            reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));

                        lisitraPD.Add(persD);
                        DepartementMarketing.Items.Add(persD);
                    }

                }
                reader.Close();
            }
            conn.Close();
        }

        // Bouton Close
        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }


        public string retournerUrlPhoto(int idEmploye)
        {

            conn.Open();
            string urlPhoto = "null";
            string rechercherUrl = "SELECT urlphoto FROM employe WHERE idEmploye=" + idEmploye;
            MySqlCommand cmdrechercherUrl = new MySqlCommand(rechercherUrl, conn);
            using (DbDataReader reader1 = cmdrechercherUrl.ExecuteReader())
                try
                {
                    reader1.Read();
                    urlPhoto = reader1.GetString(0);

                }
                catch (Exception) { }
            conn.Close();
            return urlPhoto;
        }



        // Bouton Demande Inscription Dans Pannel DemandeInscription
        private void btDemandeInscription_Click(object sender, RoutedEventArgs e)
        {

            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Visible;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

        }


        // Bouton Gestion Projet Dans Pannel Gestion Projet
        private void btGestionProjets_Click(object sender, RoutedEventArgs e)
        {
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Visible;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

        }

        // Bouton Gestion Paie
        private void btPaie_Click(object sender, RoutedEventArgs e)
        {
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;


            PannelFicheDePaie.Visibility = Visibility.Visible;
            loadGridFicheDePaie();

        }

        //Load Grid Paie


        public void loadGridFicheDePaie()
        {

            //gridFicheDePaie.Items.Clear();
            string selectRqst = "SELECT employe.UrlPhoto, utillisateur.Nom, utillisateur.prenom, employe.idDepartement,fichedepaie.salaireBrut, fichedepaie.indemnite1, fichedepaie.Indemnite2, fichedepaie.statutfichedepaie, fichedepaie.HeureSup, fichedepaie.statutFicheDePaie " +
            "FROM fichedepaie inner join employe ON fichedepaie.idEmploye = employe.idEmploye inner join utillisateur on utillisateur.idUtilisateur = fichedepaie.idEmploye";

            MySqlCommand selectCmd = new MySqlCommand(selectRqst, conn);
            conn.Open();
            string departement;
            using (DbDataReader reader = selectCmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        switch (reader.GetString(3))
                        {
                            case "1":
                                departement = "Informatique";
                                break;
                            case "2":
                                departement = "Ressources Humaines ";
                                break;
                            case "3":
                                departement = "Informatique";
                                break;
                            default:
                                departement = "Marketing ";
                                break;
                        }
                        FicheDePaie ficheDePaie = new FicheDePaie(reader.GetString(0), reader.GetString(1).ToUpper(), reader.GetString(2),
                        departement, reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(8), reader.GetString(9));
                        ficheDePaieList.Add(ficheDePaie);
                        gridFicheDePaie.Items.Add(ficheDePaie);



                    }
                }

                reader.Close();
            }
            conn.Close();



        }


        // Bouton Tableau de Bord
        private void btTableaudeBord_Click(object sender, RoutedEventArgs e)
        {
            TextBlockDemandeInscription.Text = LoadInscription();
            TextBlockDemandeConge.Text = LoadNombreConge();
            TableauDeBord.Visibility = Visibility.Visible;

           
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            
           
        }

        // Bouton Gestiion Conge
        private void btGestionConge_Click(object sender, RoutedEventArgs e)
        {
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = (Visibility)Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Visible;
            LoadGridConge();

        }

        // Bouton Departement Informatique

        private void btInformatique_Click(object sender, RoutedEventArgs e)
        {
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Visible;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

            LoadGridDepartementInfo();

        }

        // Bouton Departement RH

        private void btRessourceHumaine_Click(object sender, RoutedEventArgs e)
        {
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Visible;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

            LoadGridDepartementRH();
        }

        // Bouton Departement Comptabilite

        private void btComptabilite_Click(object sender, RoutedEventArgs e)
        {
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Visible;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

            LoadGridDepartementComptabilite();
        }

        // Bouton Departement Marketing

        private void btMarketing_Click(object sender, RoutedEventArgs e)
        {
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Visible;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

            LoadGridDepartementMarketing();
        }

        //** Afficher Nombre  Demande de Projet en Cours
        public string LoadpDigit()
        {
            string pDigit = "15";
            string rqtpDigit = "SELECT (COUNT(NomProjet='digitalisation')*25/10) FROM projet WHERE StatutProjet = 'En Cours';" + "";
            conn.Open();
            MySqlCommand cmdPDig = new MySqlCommand(rqtpDigit, conn);
            using (DbDataReader reader = cmdPDig.ExecuteReader())
            {
                reader.Read();
                string essaie = String.Format("{0:0.00}", 199.8856);
                pDigit = ""+ essaie;

            }
            conn.Close();
            return "75";
        }

        public string LoadpVac()
        {
            string pVac = "15";
            string rqtpVac = "SELECT (COUNT(NomProjet='Vaccination')*25/10) FROM projet WHERE StatutProjet = 'En Cours'" + "";
            conn.Open();
            MySqlCommand cmdPVac = new MySqlCommand(rqtpVac, conn);
            using (DbDataReader reader = cmdPVac.ExecuteReader())
            {
                reader.Read();
                pVac = reader.GetString(0);

            }
            conn.Close();
            return "50";
        }

        public string LoadpCpub()
        {
            string pCpub = "15";
            string rqtPCpub = "SELECT (COUNT(NomProjet='campage publicitaire')*25/10) FROM projet WHERE StatutProjet = 'En Cours';" + "";
            conn.Open();
            MySqlCommand cmdPcPub = new MySqlCommand(rqtPCpub, conn);
            using (DbDataReader reader = cmdPcPub.ExecuteReader())
            {
                reader.Read();
                pCpub = reader.GetString(0);

            }
            conn.Close();
            return "90";
        }

        // Boutons Valider et Annuler DataGrid Gestion Inscription
        private void btAnnulerClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Demande Inscription Remis en Attente");
            DemandeInscriptionGrid.SelectedItems.Clear();

            DemandeInscriptionGrid.Items.Refresh();
        }

        //Changer la couleur d'une ligne de datagrid
        private void ChangeCouleurDGL(bool printing)
        {
            Style rsRowStyle = new Style();
            Style oldStyle = DemandeInscriptionGrid.RowStyle;
            Trigger DataTrigger = new Trigger();
            DataTrigger.Property = DataGridRow.IsSelectedProperty;
            DataTrigger.Value = true;
            rsRowStyle.Triggers.Add(DataTrigger);
            Setter TriggerSetter = new Setter();
            TriggerSetter.Property = DataGridRow.BackgroundProperty;
            TriggerSetter.Value = Brushes.Red;
            rsRowStyle.Setters.Add(TriggerSetter);
            DemandeInscriptionGrid.RowStyle = printing ? rsRowStyle : oldStyle;
        }

        private void btValiderClick(object sender, RoutedEventArgs e)
        {

            conn.Open();
            Personnel valider = DemandeInscriptionGrid.SelectedItem as Personnel;
            string idInscrit = valider.idEmploye;


            string rqtValiderInscription = "UPDATE `utillisateur` SET `StatutUtilisateur` = 'Valide' WHERE `utillisateur`.`idUtilisateur` = " + idInscrit + ";";

            MySqlCommand cmdValiderInscription = new MySqlCommand(rqtValiderInscription, conn);


            cmdValiderInscription.ExecuteNonQuery();
            MessageBox.Show("Demande Validée");
            conn.Close();
            DemandeInscriptionGrid.SelectedItems.Clear();
            LoadGrid();
            DemandeInscriptionGrid.Items.Refresh();


        }


        //Bouton Supprimer et Modifier Personnel Datagrid Departement Informatique


        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            PersonnelDepartement modif = DepartementInformatique.SelectedItem as PersonnelDepartement;

            string modifEmp = modif.idEmploye;
            MessageBox.Show("Voulez-vous Modifier l'Information ?");
            string rqtModifinfo = "UPDATE `employe` SET `Fonction`='" + textboxFonctionInfo.Text.ToString() + "',`Departement'='" + textboxDepartementInfo.Text.ToString() + " WHERE  idEmploye=" + modifEmp + "";
            MessageBox.Show("Modification Effectuée");
            MySqlCommand cmdModifinfo = new MySqlCommand(rqtModifinfo, conn);

            try
            {
                cmdModifinfo.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            DepartementInformatique.SelectedItems.Clear();
            InterfaceAdmin Admin = new InterfaceAdmin();
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Visible;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

            MessageBox.Show("Changements Ajoutés!!");
        }


        private void btModifierInfo(object sender, RoutedEventArgs e)
        {
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Visible;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

        }

        private void btSupprimerierInfo(object sender, RoutedEventArgs e)
        {
            conn.Open();
            PersonnelDepartement supr = DepartementInformatique.SelectedItem as PersonnelDepartement;

            string suprEmp = supr.idEmploye;
            MessageBox.Show("Voulez-vous supprimer ?");
            string rqtSuprEmpInfo = "DELETE FROM employe WHERE  idEmploye=" + suprEmp + "";
            MessageBox.Show("Employé Supprimé");
            MySqlCommand cmdSuprEmpInfo = new MySqlCommand(rqtSuprEmpInfo, conn);

            try
            {
                cmdSuprEmpInfo.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            DepartementInformatique.SelectedItems.Clear();
            InterfaceAdmin Admin = new InterfaceAdmin();
            Admin.Show();
            Admin.LoadGridDepartementInfo();
            Admin.PanelDemandeInscription.Visibility = Visibility.Hidden;
            Admin.TableauDeBord.Visibility = Visibility.Hidden;
            Admin.PanelDemandeInscription.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Info.Visibility = Visibility.Visible;
            Admin.PanelDepartement_RH.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

        }


        //Bouton Supprimer et Modifier Personnel Datagrid Departement RH

        private void supprimerRH(object sender, RoutedEventArgs e)
        {
            conn.Open();
            PersonnelDepartement supr = DepartementRH.SelectedItem as PersonnelDepartement;

            string suprEmp = supr.idEmploye;
            MessageBox.Show("Voulez-vous supprimer ?");
            string rqtSuprEmpRH = "DELETE FROM employe WHERE  idEmploye=" + suprEmp + "";
            MessageBox.Show("Employe Supprimé");
            MySqlCommand cmdSuprEmpInfo = new MySqlCommand(rqtSuprEmpRH, conn);

            try
            {
                cmdSuprEmpInfo.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            DepartementRH.SelectedItems.Clear();
            InterfaceAdmin Admin = new InterfaceAdmin();
            Admin.Show();
            Admin.LoadGridDepartementRH();
            Admin.PanelDemandeInscription.Visibility = Visibility.Hidden;
            Admin.TableauDeBord.Visibility = Visibility.Hidden;
            Admin.PanelDemandeInscription.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Info.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_RH.Visibility = Visibility.Visible;
            Admin.PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

        }

        private void btModifierRh(object sender, RoutedEventArgs e)
        {
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Visible;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            
        }

        private void btnAjouterRHclick(object sender, RoutedEventArgs e)
        {
            conn.Open();
            PersonnelDepartement modif = DepartementRH.SelectedItem as PersonnelDepartement;

            string modifEmp = modif.idEmploye;
            MessageBox.Show("Voulez-vous Modifier l'Information ?");
            string rqtModifinfo = "UPDATE `employe` SET `Fonction`='" + textboxFonctionRH.Text.ToString() + "',`Departement'='" + textboxDepartementRH.Text.ToString() + " WHERE  idEmploye=" + modifEmp + "";
            MessageBox.Show("Modification Effectuée");
            MySqlCommand cmdModifinfo = new MySqlCommand(rqtModifinfo, conn);

            try
            {
                cmdModifinfo.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            DepartementRH.SelectedItems.Clear();
            InterfaceAdmin Admin = new InterfaceAdmin();
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Visible;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            
            MessageBox.Show("Changements Ajoutés!!");
        }




        //Bouton Supprimer et Modifier Personnel Datagrid Departement Compta

        private void supprimmerCompta(object sender, RoutedEventArgs e)
        {
            conn.Open();
            PersonnelDepartement supr = DepartementComptabilite.SelectedItem as PersonnelDepartement;

            string suprEmp = supr.idEmploye;
            MessageBox.Show("Voulez-vous supprimer ?");
            string rqtSuprEmpCompta = "DELETE FROM employe WHERE  idEmploye=" + suprEmp + "";
            MessageBox.Show("Employe Supprimé");
            MySqlCommand cmdSuprEmpInfo = new MySqlCommand(rqtSuprEmpCompta, conn);

            try
            {
                cmdSuprEmpInfo.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            DepartementComptabilite.SelectedItems.Clear();
            InterfaceAdmin Admin = new InterfaceAdmin();
            Admin.Show();
            Admin.LoadGridDepartementComptabilite();
            Admin.PanelDemandeInscription.Visibility = Visibility.Hidden;
            Admin.TableauDeBord.Visibility = Visibility.Hidden;
            Admin.PanelDemandeInscription.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Info.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_RH.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Comptabilite.Visibility = Visibility.Visible;
            Admin.PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

        }

        private void btmodifCompta(object sender, RoutedEventArgs e)
        {
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Visible;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            
        }

        private void btnAjouterCclick(object sender, RoutedEventArgs e)
        {
            conn.Open();
            PersonnelDepartement modif = DepartementComptabilite.SelectedItem as PersonnelDepartement;

            string modifEmp = modif.idEmploye;
            MessageBox.Show("Voulez-vous Modifier l'Information ?");
            string rqtModifinfo = "UPDATE `employe` SET `Fonction`='" + textboxFonctionC.Text.ToString() + "',`Departement'='" + textboxDepartementC.Text.ToString() + " WHERE  idEmploye=" + modifEmp + "";
            MessageBox.Show("Modification Effectuée");
            MySqlCommand cmdModifinfo = new MySqlCommand(rqtModifinfo, conn);

            try
            {
                cmdModifinfo.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            DepartementComptabilite.SelectedItems.Clear();
            InterfaceAdmin Admin = new InterfaceAdmin();
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Visible;
            MatriceRACI.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

            MessageBox.Show("Changements Ajoutés!!");
        }


        //Bouton Supprimer et Modifier Personnel Datagrid Departement Marketing

        private void supprimerMarketing(object sender, RoutedEventArgs e)
        {
            conn.Open();
            PersonnelDepartement supr = DepartementMarketing.SelectedItem as PersonnelDepartement;

            string suprEmp = supr.idEmploye;
            MessageBox.Show("Voulez-vous supprimer ?");
            string rqtSuprEmpMarketing = "DELETE FROM employe WHERE  idEmploye=" + suprEmp + "";
            MessageBox.Show("Employe Supprimé");
            MySqlCommand cmdSuprEmpInfo = new MySqlCommand(rqtSuprEmpMarketing, conn);

            try
            {
                cmdSuprEmpInfo.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            DepartementMarketing.SelectedItems.Clear();
            InterfaceAdmin Admin = new InterfaceAdmin();
            Admin.Show();
            Admin.LoadGridDepartementMarketing();
            Admin.PanelDemandeInscription.Visibility = Visibility.Hidden;
            Admin.TableauDeBord.Visibility = Visibility.Hidden;
            Admin.PanelDemandeInscription.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Info.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_RH.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            Admin.PanelDepartement_Marketing.Visibility = Visibility.Visible;
            MatriceRACI.Visibility = Visibility.Hidden;
          

        }

        private void btmodifMarketing(object sender, RoutedEventArgs e)
        {
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Visible;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            panelParametre.Visibility = Visibility.Hidden;

            FenetreInfoFlottanteMarketing.Visibility = Visibility.Visible;
        }


        private void btAjouterMarketingClick(object sender, RoutedEventArgs e)
        {
            conn.Open();
            PersonnelDepartement modif = DepartementMarketing.SelectedItem as PersonnelDepartement;

            string modifEmp = modif.idEmploye;
            MessageBox.Show("Voulez-vous Modifier l'Information ?");
            string rqtModifinfo = "UPDATE `employe` SET `Fonction`='" + textboxFonctionMarketing.Text.ToString() + "',`Departement'='" + textboxDepartementMarketing.Text.ToString() + " WHERE  idEmploye=" + modifEmp + "";
            MessageBox.Show("Modification Effectuée");
            MySqlCommand cmdModifinfo = new MySqlCommand(rqtModifinfo, conn);

            try
            {
                cmdModifinfo.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            DepartementMarketing.SelectedItems.Clear();
            InterfaceAdmin Admin = new InterfaceAdmin();
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Visible;
            MatriceRACI.Visibility = Visibility.Hidden;
            MessageBox.Show("Changements Ajoutés!!");

        }

        //Fonction chargement de tableau
        private void LoadGridRaci()
        {
            string rqSelectTache = "SELECT nomDeTache FROM `tache`";
            MySqlCommand selectTache = new MySqlCommand(rqSelectTache, conn);

            conn.Open();

            using (DbDataReader reader = selectTache.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TacheRACI tacheRACI = new TacheRACI(reader.GetString(0), "R", "C", "A", "I", "C", "C", "I", "A", "I", "A", "C", "R", "A", "C", "C", "C");
                        tacheRaciList.Add(tacheRACI);
                        gridRACI.ItemsSource = tacheRaciList;
                    }
                }
                reader.Close();
            }
            //Assignation des taches
            string assignerTache = "SELECT RoleRACI, idEmploye, idTache FROM `assigner`";
            MySqlCommand selectAssignation = new MySqlCommand(assignerTache, conn);
            using (DbDataReader reader2 = selectAssignation.ExecuteReader())
            {
                if (reader2.HasRows)
                {
                    int indexTache = 0;
                    while (reader2.Read())
                    {
                        indexTache++;
                        int tempIdEmployeConverted = int.Parse(reader2.GetString(1));

                        switch (indexTache)

                        {
                            case 1:
                                if (tempIdEmployeConverted == 1) { tacheRaciList[indexTache].employe1 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 2) { tacheRaciList[indexTache].employe2 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 3) { tacheRaciList[indexTache].employe3 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 4) { tacheRaciList[indexTache].employe4 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 5) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 6) { tacheRaciList[tempIdEmployeConverted].employe6 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 7) { tacheRaciList[tempIdEmployeConverted].employe7 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 8) { tacheRaciList[tempIdEmployeConverted].employe8 = reader2.GetString(0); }
                                break;
                            case 2:
                                if (tempIdEmployeConverted == 1) { tacheRaciList[indexTache].employe1 = "-"; }
                                if (tempIdEmployeConverted == 2) { tacheRaciList[indexTache].employe2 = "-"; }
                                if (tempIdEmployeConverted == 3) { tacheRaciList[indexTache].employe3 = "-"; }
                                if (tempIdEmployeConverted == 4) { tacheRaciList[indexTache].employe4 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 5) { tacheRaciList[indexTache].employe5 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 6) { tacheRaciList[tempIdEmployeConverted].employe6 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 7) { tacheRaciList[tempIdEmployeConverted].employe7 = reader2.GetString(0); }
                                if (tempIdEmployeConverted == 8) { tacheRaciList[tempIdEmployeConverted].employe8 = reader2.GetString(0); }
                                break;
                            case 3:
                                if (tempIdEmployeConverted == 1) { tacheRaciList[indexTache].employe1 = "-"; }
                                if (tempIdEmployeConverted == 2) { tacheRaciList[indexTache].employe2 = "-"; }
                                if (tempIdEmployeConverted == 3) { tacheRaciList[indexTache].employe3 = "-"; }
                                if (tempIdEmployeConverted == 4) { tacheRaciList[indexTache].employe4 = "-"; }
                                if (tempIdEmployeConverted == 5) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 6) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 7) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 8) { tacheRaciList[indexTache].employe5 = "-"; }
                                break;
                            case 4:
                                if (tempIdEmployeConverted == 1) { tacheRaciList[indexTache].employe1 = "-"; }
                                if (tempIdEmployeConverted == 2) { tacheRaciList[indexTache].employe2 = "-"; }
                                if (tempIdEmployeConverted == 3) { tacheRaciList[indexTache].employe3 = "-"; }
                                if (tempIdEmployeConverted == 4) { tacheRaciList[indexTache].employe4 = "-"; }
                                if (tempIdEmployeConverted == 5) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 6) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 7) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 8) { tacheRaciList[indexTache].employe5 = "-"; }
                                break;
                            case 5:
                                if (tempIdEmployeConverted == 1) { tacheRaciList[indexTache].employe1 = "-"; }
                                if (tempIdEmployeConverted == 2) { tacheRaciList[indexTache].employe2 = "-"; }
                                if (tempIdEmployeConverted == 3) { tacheRaciList[indexTache].employe3 = "-"; }
                                if (tempIdEmployeConverted == 4) { tacheRaciList[indexTache].employe4 = "-"; }
                                if (tempIdEmployeConverted == 5) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 6) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 7) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 8) { tacheRaciList[indexTache].employe5 = "-"; }
                                break;

                            case 6:
                                if (tempIdEmployeConverted == 1) { tacheRaciList[indexTache].employe1 = "-"; }
                                if (tempIdEmployeConverted == 2) { tacheRaciList[indexTache].employe2 = "-"; }
                                if (tempIdEmployeConverted == 3) { tacheRaciList[indexTache].employe3 = "-"; }
                                if (tempIdEmployeConverted == 4) { tacheRaciList[indexTache].employe4 = "-"; }
                                if (tempIdEmployeConverted == 5) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 6) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 7) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 8) { tacheRaciList[indexTache].employe5 = "-"; }
                                break;

                            case 7:
                                if (tempIdEmployeConverted == 1) { tacheRaciList[indexTache].employe1 = "-"; }
                                if (tempIdEmployeConverted == 2) { tacheRaciList[indexTache].employe2 = "-"; }
                                if (tempIdEmployeConverted == 3) { tacheRaciList[indexTache].employe3 = "-"; }
                                if (tempIdEmployeConverted == 4) { tacheRaciList[indexTache].employe4 = "-"; }
                                if (tempIdEmployeConverted == 5) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 6) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 7) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 8) { tacheRaciList[indexTache].employe5 = "-"; }
                                break;
                            case 8:
                                if (tempIdEmployeConverted == 1) { tacheRaciList[indexTache].employe1 = "-"; }
                                if (tempIdEmployeConverted == 2) { tacheRaciList[indexTache].employe2 = "-"; }
                                if (tempIdEmployeConverted == 3) { tacheRaciList[indexTache].employe3 = "-"; }
                                if (tempIdEmployeConverted == 4) { tacheRaciList[indexTache].employe4 = "-"; }
                                if (tempIdEmployeConverted == 5) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 6) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 7) { tacheRaciList[indexTache].employe5 = "-"; }
                                if (tempIdEmployeConverted == 8) { tacheRaciList[indexTache].employe5 = "-"; }
                                break;
                            default:

                                break;
                        }
                        tacheRaciList[indexTache].employe1 = reader2.GetString(0);
                        if (tempIdEmployeConverted == 2) { tacheRaciList[indexTache].employe2 = reader2.GetString(0); }
                        if (tempIdEmployeConverted == 3) { tacheRaciList[tempIdEmployeConverted].employe3 = reader2.GetString(0); }
                        if (tempIdEmployeConverted == 4) { tacheRaciList[tempIdEmployeConverted].employe4 = reader2.GetString(0); }
                        if (tempIdEmployeConverted == 5) { tacheRaciList[tempIdEmployeConverted].employe5 = reader2.GetString(0); }
                        if (tempIdEmployeConverted == 6) { tacheRaciList[tempIdEmployeConverted].employe6 = reader2.GetString(0); }
                        if (tempIdEmployeConverted == 7) { tacheRaciList[tempIdEmployeConverted].employe7 = reader2.GetString(0); }
                        if (tempIdEmployeConverted == 8) { tacheRaciList[tempIdEmployeConverted].employe8 = reader2.GetString(0); }
                        if (indexTache == 7) { indexTache = 0; }
                    }

                }
            }
            //Nom des accomplisseurs
            string responsable = "SELECT nom, prenom FROM `utillisateur`";


            MySqlCommand selectUtilisateur = new MySqlCommand(responsable, conn);

            tacheEtLivrables.HeaderStyle.Resources.Clear();
            using (DbDataReader readerUtilisateur = selectUtilisateur.ExecuteReader())
            {
                if (readerUtilisateur.HasRows)
                {
                    int indexEmploye = 0;
                    while (readerUtilisateur.Read())
                    {
                        indexEmploye++;
                        DataGridTextColumn textColumn = new DataGridTextColumn();
                        string nomEmployeEtNumeroColonne = "employe" + indexEmploye;
                        textColumn.Header = readerUtilisateur.GetString(0) + " " + readerUtilisateur.GetString(1) + " ";
                        textColumn.Binding = new Binding(nomEmployeEtNumeroColonne);
                        gridRACI.Columns.Add(textColumn);
                    }
                }
            }
            conn.Close();

        }


        //Departement Congé
        private void supprimerDepInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Voulez vous vraiment supprimer cet employé");

        }

        private void boutonModifierInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Voulez vous vraiment modifier cet élémént?");
            if (gridConge.SelectedItem != null)
            {
                Conge congeSelected = gridConge.SelectedItem as Conge;
            }
        }

        private void clickImage(object sender, MouseButtonEventArgs e)
        {
            fenetreFlottanteCongé.Visibility = Visibility.Visible;
            try
            {
                if(gridConge.SelectedItem != null) {
                    Conge congeSelected = gridConge.SelectedItem as Conge;
                    txtBoxNomFenetre.Text = congeSelected.nomEmploye;
                    txtBoxPrenomFenetre.Text = congeSelected.prenomEmploye;
                    imagePdPConge.ImageSource = new BitmapImage(new Uri(congeSelected.urlPhoto, UriKind.Absolute));
                    DateTime dateDebutFenetre = DateTime.Parse(congeSelected.debutConge);

                    datePickerDateDebutFenetre.SelectedDate = dateDebutFenetre;

                }
               
            }
            catch (Exception ) { }
        }
        public void LoadGridConge()
        {
            string selectRqst = "SELECT employe.urlPhoto, conge.idTypeConge, employe.idEmploye, utillisateur.Nom, utillisateur.prenom, conge.DateDebutC, conge.DateFinConge,conge.nbJours ,departement.nomDepartement "+
                                "FROM `employe` inner join utillisateur on employe.idEmploye = utillisateur.idUtilisateur inner join departement on employe.idDepartement = departement.idDepartement "+
                                "inner join conge on conge.idEmploye = employe.idEmploye "+"";


            MySqlCommand selectCmd = new MySqlCommand(selectRqst, conn);
            //Conge conge = new Conge("urlPhoto", "idEmploye", "typeConge", "4", "5", "6", "7", "Test");
            //congeList.Add(conge);
            //gridConge.ItemsSource = congeList;
            conn.Open();
            using (DbDataReader reader = selectCmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //charge Type et date
                        //Conge(urlPhoto, idEmploye, typeConge, nomEmploye, prenomEmploye, debutConge, finConge,  nbJours)
                        string dateDebut = reader.GetString(5).Substring(0, reader.GetString(5).IndexOf(" "));
                        string dateFin = reader.GetString(6).Substring(0, reader.GetString(6).IndexOf(" "));
                        string typeConge;
                        switch (reader.GetString(1))
                        {
                            case "1":
                                typeConge = "Congé payé";
                                break;
                            case "2":
                                typeConge = "Congé sans Solde";
                                break;
                            case "3":
                                typeConge = "Congé de maternité";
                                break;
                            case "4":
                                typeConge = "Congé Maladie";
                                break;
                            case "5":
                                typeConge = "Congé payé";
                                break;
                            default:
                                typeConge = "Congé annuel";
                                break;
                        }

                        Conge conge = new Conge(reader.GetString(0), reader.GetString(1), typeConge, reader.GetString(3), reader.GetString(4), dateDebut, dateFin, reader.GetString(7), reader.GetString(8));
                        congeList.Add(conge);

                        gridConge.ItemsSource = congeList;
                    }
                }
                reader.Close();
            }
            conn.Close();
        }

      

        private void clickButtonImprimerFicheDePaie(object sender, RoutedEventArgs e)
        {
            DemandeDeCongeAdmin demandeDeConge = new DemandeDeCongeAdmin("1");
            
            demandeDeConge.Show();
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
          
            panelParametre.Visibility = Visibility.Hidden;

        }

        private void btParametre_Click(object sender, RoutedEventArgs e)
        {
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Visible;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;

            
        }

        private void btOutils_Click(object sender, RoutedEventArgs e)
        {
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            TableauDeBord.Visibility = Visibility.Hidden;
            PanelDemandeInscription.Visibility = Visibility.Hidden;
            PanelDepartement_Info.Visibility = Visibility.Hidden;
            PanelDepartement_RH.Visibility = Visibility.Hidden;
            PanelDepartement_Comptabilite.Visibility = Visibility.Hidden;
            PanelDepartement_Marketing.Visibility = Visibility.Visible;
            FenetreInfoFlottante.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteCompta.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteMarketing.Visibility = Visibility.Hidden;
            FenetreInfoFlottanteRH.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Hidden;
            fenetreFlottanteCongé.Visibility = Visibility.Hidden;
            PannelFicheDePaie.Visibility = Visibility.Hidden;

            panelParametre.Visibility = Visibility.Visible;
            




        }

        private void CloseFlottanteConge(object sender, MouseButtonEventArgs e)
        {
            fenetreFlottanteCongé.Visibility=Visibility.Hidden;
        }

        private void FermerFlottanteMarketing(object sender, MouseButtonEventArgs e)
        {
            FenetreInfoFlottanteMarketing.Visibility=Visibility.Hidden;
        }

        //fermer Marketing ity fa disodiso kely euh!!!!!
        private void fermerfenetreflottanteMarketing(object sender, MouseButtonEventArgs e)
        {
            FenetreInfoFlottanteRH.Visibility=Visibility.Hidden;
        }

        private void fermerComptabiliteFlottante(object sender, MouseButtonEventArgs e)
        {
            FenetreInfoFlottanteCompta.Visibility=Visibility.Hidden;
        }

        private void fermerInfoFlottante(object sender, MouseButtonEventArgs e)
        {
            FenetreInfoFlottante.Visibility=Visibility.Hidden;
        }

        private void clickCarteDemandeInscription(object sender, MouseButtonEventArgs e)
        {
            TableauDeBord.Visibility=Visibility.Hidden;
            PanelDemandeInscription.Visibility=Visibility.Visible;
        }

        private void CarteTachesDown(object sender, MouseButtonEventArgs e)
        {
            TableauDeBord.Visibility = Visibility.Hidden;
            MatriceRACI.Visibility = Visibility.Visible;
        }

        private void CardCongeDown(object sender, MouseButtonEventArgs e)
        {
            TableauDeBord.Visibility = Visibility.Hidden;
            PannelConge.Visibility = Visibility.Visible;
        }

        private void clickEnvoyerFDP(object sender, RoutedEventArgs e)
        {
            try
            {
                string fichePdf = "C:/FicheDePaie.pdf";
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("loop.crowdfunding@gmail.com");
                msg.To.Add("ratovolalao.contact@gmail.com");
                msg.Subject = "Fiche de paie";
                msg.Body = "Voilà votre fiche de paie " + fichePdf;
                msg.Attachments.Add(new Attachment(fichePdf));





                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "loop.crowdfunding@gmail.com";
                ntcd.Password = "xqkrtrokrarwmcom";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);





                MessageBox.Show("votre email est envoyé");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
