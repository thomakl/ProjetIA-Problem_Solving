using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijstra {
    public partial class FormDijkstra : Form {
        public FormDijkstra() {
            InitializeComponent();


            //POUR AFFICHER LE GRAPHE (ENONCE)
            StreamReader monStreamReader = new StreamReader("graphe1.txt"); //à changer plus tard

            // 1ère ligne : nombre de noeuds du graphe
            string ligne = monStreamReader.ReadLine();
            int i = 0;
            while (ligne[i] != ':') {
                i++;
            }
            string strnbnoeuds = "";
            i++; // On dépasse le ":"
            while (ligne[i] == ' ') {
                i++; // on saute les blancs éventuels
            }
            while (i < ligne.Length) {
                strnbnoeuds = strnbnoeuds + ligne[i];
                i++;
            }
            int nbnodes = Convert.ToInt32(strnbnoeuds);

            double[,] matrice = new double[nbnodes, nbnodes];
            for (i = 0; i < nbnodes; i++) {
                for (int j = 0; j < nbnodes; j++) {
                    matrice[i, j] = -1;
                }
            }

            // Ensuite on a la structure suivante : 
            //  arc : n°noeud départ    n°noeud arrivée  valeur
            ligne = monStreamReader.ReadLine();
            while (ligne != null) {
                i = 0;
                while (ligne[i] != ':') {
                    i++;
                }
                i++; // on passe le :
                while (ligne[i] == ' ') {
                    i++; // on saute les blancs éventuels
                }
                string strN1 = "";
                while (ligne[i] != ' ') {
                    strN1 = strN1 + ligne[i];
                    i++;
                }
                int N1 = Convert.ToInt32(strN1);

                // On saute les blancs éventuels
                while (ligne[i] == ' ') i++;
                string strN2 = "";
                while (ligne[i] != ' ') {
                    strN2 = strN2 + ligne[i];
                    i++;
                }
                int N2 = Convert.ToInt32(strN2);

                // On saute les blancs éventuels
                while (ligne[i] == ' ') i++;
                string strVal = "";
                while ((i < ligne.Length) && (ligne[i] != ' ')) {
                    strVal = strVal + ligne[i];
                    i++;
                }
                double val = Convert.ToDouble(strVal);

                matrice[N1, N2] = val;
                matrice[N2, N1] = val;
                listBoxEnonce.Items.Add(Convert.ToString(N1)
                   + " ---> " + Convert.ToString(N2)
                   + "   :   " + Convert.ToString(matrice[N1, N2]));

                ligne = monStreamReader.ReadLine();
            }

            // Fermeture du StreamReader (obligatoire) 
            monStreamReader.Close();
        }


    }
}
