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
        //ATTRIBUTS ET PROPRIETES
        public int Points { get; private set; }

        //CONSTRUCTEUR
        public FormDijkstra() {
            InitializeComponent();

            //POUR AFFICHER LE GRAPHE (ENONCE)
            //StreamReader monStreamReader = new StreamReader("graphe1.txt"); //à changer plus tard

            // 1ère ligne : nombre de noeuds du graphe
            string ligne = monStreamReader.ReadLine();
            int i = 0;
            while (ligne[i] != ':') {
                i++;
            }
            string strNbNoeuds = "";
            i++; // On dépasse le ":"
            while (ligne[i] == ' ') {
                i++; // on saute les blancs éventuels
            }
            while (i < ligne.Length) {
                strNbNoeuds = strNbNoeuds + ligne[i];
                i++;
            }
            int nbNoeuds = Convert.ToInt32(strNbNoeuds);

            double[,] matrice = new double[nbNoeuds, nbNoeuds];
            for (i = 0; i < nbNoeuds; i++) {
                for (int j = 0; j < nbNoeuds; j++) {
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


            // Choix des noeuds initial et d'arrivée
            Random r = new Random();
            int noeudInitial = r.Next(nbNoeuds);
            int noeudArrivee = r.Next(nbNoeuds);
            if (noeudInitial == noeudArrivee) { // pour éviter les cas d'égalités
                noeudArrivee = (noeudArrivee + 1) % nbNoeuds;
            }
            textBoxDepart.Text = noeudInitial.ToString();
            textBoxArrive.Text = noeudArrivee.ToString();


            //Remplissage des noeuds ouverts et fermés
            txtBoxFrep.Text = "{}\r\n";
            txtBoxOrep.Text = "{" + noeudInitial + "}\r\n";
        }


        //METHODES
        private void btnFin_Click(object sender, EventArgs e) {
            lblArbre.Visible = true;
            btnInitArbre.Visible = true;
            btnOkArbre.Visible = true;
            treeViewSaisie.Visible = true;
            btnInit.Visible = false;
            btnOk.Visible = false;
        }



        private void btnInit_Click(object sender, EventArgs e) {
            txtBoxFsaisie.Text = "";
            txtBoxOsaisie.Text = "";
        }



        private void btnOk_Click(object sender, EventArgs e) {
            //Ici tester si la ligne validée est juste
            bool repJuste = false;


            if (repJuste) {
                txtBoxFrep.Text += "{" + txtBoxFsaisie.Text + "}\r\n";
                txtBoxOrep.Text += "{" + txtBoxOsaisie.Text + "}\r\n";
                txtBoxFsaisie.Text = "";
                txtBoxOsaisie.Text = "";
            } else {
                MessageBox.Show("Réponse fausse !");
            }
        }
    }
}
