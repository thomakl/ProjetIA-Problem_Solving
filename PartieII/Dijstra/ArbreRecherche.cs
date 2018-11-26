using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijstra {
    class ArbreRecherche {
        //ATTRIBUTS
        public List<Noeud> L_Ouverts;           //la liste des noeuds ouverts
        public List<Noeud> L_Fermes;            //la liste des noeuds fermés  


        //METHODES
        /*
         * Permet de chercher le noeud N dans la liste des noeuds fermés et de le renvoyer
         */
        private Noeud ChercheNoeudDansFermes(Noeud N) {
            int i = 0;

            while (i < L_Fermes.Count) {
                if (L_Fermes[i].EstEgal(N))
                    return L_Fermes[i];
                i++;
            }
            return null;
        }


        /*
         * Permet de chercher le noeud N dans la liste des noeuds ouverts et de le renvoyer
         */
        private Noeud ChercheNoeudDansOuverts(Noeud N) {
            int i = 0;

            while (i < L_Ouverts.Count) {
                if (L_Ouverts[i].EstEgal(N))
                    return L_Ouverts[i];
                i++;
            }
            return null;
        }

        

        /*
         * Permet de mettre à jour les successeurs de N (présent dans son attributs ListSucc)
         */
        private void MAJSuccesseurs(Noeud N) {
            List<Noeud> listsucc = N.ListeSucc();
            foreach (Noeud N2 in listsucc) {
                Noeud N2bis = ChercheNoeudDansFermes(N2);
                if (N2bis == null) { // Rien dans les fermés. Est-il dans les ouverts ?
                    N2bis = ChercheNoeudDansOuverts(N2);
                    if (N2bis != null) { //N2 est dans les ouverts, le chemin est-il le meilleur ?
                        if (N.CoutInit + N.CoutArc(N2) < N2bis.CoutInit) { //le chemin est meilleur
                            N2bis.CoutInit = N.CoutInit + N.CoutArc(N2);
                            N2bis.RecalculeCoutTotal();
                            N2bis.Supprime_Liens_Parent();
                            N2bis.SetNoeudParent(N);
                            L_Ouverts.Remove(N2bis);
                            this.InsertNouvNoeudLOuverts(N2bis);
                        }
                    } else { //N2 n'est ni dans les ouverts, ni dans les fermés : il est nouveau
                        N2.CoutInit = N.CoutInit + N.CoutArc(N2);
                        N2.SetNoeudParent(N);
                        N2.CalculCoutTotal();
                        this.InsertNouvNoeudLOuverts(N2);
                    }
                }
            }
        }



        /*
         * Permet d'insérer un nouveau noeud dans la liste des ouverts
         * L'insertion respecte l'ordre du cout total le plus petit au plus grand
         */
        public void InsertNouvNoeudLOuverts(Noeud NouvNoeud) {
            if (this.L_Ouverts.Count == 0) {
                L_Ouverts.Add(NouvNoeud);
            } else {
                Noeud N = L_Ouverts[0];
                bool trouve = false;
                int i = 0;
                do {
                    if (NouvNoeud.CoutTotal < N.CoutTotal) {
                        L_Ouverts.Insert(i, NouvNoeud);
                        trouve = true;
                    } else {
                        i++;
                        if (L_Ouverts.Count == i) {
                            N = null;
                            L_Ouverts.Insert(i, NouvNoeud);
                        } else { N = L_Ouverts[i]; }
                    }
                } while ((N != null) && (trouve == false));
            }
        }


        // Si on veut afficher l'arbre de recherche, il suffit de passer un treeview en paramètres
        // Celui-ci est mis à jour avec les noeuds de la liste des fermés, on ne tient pas compte des ouverts
        public TreeNode GetSearchTree() {
            if (L_Fermes == null) return null;
            if (L_Fermes.Count == 0) return null;
            
            TreeNode TN = new TreeNode(L_Fermes[0].ToString());

            AjouteBranche(L_Fermes[0], TN);
            return TN;
        }


        public void GetSearchTreeVide(TreeView TV) {
            if (L_Fermes == null) return;
            if (L_Fermes.Count == 0) return;

            // On suppose le TreeView préexistant
            TV.Nodes.Clear();

            TreeNode TN = new TreeNode("?");
            TV.Nodes.Add(TN);

            AjouteBrancheVide(L_Fermes[0], TN);
        }


        // AjouteBranche est exclusivement appelée par GetSearchTree; les noeuds sont ajoutés de manière récursive
        private void AjouteBranche(Noeud GN, TreeNode TN) {
            foreach (Noeud GNfils in GN.Enfants) {
                TreeNode TNfils = new TreeNode(GNfils.ToString());
                TN.Nodes.Add(TNfils);
                if (GNfils.Enfants.Count > 0) AjouteBranche(GNfils, TNfils);
            }
        }


        private void AjouteBrancheVide(Noeud GN, TreeNode TN) {
            foreach (Noeud GNfils in GN.Enfants) {
                TreeNode TNfils = new TreeNode("?");
                TN.Nodes.Add(TNfils);
                if (GNfils.Enfants.Count > 0) AjouteBrancheVide(GNfils, TNfils);
            }
        }


        //Permet de faire A* mais aussi de conserver tous les états des listes de noeuds ouverts et fermés
        public void RechercheSolutionAEtoileListe(Noeud N0, List<List<Noeud>> noeudsOuverts, List<List<Noeud>> noeudsFermes) {
            L_Ouverts = new List<Noeud>();
            L_Fermes = new List<Noeud>();
            // Le noeud passé en paramètre est supposé être le noeud initial
            Noeud N = N0;
            L_Ouverts.Add(N0);

            // tant que le noeud n'est pas terminal et que ouverts n'est pas vide
            while (L_Ouverts.Count != 0 && N.EtatFinal() == false) {
                // Le meilleur noeud des ouverts est supposé placé en tête de liste
                // On le place dans les fermés
                L_Ouverts.Remove(N);
                L_Fermes.Add(N);
                
                // Il faut trouver les noeuds successeurs de N
                this.MAJSuccesseurs(N);
                // Inutile de retrier car les insertions ont été faites en respectant l'ordre
                

                // On prend le meilleur, donc celui en position 0, pour continuer à explorer les états
                // A condition qu'il existe bien sûr
                if (L_Ouverts.Count > 0) {
                    N = L_Ouverts[0];
                } else {
                    N = null;
                }

                noeudsOuverts.Add(new List<Noeud>(L_Ouverts));
                noeudsFermes.Add(new List<Noeud>(L_Fermes));
            }
        }
    }
}

