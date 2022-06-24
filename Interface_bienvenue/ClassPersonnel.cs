using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Interface_bienvenue
{
    internal class Personnel
    {
        public string urlPhoto { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Departement { get; set; }
        public string Fonction { get; set; }
        public string idEmploye { get; set; }
        Image image = new Image();



        public Personnel(string urlPhoto, string Nom, string Prenom, string Departement, string Fonction, string idEmploye)
        {
            this.urlPhoto = urlPhoto;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Departement = Departement;
            this.Fonction = Fonction;
            this.idEmploye = idEmploye;
        }



    }
}
   
