using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_bienvenue
{
    internal class TacheRACI
    {
        public string nomTache { get; set; }

        public string urlPhoto { get; set; }

        public string typeConge { get; set; }
        public string employe1 { get; set; }
        public string employe2 { get; set; }
        public string employe3 { get; set; }
        public string employe4 { get; set; }
        public string employe5 { get; set; }
        public string employe6 { get; set; }
        public string employe7 { get; set; }
        public string employe8 { get; set; }
        public string employe9 { get; set; }
        public string employe10 { get; set; }
        public string employe11 { get; set; }
        public string employe12 { get; set; }

        public string employe13 { get; set; }
        public string employe14 { get; set; }
        public string employe15 { get; set; }
        public string employe16 { get; set; }


        public TacheRACI(string nomTache, string employe1, string employe2, string employe3,
            string employe4, string employe5, string employe6, string employe7, string employe8, string employe9, string employe10, string employe11,
            string employe12, string employe13, string employe14, string employe15, string employe16)
        {
            this.nomTache = nomTache;
            this.employe1 = employe1;
            this.employe2 = employe2;
            this.employe3 = employe3;
            this.employe4 = employe4;
            this.employe5 = employe5;
            this.employe6 = employe6;
            this.employe7 = employe7;
            this.employe8 = employe8;
            this.employe9 = employe9;
            this.employe10 = employe10;
            this.employe11 = employe11;
            this.employe12 = employe12;
            this.employe13 = employe13;
            this.employe14 = employe14;
            this.employe15 = employe15;
            this.employe16 = employe16;
        }

    }

}

