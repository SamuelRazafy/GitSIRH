using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_bienvenue
{
    internal class Departement
    {
        public String nom_Departement { get; set; }

        public Departement(String nom_Departement)
        {
            this.nom_Departement = nom_Departement;
        }
    }
}
