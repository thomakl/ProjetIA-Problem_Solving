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
        public int NbNoeuds { get; set; }                           //Nombre de noeuds dans le graphe
        public int NoeudInitial { get; set; }                       //Numéro du noeud initial
        public int NoeudArrivee { get; set; }                       //Numéro du noeud d'arrivée
        public double[,] Matrice { get; set; }                      //Matrice d'adjacence du graphe
        public int Etape { get; private set; }                      //Progression dans l'algo de Dijkstra
        public List<List<Noeud>> NoeudsOuverts { get; set; }        //Liste avec toutes les étapes de la liste de noeud ouverts
        public List<List<Noeud>> NoeudsFermes { get; set; }         //idem pour les noeuds fermés
        public int NoeudEnCours { get; set; }                       //pour le remplissage du TreeView, pour savoir où on est rendu
        public TreeNode ArbreCorrige { get; set; }                  //TreeNode de l'arbre juste
        public int Note { get; set; }                               //note du candidat



        //CONSTRUCTEUR
        public FormDijkstra(int note) {
            InitializeComponent();

            //Définition de la note du candidat
            Note = note;

            //Lecture de la question
            LectureFichier();

            // Choix des noeuds initial et d'arrivée
            Random r = new Random();
            NoeudInitial = r.Next(NbNoeuds);
            NoeudArrivee = r.Next(NbNoeuds);
            if (NoeudInitial == NoeudArrivee) { // pour éviter les cas d'égalités
                NoeudArrivee = (NoeudArrivee + 1) % NbNoeuds;
            }
            textBoxDepart.Text = NoeudInitial.ToString();
            textBoxArrive.Text = NoeudArrivee.ToString();


            //1ère étape du joueur
            this.Etape = 0;


            //Résolution du problème
            NoeudsOuverts = new List<List<Noeud>>();
            NoeudsFermes = new List<List<Noeud>>();
            ArbreRecherche arbre = new ArbreRecherche();
            NoeudNumero N0 = new NoeudNumero(this);
            N0.numero = NoeudInitial;
            arbre.RechercheSolutionAEtoileListe(N0, NoeudsOuverts, NoeudsFermes);
            ArbreCorrige = arbre.GetSearchTree();
            arbre.GetSearchTreeVide(treeViewSaisie);


            //Remplissage des textBox noeuds ouverts et fermés
            txtBoxFrep.Text = "{}\r\n";
            txtBoxOrep.Text = "{" + NoeudInitial + "}\r\n";
        }



        //METHODES
        private void LectureFichier() {
            StreamReader monStreamReader = new StreamReader("..\\..\\..\\PartieII\\Dijstra\\bin\\Debug\\graphe1.txt"); //à changer plus tard

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
            NbNoeuds = Convert.ToInt32(strNbNoeuds);

            Matrice = new double[NbNoeuds, NbNoeuds];
            for (i = 0; i < NbNoeuds; i++) {
                for (int j = 0; j < NbNoeuds; j++) {
                    Matrice[i, j] = -1;
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

                Matrice[N1, N2] = val;
                Matrice[N2, N1] = val;
                listBoxEnonce.Items.Add(Convert.ToString(N1)
                   + " ---> " + Convert.ToString(N2)
                   + "   :   " + Convert.ToString(Matrice[N1, N2]));

                ligne = monStreamReader.ReadLine();
            }

            // Fermeture du StreamReader (obligatoire) 
            monStreamReader.Close();
        }


        private void btnFin_Click(object sender, EventArgs e) {

        }



        private void btnInit_Click(object sender, EventArgs e) {
            txtBoxFsaisie.Text = "";
            txtBoxOsaisie.Text = "";
        }



        private void btnOk_Click(object sender, EventArgs e) {
            bool premierEssai = true;

            if (Etape < NoeudsOuverts.Count() && EstEgal(NoeudsOuverts[Etape], txtBoxOsaisie.Text) && EstEgal(NoeudsFermes[Etape], txtBoxFsaisie.Text)) { //réponse correcte
                txtBoxFrep.Text += "{" + txtBoxFsaisie.Text + "}\r\n";
                txtBoxOrep.Text += "{" + txtBoxOsaisie.Text + "}\r\n";
                txtBoxFsaisie.Text = "";
                txtBoxOsaisie.Text = "";
                Etape++;
                if (Etape == NoeudsOuverts.Count()) {
                    MessageBox.Show("Tu as réussi !");
                    lblArbre.Visible = true;
                    btnInitArbre.Visible = true;
                    btnOkArbre.Visible = true;
                    treeViewSaisie.Visible = true;
                    treeViewSaisie.ExpandAll();
                    btnAjoutArb.Visible = true;
                    txtBoxSaisieArb.Visible = true;
                    btnInit.Visible = false;
                    btnOk.Visible = false;

                    if (premierEssai) {
                        Note = Note + 2;
                    } else {
                        Note++;
                    }
                }
            } else { //réponse incorrecte
                MessageBox.Show("Réponse fausse !");
                premierEssai = false;
            }

        }


        private bool EstEgal(List<Noeud> listeNoeuds, string strNoeuds) {
            for (int i = 0; i < strNoeuds.Length; i++) {
                string strNum = "";
                while (i < strNoeuds.Length && strNoeuds[i] != ',') {
                    strNum += strNoeuds[i];
                    i++;
                }
                while (i < strNoeuds.Length && strNoeuds[i] == ' ') {
                    i++; // on saute les blancs éventuels
                }

                int num = int.Parse((string)strNum);

                //pour savoir si le noeud présent dans le string est aussi présent dans la liste
                int k = 0;
                bool trouve = false;
                while (k < listeNoeuds.Count() && trouve == false) {
                    int noeudNumero = ((NoeudNumero)listeNoeuds[k]).numero;
                    if (noeudNumero == num) {
                        trouve = true;
                        listeNoeuds.Remove(listeNoeuds[k]);
                    }
                    k++;
                }

                if (trouve == false) { //car ça veut dire qu'on a pas trouvé un noeud du string dans la liste réelle
                    return false;
                }
            }


            if (listeNoeuds.Count() != 0) { //car ça veut dire qu'un noeud de la liste réelle n'a pas été cité dans le string
                return false;
            } else {
                return true;
            }
        }


        private void btnAjoutArb_Click(object sender, EventArgs e) {

        }

        private void treeViewSaisie_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            e.Node.Text = txtBoxSaisieArb.Text;
        }

        private void btnOkArbre_Click(object sender, EventArgs e) {
            //TreeNode test = treeViewSaisie.Nodes[0];
            if (CompareTreeNodes(ArbreCorrige,treeViewSaisie.Nodes[0])) {
                MessageBox.Show("Tu as réussi !");
                Note++;
            } else {
                MessageBox.Show("Réponse fausse !");
            }
            FermerApp();
        }


        private bool CompareRecursiveTree(TreeNode tn1, TreeNode tn2) {
            if (tn1 == null || tn2 == null) {
                return tn1 == tn2;
            }

            if ((tn1.Text != tn2.Text) || (tn1.Nodes.Count != tn2.Nodes.Count)) {
                return false;
            }

            for (int i = 0; i < tn1.Nodes.Count; i++) {
                if (!CompareRecursiveTree(tn1.Nodes[i], tn2.Nodes[i])) {
                    return false;
                }
            }
            return true;
        }

        private bool CompareTreeNodes(TreeNode tn1, TreeNode tn2) {
            TreeNode tn1_Children1 = tn1;//.Nodes[0];
            TreeNode tn2_Children2 = tn2;//.Nodes[0];

            if (tn1_Children1 == null || tn2_Children2 == null) {
                return tn1_Children1 == tn2_Children2;
            }

            if (tn1_Children1.Nodes.Count != tn2_Children2.Nodes.Count) {
                return false;
            }

            for (int i = 0; i < tn1_Children1.Nodes.Count; i++) {
                if (!CompareRecursiveTree(tn1_Children1, tn2_Children2)) {
                    return false;
                }
            }
            return true;
        }


        public void FermerApp() {
            MessageBox.Show("Félicitations, tu as terminé le test !\n Tu as : " + Note + "/20");
            Application.Exit();
        }
    }
}
