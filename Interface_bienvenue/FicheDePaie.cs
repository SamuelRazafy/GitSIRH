using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_bienvenue
    {
        internal class FicheDePaie
        {
            public string urlPhoto { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Departement { get; set; }
            public string SalaireBase { get; set; }

            public string Indemnite1 { get; set; }

            public string Indemnite2 { get; set; }

            public string SalaireBrut { get; set; }

            public string SalaireNet { get; set; }

            public string Statut { get; set; }

            public string HeuresSupp { get; set; }

        public FicheDePaie(string urlPhoto, string nom, string prenom, string departement, string salaireBase, string indemnite1, string indemnite2, string salaireBrut, string salaireNet, string HeuresSupp, string statut)
            {
                this.urlPhoto = urlPhoto;
                Nom = nom;
                Prenom = prenom;
                Departement = departement;
                SalaireBase = salaireBase;
                Indemnite1 = indemnite1;
                Indemnite2 = indemnite2;
                SalaireBrut = salaireBrut;
                SalaireNet = salaireNet;
                 this.HeuresSupp = HeuresSupp;  
                Statut = statut;
            }





        }
    }


