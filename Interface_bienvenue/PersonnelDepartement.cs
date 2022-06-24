using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Interface_bienvenue
{
    internal class PersonnelDepartement
    {
        public string urlPhoto { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CINEmp { get; set; }
        public string statutMatrimonial { get; set; }
        public string Sexemp { get; set; }

        public string DateEntree { get; set; }

        public string idEmploye { get; set; }
        public string Fonction { get; set; }

        Image image = new Image();



        public PersonnelDepartement(string urlPhoto, string Nom, string Prenom, string CINEmp, string statutMatrimonial, string Sexemp, string DateEntree, string Fonction, string idEmploye)
        {
            this.urlPhoto = urlPhoto;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.CINEmp = CINEmp;
            this.statutMatrimonial = statutMatrimonial;
            this.Sexemp = Sexemp;
            this.DateEntree = DateEntree;
            this.Fonction = Fonction;
            this.idEmploye = idEmploye;
        }

    }
}
