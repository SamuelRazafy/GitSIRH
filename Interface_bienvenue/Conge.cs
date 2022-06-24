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
    internal class Conge
    {
        public string idEmploye { get; set; }

        public string urlPhoto { get; set; }

        public string typeConge { get; set; }
        public string nomEmploye { get; set; }
        public string prenomEmploye { get; set; }
        public string debutConge { get; set; }
        public string finConge { get; set; }
        public string nbJours { get; set; }

        public string image { get; set; }


        public Conge(string urlPhoto, string image, string idEmploye, string typeConge,
            string nomEmploye, string prenomEmploye, string debutConge, string finConge, string nbJours)
        {
            this.image = image;
            this.idEmploye = idEmploye;
            this.urlPhoto = urlPhoto;
            this.typeConge = typeConge;
            this.nomEmploye = nomEmploye;
            this.prenomEmploye = prenomEmploye;
            this.debutConge = debutConge;
            this.finConge = finConge;
            this.nbJours = nbJours;

        }

    }



}
